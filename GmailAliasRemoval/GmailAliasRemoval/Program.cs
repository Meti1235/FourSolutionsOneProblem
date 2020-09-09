using System;
using System.Text.RegularExpressions;

namespace GmailAliasRemoval
{
    class Program
    {
       
        //Solution 1
        static string RegexAliasRemoval(string email)
        {
            
            Regex regex = new Regex(@"[+].+[@]");
            string output = regex.Replace(email, "@");
           
            return output;
        }

        //Solution 2
        static string SplitFuncAliasRemoval(string email)
        {

            
            char[] stringSeparators = { '+', '@' };
            string[] emailArray = email.Split(stringSeparators, StringSplitOptions.None);
            string output = emailArray[0] + "@" + emailArray[2];

            return output;
        }

        //Solution 3
        static string BoolAliasRemoval (string email)
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


            string emailInput = "sakipi.mu+office@gmail";

            //Solution 1 

            Console.WriteLine(RegexAliasRemoval(emailInput));

            //Solution 2

            Console.WriteLine(SplitFuncAliasRemoval(emailInput));

            //Solution 3

            Console.WriteLine(BoolAliasRemoval(emailInput));

            //Bonus Solution 4

            Console.WriteLine(NoFuncAliasRemoval(emailInput));


            Console.ReadLine();
         
        }


        //Bonus Solution 4
        //Dislamer: *This is not the type of code I would write normally. The challenge is to use no functions/methods*
        static string NoFuncAliasRemoval(string email)
        {

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
            string output = realEmailFirstPart + realEmailSecondPart;

            return output;
        }
    }
}
