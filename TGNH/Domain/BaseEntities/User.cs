using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BaseEntities
{
    public class User
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required] 
        public string UserName { get; set; }
        [MinLength(6)]
        [MaxLength(100)]
        [Required]
        public string Password { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        [Required]
        public string ActivationCode { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
