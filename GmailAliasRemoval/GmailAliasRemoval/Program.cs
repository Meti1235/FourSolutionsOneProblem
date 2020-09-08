using System;

namespace GmailAliasRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = "meti20+whatever@gmail.com";
            char[] emailCharArray = email.ToCharArray();
            int plusSign = 0;
            foreach (var emailChar in emailCharArray)
            {
                plusSign++;
                if (emailChar == '+')
                {
                    plusSign--;
                    break;

                }
            }
            int atSign = 0;
            foreach (var emailChar in emailCharArray)
            {
                atSign++;
                if (emailChar == '@')
                {
                    atSign--;
                    break;
                }
            }

            //string realEmail2 = email.Substring(0, plus) + email.Substring(atSign);
            //Console.WriteLine(realEmail2);

            char[] newEmailCharArray = null;
            char[] newEmailCharArray2 = null;

            for (int i = 0; i < plusSign; i++)
            {
                Array.Resize(ref newEmailCharArray, i + 1);
                newEmailCharArray[i] = emailCharArray[i];
            }

            for (int i = atSign; i < emailCharArray.Length; i++)
            {
                Array.Resize(ref newEmailCharArray2, i + 1 - atSign);
                newEmailCharArray2[i - atSign] = emailCharArray[i];
            }
            string realEmailFirstPart = new string(newEmailCharArray);
            string realEmailSecondPart = new string(newEmailCharArray2);

            string realEmail3 = realEmailFirstPart + realEmailSecondPart;
            Console.WriteLine(realEmail3);
            //meti

        }
    }
}
