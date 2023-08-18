using System.ComponentModel.DataAnnotations;
using bookAPI._1_Domain.Models;

namespace bookAPI._2_Infrastructure.Models
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
        public List<BookRepository> BookList {get; set;}
    }
}
