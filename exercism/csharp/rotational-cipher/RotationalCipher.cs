using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsUpper(c))
            {
                const int firstAscii = 65;
                char newChar = (char)(((int)c - firstAscii + shiftKey) % 26 + firstAscii);
                sb.Append(newChar);
            }
            else if (char.IsLower(c))
            {
                const int firstAscii = 97;
                char newChar = (char)(((int)c - firstAscii + shiftKey) % 26 + firstAscii);
                sb.Append(newChar);
            }
            else sb.Append(c);
        }

        return sb.ToString();
    }
}