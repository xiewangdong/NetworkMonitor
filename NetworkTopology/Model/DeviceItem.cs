using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace NetworkTopology.Model
{
    public class DeviceItem
    {
        public string UpSource { get; set; }
        public string DownSource { get; set; }
        public string Name { get; set; }
        private string source;

        public string Source
        {
            get 
            {
                if (string.IsNullOrEmpty(source))
                {
                    source = DownSource;
                }
                return source; 
            }
            set { source = value; }
        }

    }
}
