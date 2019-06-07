using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.Models
{
    [Table("Subscriptions", Schema="dbo")]
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid RepoId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
