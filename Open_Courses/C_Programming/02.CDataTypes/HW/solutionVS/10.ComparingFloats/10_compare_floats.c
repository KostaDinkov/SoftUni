/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		10. Comparing Floats
*				Write a program that safely compares floating-point numbers 
*				(double) with precision eps = 0.000001. Note that we cannot directly compare 
*				two floating-point numbers a and b by a==b because of the nature of the 
*				floating-point arithmetic. Therefore, we assume two numbers are equal if 
*				they are more closely to each other than a fixed constant eps.
*/

#include <stdio.h>
#include <math.h>

int main(void) 
{
	double firstNum;
	double secondNum;
	double eps = 0.000001;
	
	printf("Enter first number: ");
	scanf("%lf", &firstNum);
	printf("Enter second number: ");
	scanf("%lf", &secondNum);

	int areEqual = CompareDoubles(firstNum, secondNum, eps);
	printf("Are numbers equal : %s\n", areEqual == 1 ? "true":"false");

	return 0;
}

int CompareDoubles(double a, double b, double eps) 
{
	double diff = fabs(a - b) ;
	// printf("diff = %.10lf\n", diff); // this line is for debugging only
	if (diff>(eps))
	{
		return 0;
	}
	return 1;
}