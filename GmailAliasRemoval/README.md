

# Three Solutions One Problem ??  
<br/>

## ?? The problem/Why we need it

#### Customers are using Gmails with append plus (“+”) sign to create multiple Gmails from one original Gmail.

GMail logic example: sakipi.mu<strong>+office</strong>@gmail == sakipi.mu@gmail.com 

<br/>

## ?? The Task

#### Removing the alias from GMail addresses by creating three different solutions
<br/>

## Solution 1 The Challenging One

Uses a Regular Expression to go through the string letter by letter until it finds a '+' character and removes everything from the plus until it finds the character '@' and then replace the alias with a new '@' sign. This was my first experience with Regex.

## Solution 2 The Fun One

Uses a Split() function by giving it a char array of the symbols '+' and '@' which tells the function where to cut the string. As a result, we have an array of 3 strings then we just concatenate strings the string with index 0 and index 2 which leaves out the alies string with idenx 1.


## Solution 3 The Popular One

Uses a method which accepts and returns a string. We are using a for loop to go through the given string by character by using the "i" temporary variable as an index incrementer which we are also using in our if and if else statements in order to check if the character in the current loop is '+' and if it is true to change our shouldCopy bool to false which tells our third if to stop concatenating up until we get to the symbol '@' in our loop which tells our if else statement to change our shouldCopy bool to true which tells our third if statement to continue concatenating our string output. In the end we return a string without the alias. All we have to do now is call the method and give it an Email.
 

## Bonus! Solution 4 The Painfull One
This was a challenge proposed by a Deveveloper friend of mine which was for me to come up with a solution but without using any inbuild or custom methods. This was far more difficult than one would think. Especially if ones mind is used to going straight to helpful shortcuts. In a way you will get a deeper understanding the code flow and you will appreciate more the methods and shortcuts that we have today. It is a challenge I recommend. Enjoy! ??  
<br/>

## Author Info

- Email - [sakipi.mu@gmail.com](mailto:sakipi.mu@gmail.com)
- LinkedIn - [Muhamed Sakipi](https://www.linkedin.com/in/muhamed-sakipi)




