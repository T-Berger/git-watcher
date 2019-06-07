using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.Models
{
    [Table("GitRepos",Schema ="dbo")]
    public class GitRepository
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)] // Max length Git
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }
    }
}
