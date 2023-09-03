using bookAPI.Infrastructure.Models;

namespace bookAPI.Domain.Models{
    public class UserInputModel
    {
        public int Id { get; set; }
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime SignupDate {get; set;}
        public bool hasDiscount {get; set;}
    }
}
