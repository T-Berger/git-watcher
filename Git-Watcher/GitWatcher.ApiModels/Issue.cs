using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git_Watcher_Client.Models
{
    public class Issue
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Link { get; set; }
        public bool Important { get; set; }
    }
}