using System.Text.RegularExpressions;

namespace WebPrikol.Validation
{
    public class PhoneNumberValidation
    {
        public bool IsValid(long? phoneNumber)
        {
            Regex regex = new(@"^(7|8){1}\d{10}$");
            return regex.IsMatch(phoneNumber.ToString());
        }


    }
}
