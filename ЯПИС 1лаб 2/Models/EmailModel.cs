using System.ComponentModel.DataAnnotations;

namespace ЯПИС_1лаб_2.Models
{
    public class EmailModel
    {
        [CustomValidation(typeof(EmailValidation), "IsEmailValid")]
        public string? Email { get; set; }
    }
}
