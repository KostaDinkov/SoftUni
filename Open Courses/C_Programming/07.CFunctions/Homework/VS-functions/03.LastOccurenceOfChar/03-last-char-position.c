/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		3.Last Occurance Of Character
*				Write a function that takes determines the position of the rightmost 
*				occurrence of a character ch in a string str. If no such character exists, the function 
*				should return -1.
*
* Date:			24-10-2015
*/

#include <stdio.h>
#include "utils.h"

// Prototypes
int GetLastCharPosition(char ch, string input);


int main(void)
{
	printf("Enter a string: ");
	string input = GetString();
	printf("Enter a char: ");
	char ch = GetChar();

	int charPosition = GetLastCharPosition(ch, input);
	printf("The rightmost of %c is %i\n", ch, charPosition);
	return 0;
}
int GetLastCharPosition(char ch, string input)
{
	int index = 0;
	char currentChar = input[index];
	int lastPosition;
	int isFound = 0;
	while ((currentChar = input[index]) != NULL)
	{
		if (ch == currentChar)
		{
			lastPosition = index;
			isFound = 1;
		}
		index++;
	}
	if (isFound ==0)
	{
		return -1;
	}
	return lastPosition;
	
}