using System.ComponentModel.DataAnnotations;
using bookAPI.Domain.Models;

namespace bookAPI.Infrastructure.Models
{
    public class UserRepository
    {
        [Key]
        public int Id { get; set; }
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime SignupDate {get; set;}
        public bool HasDiscount {get; set;}
    }
}
