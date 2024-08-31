using Xunit;
using Bruteforce_inlämningsuppgift;

public class PasswordBruteForcerTests
{
    [Fact]
    public void NextGuess_ShouldGenerateCorrectInitialGuess()
    {
        // Arrange
        var bruteForcer = new PasswordBruteForcer(5);

        // Act
        string guess = bruteForcer.NextGuess();

        // Assert
        Assert.Equal("aaaaa", guess); // Note: the expected value should be "aaaaa"
    }
}
