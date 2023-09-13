using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFL
{
    public class XaxatNtbI
    {
        public string Name { get; set; }
        public bool IsAccept { get; set; }
        public bool IsStart { get; set; }
        public Dictionary<string, XaxatNtbI> Path { get; set; }
        public XaxatNtbI()
        {
            Name = string.Empty;
            IsAccept = false;
            IsStart = false;
            Path = new();
        }
    }
}
