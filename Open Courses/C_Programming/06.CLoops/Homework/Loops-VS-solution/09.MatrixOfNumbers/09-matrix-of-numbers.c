/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		9. Matrix of Numbers
*				Write a program that reads from the console a positive integer number
*				n (1 ? n ? 20) and prints a matrix like in the examples below. Use two nested loops.
*
* Date:			23-10-2015
*/

#include <stdio.h>
int GetInt(char *prompt);
int main(void)
{
	int n = GetInt("Enter a number (0<n<21): ");
	for (int i = 1; i <= n; i++)
	{
		for (int j = i; j < i + n; j++)
		{
			printf("%i ", j);
		}
		printf("\n");
	}
	return 0;
}
int GetInt(char *prompt)
{
	printf(prompt);
	int n;
	scanf("%i", &n);
	return n;
}