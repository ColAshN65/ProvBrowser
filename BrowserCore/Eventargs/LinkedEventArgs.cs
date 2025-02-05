using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserCore.Eventargs
{
    public class LinkedEventArgs : EventArgs
    {
        public string NewUrl { get; set; }  

        public LinkedEventArgs(string newUrl)
        {
             NewUrl = newUrl;
        }
    }
}
