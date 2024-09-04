using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public bool InReview { get; set; }
    }
}
