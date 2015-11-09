/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		1. Numbers form 1 to N
*				Write a program that enters from the console a positive
*				integer n and prints all the numbers from 1 to n, on a single line,
*				separated by a space.
* Date:			23-10-2015
*/

#include <stdio.h>

int main(void) {
	int numCount;
	printf("Enter an integer: ");
	scanf("%i", &numCount);
	for (int i = 1; i <= numCount; i++)
	{
		printf("%i ", i);
	}
	printf("\n");
	return 0;
}