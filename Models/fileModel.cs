using System;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fileSearcher.Models
{
    public class fileModel
    {
        public fileModel()
        {
            this.lastRefreshed = new DateTime();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string path { get; set; }
        [Required]
        public fileTypeConstant type { get; set; }
        [Required]
        public DateTime createdDateTime { get; set; }
        [Required]
        public DateTime modifiedDateTime { get; set; }
        [Required]
        public DateTime lastRefreshed { get; set; }

    }
}