/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		2.Last Digit of a Number
*				Write a function that returns the last digit of a given 
*				integer as an English word. Test the function with different
*				input values. Ensure you name the function properly. Declare a 
*				function prototype before defining the function.
*
* Date:			24-10-2015
*/

#include <stdio.h>
#include "utils.h"

// Prototypes
int GetLastDigit(int number);
char * DigitAsWord(int digit);

int main(void) 
{
	printf("Enter a number: ");
	int number = GetInt();
	int lastDigit = GetLastDigit(number);
	char * digitAsWord = DigitAsWord(lastDigit);
	printf("Last Digit is: %s\n", digitAsWord);
	
	return 0;
}
int GetLastDigit(int number)
{
	return number % 10;
}
char * DigitAsWord(int digit)
{
	char * result;
	switch (digit)
	{
	case 0: result = "Zero"; break;
	case 1: result = "One"; break;
	case 2: result = "Two"; break;
	case 3: result = "Three"; break;
	case 4: result = "Four"; break;
	case 5: result = "Five"; break;
	case 6: result = "Six"; break;
	case 7: result = "Seven"; break;
	case 8: result = "Eight"; break;
	case 9: result = "Nine"; break;
	default: result = "Not a digit";break;
	}
	return result;
}