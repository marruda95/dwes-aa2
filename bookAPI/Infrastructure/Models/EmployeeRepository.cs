﻿using System.ComponentModel.DataAnnotations;

namespace bookAPI.Infrastructure.Models
{
    public class EmployeeRepository
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateTime { get; set; }
        public int Age { get; set; }
        public bool IsOnVacation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
