using System;

namespace Git_Watcher_Client.Dto
{
    public class SubscriptionDto
    {
        public Guid Id { get; set; }
        
        public Guid RepoId { get; set; }
        
        public Guid UserId { get; set; }
    }
}