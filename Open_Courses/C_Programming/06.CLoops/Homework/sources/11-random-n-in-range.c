/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		11. Random Numbers in Given Range
*				Write a program that enters 3 integers n, min and max (min ? max)
*				and prints n random numbers in the range [min...max].
*
* Date:			23-10-2015
*/

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// Prototypes
 int rand_interval( int min,  int max);
int GetInt(char *prompt);

int main(void)
{
	unsigned int n = GetInt("How many random numbers to generate: ");
	int minNum = GetInt("Enter min number: ");
	 int maxNum = GetInt("Enter max number: ");
	for (int i = 0; i < n; i++)
	{
		printf("%i ", rand_interval(minNum, maxNum));
	}
	printf("\n");
	return 0;
}
int GetInt(char *prompt)
{
	printf(prompt);
	int n;
	scanf("%i", &n);
	return n;
}
 int rand_interval( int min,  int max)
{
	int r;
	const  int range = 1 + max - min;
	const  int buckets = RAND_MAX / range;
	const  int limit = buckets * range;

	do
	{
		r = rand();
	} while (r >= limit);

	return min + (r / buckets);
}