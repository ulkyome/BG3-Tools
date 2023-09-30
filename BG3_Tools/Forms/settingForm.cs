using BG3_Tools.Helpers;
using NLog;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class settingForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public settingForm()
        {
            InitializeComponent();
            textBoxPathTempFolder.Text = loadConfig.cfgApp.ConfigPath.temp.root;
        }

        private void buttonSave_Click(object sender, System.EventArgs e)
        {
            loadConfig.save();
        }
    }
}
