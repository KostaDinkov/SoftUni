/*
* SoftUni
* Course:		C Programming
* Lecture:		Condidional Statements
* Problem:		8. Digit As Word
*				Write a program that asks for a digit (0-9), and depending on 
*				the input, shows the digit as a word (in English). Print “not a digit” in case 
*				of invalid inut. Use a switch statement.
*/

#include <stdio.h>;

int main(void) 
{

	printf("Enter a digit(0 - 9): ");
	int digit;
	scanf("%i", &digit);

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
	printf("%s\n", result);
	return 0;
}