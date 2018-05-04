using System.Collections.Generic;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fileSearcher.Models
{


    public class searchFolderModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid searchFolderId { get; set; }

        [Required]
        public string folderPath { get; set; }
    }
    public class fileTypeModel
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileTypeId { get; set; }

        [Required]
        public fileTypeConstant type { get; set; }
    }
}