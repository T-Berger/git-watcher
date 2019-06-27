using System;

namespace Git_Watcher_Client.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        
        public string GitUserName { get; set; }
        
        public Guid ApiKey{ get; set; }
    }
}