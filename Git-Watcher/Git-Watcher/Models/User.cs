using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Git_Watcher.Models
{
    [Table("Users", Schema= "dbo")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(39)] // Max length Git
        public string GitUserName { get; set; }

        [Required]
        public Guid ApiKey{ get; set; }
    }
}
