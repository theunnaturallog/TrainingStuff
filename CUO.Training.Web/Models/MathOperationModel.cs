using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CUO.Training.Web.Models
{
    public class MathOperationModel
    {
        [Display(Name="Value One")]
        public decimal X { get; set; }
        [Display(Name = "Value Two")]
        public decimal Y { get; set; }
        [Required(ErrorMessage = "Select an Operation")]
        public MathOperationEnum MyOperation { get; set; }
        public enum MathOperationEnum : int
        {
            Add = 0,
            Subtract = 1,
            Multiply = 2,
            Divide = 3
        }
    }
    
}