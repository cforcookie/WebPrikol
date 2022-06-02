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

        [Theory]
        [InlineData(79208880519)]
        [InlineData(79186162760)]
        public void Test_Post_Buyer1(long? phoneNumber)
            => Assert.True(_validation.IsValid(phoneNumber));

        [Theory]
        [InlineData(7920888051900000)]
        [InlineData(09186162760)]
        public void Test_Post_Buyer2(long? phoneNumber)
            => Assert.False(_validation.IsValid(phoneNumber));
    }
}




