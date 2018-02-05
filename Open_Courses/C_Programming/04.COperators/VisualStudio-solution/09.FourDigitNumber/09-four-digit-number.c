/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		9. Four Digit Number
**				Write a program that takes as input a four-digit number in format abcd (e.g. 2011) and performs the following:
*                - Calculates the sum of the digits (in our example 2+0+1+1 = 4).
*                - Prints on the console the number in reversed order: dcba (in our example 1102).
*                - Puts the last digit in the first position: dabc (in our example 1201).
*                - Exchanges the second and the third digits: acbd (in our example 2101).
*                The number has always exactly 4 digits and cannot start with 0.
*/

#include <stdio.h>
#include <stdlib.h>

//Prototypes
int charToInt(char d);

int main(void) {
    
    //NOTE:
    // Getting the input as string for easier moving of digits around
    // I could have done it with math operations also, but decided to practice strings
    char input[6];
    int i;
     
    printf("Enter a four digit number: ");
    fgets(input, 6, stdin);

    /* remove newline, if present */
    i = strlen(input) - 1;
    if (input[i] == '\n')
        input[i] = '\0';

    int sum = 
        charToInt(input[0]) + 
        charToInt(input[1]) + 
        charToInt(input[2]) + 
        charToInt(input[3]);
  
    printf("The sum of the digits is: %i\n", sum);
    printf("Reversed: %c%c%c%c\n", input[3], input[2], input[1], input[0]);
    printf("Last digit in front: %c%c%c%c\n", input[3], input[0], input[1], input[2]);
    printf("Second and third digits exchanged: %c%c%c%c\n", input[0], input[2], input[1], input[3]);

	return 0;
}
/**
 *  Converts a char representing a digit to numeric data type int
 */
int charToInt(char d)
{
    char str[2];

    str[0] = d;
    str[1] = '\0';
    return (int)strtol(str, NULL, 10);
}
