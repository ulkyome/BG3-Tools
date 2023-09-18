using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BG3_Tools.Helpers
{
    internal class Generate
    {
        public static string GuID(bool isHandle)
        {

            var guid = Guid.NewGuid();
            return isHandle ? $"h{guid}".Replace('-', 'g') : guid.ToString();
        }

    }
}
