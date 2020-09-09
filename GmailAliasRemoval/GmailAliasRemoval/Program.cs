using System;
using System.Text.RegularExpressions;

namespace GmailAliasRemoval
{
    class Program
    {
        //Solution 3
        static string RemoveAlias(string email)
        {
            string output = "";
            bool shouldCopy = true;
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] == '+') shouldCopy = false;
                else if (email[i] == '@') shouldCopy = true;
                if (shouldCopy) output += email[i];
            }
            return output;
        }

        static void Main(string[] args)
        {

            //Solution 1 

            string emailRegex = "sakipi.mu+office@gmail";
            Regex regex = new Regex(@"[+].+[@]");
            string realRegexEmail = regex.Replace(emailRegex, "@");
            Console.WriteLine(realRegexEmail);

            //Solution 2

            string emailSplit = "sakipi.mu+office@gmail";
            char[] stringSeparators = { '+', '@' };
            string[] emailArray = emailSplit.Split(stringSeparators, StringSplitOptions.None);
            string realSplitEmail = emailArray[0] + "@" + emailArray[2];
            Console.WriteLine(realSplitEmail);


            //Solution 3

            string emailMethod = "sakipi.mu+office@gmail";
            Console.WriteLine(RemoveAlias(emailMethod));

            //Solution 4
            //Dislamer: *This is not the type of code I would write normally*

            string emailNoFunc = "sakipi.mu+office@gmail";
            char[] emailCharArray = emailNoFunc.ToCharArray();
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

            char[] newEmailCharArrayPlusSign = null;
            char[] newEmailCharArrayAtSign = null;

            for (int i = 0; i < plusSign; i++)
            {
                Array.Resize(ref newEmailCharArrayPlusSign, i + 1);
                newEmailCharArrayPlusSign[i] = emailCharArray[i];
            }

            for (int i = atSign; i < emailCharArray.Length; i++)
            {
                Array.Resize(ref newEmailCharArrayAtSign, i + 1 - atSign);
                newEmailCharArrayAtSign[i - atSign] = emailCharArray[i];
            }

            string realEmailFirstPart = new string(newEmailCharArrayPlusSign);
            string realEmailSecondPart = new string(newEmailCharArrayAtSign);
            string realEmailNoFunc = realEmailFirstPart + realEmailSecondPart;
            Console.WriteLine(realEmailNoFunc);


            Console.ReadLine();
            //Finding 4 different solutions to a problem I already solved helped me get a deeper understanding of how the code flows
            //It is a good excercise that I recommend
        }
    }
}
