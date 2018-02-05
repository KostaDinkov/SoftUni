/*
* SoftUni
* Course:		C Programming
* Lecture:		Condidional Statements
* Problem:		01. Exchange if Greater
*				Write an if-statement that takes two integer variables a and b 
*				and exchanges their values if the first one is greater than the second one. 
*				As a result print the values a and b, separated by a space.
*/

#include <stdio.h>;

int main(void) {
	int a;
	int b;
	printf("Enter first integer: ");
	scanf("%i", &a);
	printf("Enter second integer: ");
	scanf("%i", &b);

	if (a>b)
	{
		int tmp = a;
		a = b;
		b = tmp;
	}
	printf("%i %i\n", a, b);
	return 0;
}