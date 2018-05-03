using System;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fileSearcher.Models
{
    public class file
    {
        public file()
        {
            this.lastRefreshed = new DateTime();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileId { get; set; }

        [Required]
        public string name { get; set; }
        [Required]
        public fileTypes type { get; set; }
        [Required]
        public DateTime createdDateTime { get; set; }
        [Required]
        public DateTime modifiedDateTime { get; set; }
        [Required]
        public DateTime lastRefreshed { get; set; }

    }
}