using System.ComponentModel.DataAnnotations;
using bookAPI._1_Domain.Models;
namespace bookAPI._2_Infrastructure.Models
{
    public class BookRepository
    {
        [Key]
        public int Id {get; set;}
        public string Name {get; set;}
        public string Author {get; set;}
        public string Genre {get; set;}
        public double Price {get; set;}
        public DateTime DatePublished {get; set;}
        public bool IsInStock {get; set;}
        public int Stock {get; set;}
        public bool IsRemoved {get; set;}
    }
}
