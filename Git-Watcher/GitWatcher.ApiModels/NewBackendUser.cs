using System;

namespace GitWatcher.ApiModels
{
    public class NewBackendUser
    {
        public Guid Key { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return "{" +
                    $"UserName:{UserName}," +
                    $"Key:{Key.ToString()}" +
                "}";
        }
    }
}
