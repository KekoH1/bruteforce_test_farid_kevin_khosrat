using System;
using System.Threading;
using OtpNet;

namespace Bruteforce_inlämningsuppgift
{

    public class PasswordBruteForcer
{
    private readonly char[] alphabet;
    private readonly int[] pos;
    private readonly int passwordLength;
    private bool isFirstGuess = true;

    public PasswordBruteForcer(int length)
    {
        alphabet = new char[]
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', ';', ':', '\'', '"', ',', '.', '/', '?', '<', '>', '|'
        };
        passwordLength = length;
        pos = new int[passwordLength];
    }

    public string NextGuess()
    {
        if (isFirstGuess)
        {
            isFirstGuess = false;
            return new string('a', passwordLength);
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (pos[i] < alphabet.Length - 1)
            {
                pos[i]++;
                break;
            }
            else
            {
                pos[i] = 0;
            }
        }

        return ConvertPosToString(pos);
    }

    private string ConvertPosToString(int[] positions)
    {
        char[] chars = new char[positions.Length];
        for (int i = 0; i < positions.Length; i++)
        {
            chars[i] = alphabet[positions[i]];
        }
        return new string(chars);
    }
}

}