using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrudEntityFramework.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee name is requied")]
        [DataType(DataType.Text)]
        [Display(Name = "Empolyee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        [DataType(DataType.Text)]
        [Range(minimum: 1, maximum: 100000)]
        public double Salary { get; set; }
    }
}
