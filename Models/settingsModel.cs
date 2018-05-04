using System.Collections.Generic;
using fileSearcher.constants;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fileSearcher.Models
{


    public class searchFolder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid searchFolderId { get; set; }

        [Required]
        [RegularExpression(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$")]
        public string folderPath { get; set; }
    }
    public class fileType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid fileTypeId { get; set; }

        [Required]
        public fileTypeConstant type { get; set; }
    }
}