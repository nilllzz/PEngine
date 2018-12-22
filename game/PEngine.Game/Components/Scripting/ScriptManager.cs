using Kolben;
using Kolben.Adapters;
using Kolben.Types;
using PEngine.Game.Components.Scripting.ApiClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PEngine.Game.Components.Scripting
{
    internal class ScriptManager
    {
        private int _activeProcessorCount = 0;
        private List<SObject> _prototypeBuffer;
        private Dictionary<string, MethodInfo[]> _apiClasses;

        public bool IsActive => _activeProcessorCount > 0;

        public void RunScript(string source)
        {
            _activeProcessorCount++;

            Task.Run(() =>
            {
                try
                {
                    var processor = CreateProcessor();
                    var result = processor.Run(source);

                    if (ScriptContextManipulator.ThrownRuntimeError(processor) &&
                        ScriptOutAdapter.Translate(result) is ScriptRuntimeException runtimeException)
                    {
                        throw runtimeException;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred during script execution: " + ex.Message);
                }

                _activeProcessorCount--;
            });
        }

        private ScriptProcessor CreateProcessor()
        {
            if (_prototypeBuffer == null)
            {
                InitializePrototypeBuffer();
            }

            var processor = new ScriptProcessor(_prototypeBuffer);
            ScriptContextManipulator.SetCallbackExecuteMethod(processor, ExecuteMethod);

            return processor;
        }

        private SObject ExecuteMethod(ScriptProcessor processor, string className, string methodName, SObject[] parameters)
        {
            if (_apiClasses == null)
            {
                InitializeApiClasses();
            }

            if (_apiClasses.ContainsKey(className))
            {
                var method = _apiClasses[className].FirstOrDefault(m => m.Name == methodName);
                if (method != null)
                {
                    var result = method.Invoke(null, new object[] { processor, parameters });
                    return (SObject)result;
                }
            }

            return ScriptInAdapter.GetUndefined(processor);
        }

        private void InitializePrototypeBuffer()
        {
            _prototypeBuffer = new List<SObject>();
            var processor = new ScriptProcessor(); // only used to initialize prototypes

            foreach (var o in typeof(ScriptManager).Assembly.GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(ScriptPrototypeAttribute), true).Length > 0))
            {
                _prototypeBuffer.Add(ScriptInAdapter.Translate(processor, o));
            }
        }

        private void InitializeApiClasses()
        {
            _apiClasses = new Dictionary<string, MethodInfo[]>();

            foreach (var o in typeof(ScriptManager).Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ApiClass)) && t.GetCustomAttributes(typeof(ApiClassAttribute), true).Length > 0))
            {
                var attr = o.GetCustomAttribute<ApiClassAttribute>();
                var methods = o.GetMethods(BindingFlags.Public | BindingFlags.Static);

                if (methods.Length > 0)
                {
                    _apiClasses.Add(attr.ClassName, methods.ToArray());
                }
            }
        }

        public static void WaitUntil(Func<bool> condition)
        {
            SpinWait.SpinUntil(condition);
        }
    }
}
