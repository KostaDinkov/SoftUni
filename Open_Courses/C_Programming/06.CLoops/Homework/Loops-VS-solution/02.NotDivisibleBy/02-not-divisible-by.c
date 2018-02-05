/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		2. Not divisible by 3 and 7
*				Write a program that enters from the console a positive integer n
*				and prints all the numbers from 1 to n not divisible by 3 and 7, on a single line,
*				separated by a space.
* Date:			23-10-2015
*/

#include <stdio.h>

int main(void)
{
	int numCount;
	printf("Enter an integer: ");
	scanf("%i", &numCount);
	for (int i = 1; i <= numCount; i++)
	{
		if (i % 7 != 0 && i % 3 != 0)
		{
			printf("%i ", i);
		}
	}
	printf("\n");
	return 0;
}