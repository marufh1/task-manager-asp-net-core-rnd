using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TASKMANAGER21.Models
{
    public partial class Projectd
    {

        public string Prid { get; set; }
        [Display(Name = "Project Name")]
        [Required]
        public string Prname { get; set; }
        [Display(Name = "Project Description")]
        [Required]
        public string Prdesc { get; set; }
    }
}
