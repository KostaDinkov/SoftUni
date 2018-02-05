/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		7. Recursive String Reverse
*				Write a recursive string reverse function. The function should accept
*				a source string and destination string as arguments. Do not use loops.
*
* Date:			24-10-2015
*/

#include <stdio.h>
#include <string.h>

// Protorypes
void Reverse(char arr[], size_t iStart, size_t iLast);

int main(void) 
{
	char  source [] = "Recursion"; // change the text between the double quotes to test other cases
	Reverse(source, 0, strlen(source) - 1);
	printf("Result: %s\n", source);

	return 0;
}
void Reverse(char arr[], size_t iStart, size_t iLast)
{
	if (iStart < iLast)
	{
		//swap
		char temp = arr[iStart];
		arr[iStart] = arr[iLast];
		arr[iLast] = temp;

		Reverse(arr, ++iStart, --iLast);
	}
}