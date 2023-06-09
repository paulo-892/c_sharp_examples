using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (input.Length == 0) return "";
        
        StringBuilder res = new StringBuilder("", input.Length);

        char curChar = '0';
        int pt = 0;
        int curCt = 0;

        while (pt < input.Length)
        {
            if (curChar == '0')
            {
                curChar = input[pt];
                pt++;
                curCt++;
            }
            else if (input[pt] == curChar)
            {
                pt++;
                curCt++;
            }
            else
            {
                res.Append(new string(curCt == 1 ? curChar.ToString() : curCt + "" + curChar));
                
                curChar = input[pt];
                pt++;
                curCt = 1;
            }
        }
        
        res.Append(new string(curCt == 1 ? curChar.ToString() : curCt + "" + curChar));
        
        return res.ToString();

    }

    public static string Decode(string input)
    {
        if (input.Length == 0) return "";
        
        StringBuilder res = new StringBuilder("", input.Length);
        StringBuilder charCount = new StringBuilder("", input.Length);

        int pt = 0;

        while (pt < input.Length)
        {
            char curChar = input[pt];
            
            if (char.IsDigit(curChar))
            {
                charCount.Append(curChar);
                pt++;
            }
            else if (!char.IsDigit(curChar) && charCount.Length > 0)
            {
                int ct = int.Parse(charCount.ToString());
                res.Append(curChar, ct);
                charCount.Clear();
                pt++;
            }
            else if (!char.IsDigit(curChar) && charCount.Length == 0)
            {
                res.Append(curChar);
                pt++;
            }
        }

        return res.ToString();
    }
}
