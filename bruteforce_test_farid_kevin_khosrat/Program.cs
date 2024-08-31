using System;
using System.Threading;
using Bruteforce_inlämningsuppgift;
using OtpNet;
namespace Bruteforce_inlämningsuppgift
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Password (max 6 letters, recommended 4): ");
            string password = Console.ReadLine();

            PasswordBruteForcer bruteForcer = new PasswordBruteForcer(password.Length);
            TwoFactorAuthentication twoFA = new TwoFactorAuthentication("JBSWY3DPEHPK3PXP");
            AccountSecurity security = new AccountSecurity();

            int count = 0;
            int maxAttempts = 1000000;

            while (!security.IsBlocked)
            {
                string guess = "Farid";


                if (guess == password)
                {
                    Console.WriteLine(" Proceeding to 2FA...");
                    string code = twoFA.GenerateCode();
                    Console.WriteLine($"Your 2FA code is: {code}");

                    Console.Write("Enter 2FA code: ");
                    string userCode = Console.ReadLine();

                    if (twoFA.VerifyCode(userCode))
                    {
                        Console.WriteLine("2FA authentication successful!");
                        Console.WriteLine($"Found password: {guess}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid 2FA code.");
                        security.RecordFailedAttempt();
                    }
                }
                else
                {
                    security.RecordFailedAttempt();
                    if (!security.IsBlocked)
                    {
                        Console.WriteLine("Incorrect password.");
                    }
                }

                if (count >= maxAttempts)
                {
                    Console.WriteLine("Maximum attempts reached. Terminating brute force attack.");
                    break;
                }
            }

            if (security.IsBlocked)
            {
                Console.WriteLine("Your account is temporarily blocked due to multiple failed login attempts. Please try again later.");
            }
        }
    }
}