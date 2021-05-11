using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace TASKMANAGER21.Models
{
    public partial class Tasks1
    {
        public string Tskid { get; set; }

        [Display(Name = "Task Name")]
        [Required]
        public string Tskname { get; set; }
        [Display(Name = "Description")]
        public string Tskdesc { get; set; }
        [Display(Name = "Status")]
        [Required]
        public string Tskstatus { get; set; }
        [Display(Name = "Priority")]
        [Required]
        public string Tskpriority { get; set; }
        [Display(Name = "Assigned By")]
        public string Tskowner { get; set; }
        [Display(Name = "Assigned To")]
        [Required]
        public string Tskassigned { get; set; }

        [Display(Name = "Start Date")]
        [Required]
        public DateTime Tskstart { get; set; }

        [Display(Name = "Due Date")]
        [Required]
        public DateTime Tskendtime { get; set; }

        [Required]
        [Display(Name = "Project")]
        public string Tskproject { get; set; }
        [Display(Name = "")]
        public DateTime Rowtime { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Column(Order = 0)]
        public long Rowid { get; set; }
    }
}
