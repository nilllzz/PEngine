using PEngine.Creator.Views.Projects;
using System.Windows.Forms;

namespace PEngine.Creator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            // load main view
            var view = new WelcomeView();
            panel_main.Controls.Add(view);
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
