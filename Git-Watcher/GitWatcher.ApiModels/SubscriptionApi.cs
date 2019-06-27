using System;
using System.Collections.Generic;
using System.Text;

namespace GitWatcher.ApiModels
{
    public class SubscriptionApi
    {
        public Guid ApiKey { get; set; }
        public string RepoId { get; set; }

        public override string ToString()
        {
            return "{" +
                    $"RepoId:\"{RepoId}\"," +
                    $"Key:\"{ApiKey.ToString()}\"" +
                "}";
        }
    }
}
