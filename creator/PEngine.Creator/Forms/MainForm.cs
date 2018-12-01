using PEngine.Creator.Components.Projects;
using PEngine.Creator.Views;
using PEngine.Creator.Views.Projects;
using System;
using System.Windows.Forms;

namespace PEngine.Creator.Forms
{
    public partial class MainForm : Form
    {
        public static MainForm Instance => (MainForm)ActiveForm;

        public BaseView ActiveView
        {
            get
            {
                if (panel_main.Controls.Count == 1 && panel_main.Controls[0] is BaseView)
                {
                    return (BaseView)panel_main.Controls[0];
                }
                return null;
            }
        }

        public MainForm()
        {
            InitializeComponent();

            // load main view
            var view = new WelcomeView();
            SetView(view);
        }

        public void SetView(BaseView view)
        {
            if (ActiveView != null)
            {
                ActiveView.StatusChanged -= OnStatusChanged;
                ActiveView.TitleChanged -= OnTitleChanged;
                ActiveView.Dispose();
            }
            panel_main.Controls.Clear();
            panel_main.Controls.Add(view);
            view.StatusChanged += OnStatusChanged;
            view.TitleChanged += OnTitleChanged;
            OnStatusChanged(view.Status);
            OnTitleChanged(view.Title);
        }

        private void OnStatusChanged(string status)
        {
            status_label_status.Text = status;
        }

        private void OnTitleChanged(string title)
        {
            var newTitle = "PEngine Creator";
            if (title != null && title.Length > 0 && title.Trim().Length > 0)
            {
                newTitle = title.Trim() + " - " + newTitle;
            }
            Text = newTitle;
        }

        private void menu_file_openproject_Click(object sender, EventArgs e)
        {
            ProjectService.OpenProject(this);
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    var process = new Process
        //    {
        //        StartInfo = new ProcessStartInfo()
        //        {
        //            FileName = "PEngine.Game.exe",
        //            RedirectStandardOutput = true,
        //            UseShellExecute = false,
        //        }
        //    };
        //    process.Start();
        //    var stream = process.StandardOutput;
        //    while (!stream.EndOfStream)
        //    {
        //        var line = stream.ReadLine();
        //        Console.WriteLine(line);
        //    }
        //}
    }
}
