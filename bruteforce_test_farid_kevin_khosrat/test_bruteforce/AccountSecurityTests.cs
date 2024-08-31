using Xunit;
using Bruteforce_inlämningsuppgift;

public class AccountSecurityTests
{
    [Fact]
    public void RecordFailedAttempt_ShouldBlockAccountAfterMaxAttempts()
    {
        // Arrange
        var security = new AccountSecurity();

        // Act
        security.RecordFailedAttempt();
        security.RecordFailedAttempt();
        security.RecordFailedAttempt();

        // Assert
        Assert.True(security.IsBlocked);
    }
}