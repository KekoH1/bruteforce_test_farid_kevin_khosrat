using OtpNet;
using System;
using System.Threading;
using OtpNet;

namespace Bruteforce_inlämningsuppgift
{
    public class TwoFactorAuthentication
    {

        private readonly Totp otp;

        public TwoFactorAuthentication(string userSecretKey)
        {
            otp = new Totp(Base32Encoding.ToBytes(userSecretKey));
        }

        public string GenerateCode()
        {
            return otp.ComputeTotp();
        }

        public bool VerifyCode(string userCode)
        {
            return otp.VerifyTotp(userCode, out long timeStepMatched, new VerificationWindow(previous: 2, future: 2));
        }
    }


}