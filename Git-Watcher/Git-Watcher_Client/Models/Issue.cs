using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Git_Watcher_Client.Models
{
    public class Issue
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Link { get; set; }
    }
}