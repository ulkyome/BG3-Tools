using NLog;
using System.Windows.Forms;

namespace BG3_Tools.Forms
{
    public partial class AboutForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public AboutForm()
        {
            InitializeComponent();
        }
    }
}
