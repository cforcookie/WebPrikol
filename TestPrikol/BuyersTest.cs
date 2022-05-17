using Xunit;
using WebPrikol.Validation;

namespace TestPrikol
{
    public class BuyersTest
    {
        private readonly PhoneNumberValidation _validation;

        public BuyersTest() => _validation = new PhoneNumberValidation();

        [Fact]
        public void Test_Post_Buyer()
            => Assert.True(_validation.IsValid(79208880519));
    }
}




