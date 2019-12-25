using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
using EmpoyeeRegisteration.Constants;
using System.Web.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpoyeeRegisteration.Models
{
    public class Employee
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Employee Name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Employee Name Should be min 2 and max 20 length")]
        public string EmployeeName { get; set; }


        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter correct Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [Key]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email Id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please Provide Valid Email")]
        public string EmailId { get; set; }


        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfJoining { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Select Employee Department")]
        public string EmployeeDepartment { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select marital status")]
        public string MaritalStatus { get; set; }

    }

}