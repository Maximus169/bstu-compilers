using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ЯПИС_1лаб_2.Models
{
    public class EmailValidation
    {
        public static ValidationResult? IsEmailValid(string email, ValidationContext context)
        {
            string cond = @"(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)";
            if (email != null && Regex.IsMatch(email, cond))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Incorrect email adress", new[] { context.MemberName });
        }
    }
}
