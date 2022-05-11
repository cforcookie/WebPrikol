using System.Text.RegularExpressions;

namespace WebPrikol.Validation
{
    public class PhoneNumberValidation
    {
        public bool IsValid(int phoneNumber)
        {
            string phNum = "+7(918)-217-27-63";
            Regex regex = new Regex(@"+7(\d*)");
            //Regex regex = new Regex(@"(8|9){1}-[0-9]{2}-[0-9]{3}-\d{4}");
            MatchCollection matches = regex.Matches(phNum);


            return true;
        }


    }
}
