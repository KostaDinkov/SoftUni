/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		6. Biggest of Five
*				Write a program that finds the biggest of five numbers by using only five if statements.
*/

#include <stdio.h>;

#include <float.h>
#define ARRSIZE 5
int main(void) 
{
	//getting the numbers
	double numbers[ARRSIZE];
	double max = DBL_MIN;
	for (int i = 0;i < ARRSIZE;i++)
	{
		printf("Enter number #%i: ", i + 1);
		scanf("%lf", &numbers[i]);
	}
	//this is crazy ...
	if (numbers[0] > max) max = numbers[0];
	if (numbers[1] > max) max = numbers[1];
	if (numbers[2] > max) max = numbers[2];
	if (numbers[3] > max) max = numbers[3];
	if (numbers[4] > max) max = numbers[4];
	
	printf("%lf\n", max);
return 0;
}