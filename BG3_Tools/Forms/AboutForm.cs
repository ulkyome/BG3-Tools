using NLog;
using System.Reflection;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class AboutForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AboutForm()
        {
            var appInfo = Assembly.GetExecutingAssembly();
            InitializeComponent();

            verApp.Text = $"ver {LoadingForm.Version}";
            NameApp.Text = $"{appInfo.GetCustomAttribute<AssemblyTitleAttribute>().Title}";
            NameApp.Parent = pictureBox1;
            labelBName.Text = $"{appInfo.GetCustomAttribute<AssemblyCompanyAttribute>().Company}";
            labelBName.Parent = pictureBox1;
            richTextBoxDesc.Text = $"{appInfo.GetCustomAttribute<AssemblyDescriptionAttribute>().Description}";
        }
    }
}
