using System;
using System.Runtime.CompilerServices;
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
            //Regex/Regular Expression(without knowing anything about Regex I managed to solved it in 50min in JS and then C#)
            // JS version: console.log( 'meti20+whatever@gmail.com'.replace(/[+].+[@]/g,'@'))
            // C# version:
            string emailRegex = "meti20+whatever@gmail.com";
            Regex regex = new Regex(@"[+].+[@]");
            string realRegexEmail = regex.Replace(emailRegex, "@");

            Console.WriteLine(realRegexEmail);

            //Solution 2
            //This solution was the most fun (Split also accepts a String array the same way)
            string emailSplit = "meti20+whatever@gmail.com";
            char[] stringSeparators = { '+', '@' };
            string[] emailArray = emailSplit.Split(stringSeparators, StringSplitOptions.None);
            string realSplitEmail = emailArray[0] + "@" + emailArray[2];

            Console.WriteLine(realSplitEmail);



            //Solution 3
            // The most prefered solution because it is the most scalable and clean.
            // I am creating and using a custom method.
            //C# Version:
            RemoveAlias("meti20+whatever@gmail.com");

            //JS Version:
            //           let email = "meti20+whatever@gmail.com"
            //           function removeAlias(email){
            //            
            //                let output = '';
            //                let shouldCopy = true;
            //                for (let i = 0; i < email.length; i++)
            //                {
            //                    if (email.charAt(i) === '+') shouldCopy = false;
            //                    else if (email.charAt(i) === '@') shouldCopy = true;
            //                    if (shouldCopy) output += email.charAt(i);
            //                }
            //                return output;

            //            }
            //            console.log(removeAlias(email));



            //Solution 4
            //This was a challenge proposed by an old Dev friend to write the same code with no methods/functions like they used to 10years ago
            //Writing code while actually avoiding very helpful methods is harder than you think because your brain is wired to use them

            //Dislamer: *This is not the type of code I prefer*

            string emailNoFunc = "meti20+whatever@gmail.com";
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

            //string realEmailNoFunc = emailNoFunc.Substring(0, plus) + emailNoFunc.Substring(atSign);
            //Console.WriteLine(realEmailNoFunc);
            //Apperently Substring() is not allowed so here I continue below

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


            //Finding 4 different solutions to a problem I already solved helped me get a deeper understanding of how the code flows
            //It is a good excercise that I recommend

            Console.ReadLine();


        }
    }
}
