using System.ComponentModel.DataAnnotations;

namespace bookAPI.Infrastructure.Models
{
    public class OrderRepository
    {

        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }

    }
}
