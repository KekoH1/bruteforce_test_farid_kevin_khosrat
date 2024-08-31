using Xunit;
using Bruteforce_inlämningsuppgift;

public class TwoFactorAuthenticationTests
{
    [Fact]
    public void VerifyCode_ShouldReturnTrueForCorrectCode()
    {
        // Arrange
        var twoFA = new TwoFactorAuthentication("JBSWY3DPEHPK3PXP");
        string code = twoFA.GenerateCode();

        // Act
        bool result = twoFA.VerifyCode(code);

        // Assert
        Assert.True(result);
    }
}