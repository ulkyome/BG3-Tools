using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BG3_Tools.Models
{
    public class activeFormModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string titleWin { get; set; }
        public string codeError { get; set; }
        public string link { get; set; }
        public Action action { get; set; }
    }
}
