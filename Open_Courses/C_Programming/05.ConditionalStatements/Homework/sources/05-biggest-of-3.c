/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		5. The Biggest of 3 Numbers
*				Write a program that finds the biggest of three numbers.
*/
#include <stdio.h>;
#include <float.h>
#define ARRSIZE 3
int main(void) {

	double numbers[ARRSIZE];
	double max = DBL_MIN;
	
	//getting the numbers and simultaneously comparing for the biggest so far 
	for (int i = 0;i < ARRSIZE;i++)
	{
		printf("Enter number #%i: ", i + 1);
		scanf("%lf", &numbers[i]);
		if (numbers[i]> max)
		{
			max = numbers[i];
		}
	}
	printf("%lf\n", max);
	
	return 0;
}