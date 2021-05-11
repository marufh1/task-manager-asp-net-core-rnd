using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TASKMANAGER21.Models
{
    public partial class Resinf
    {
        public string Rescode { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string Resname { get; set; }
        [Display(Name = "User Type")]
        [Required]
        public string Restype { get; set; }
        [Display(Name = "Email")]
        [Required]
        public string Resemail { get; set; }
        [Display(Name = "Phone")]
        [Required]
        public string Resphone { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Resstatus { get; set; }
        [Display(Name = "Designation")]
        [Required]
        public string Resdesig { get; set; }
    }
}
