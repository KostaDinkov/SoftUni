/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		4. Multiplication Sign
*				Write a program that shows the sign (+, - or 0) of the product of three real numbers, 
*				without calculating it. Use a sequence of if operators.
*/

#include <stdio.h>;

int main(void) {
	
	double a;
	double b;
	double c;
	printf("Enter first number: ");
	scanf("%lf", &a);
	printf("Enter second number: ");
	scanf("%lf", &b);
	printf("Enter third number: ");
	scanf("%lf", &c);
	char result = '0';
		
	if (a!=0 && b != 0 && c !=0 )
	{
		
		// I will get the count of negative numbers
		// and if that count is odd then the result will be negative
		int negativeCount =0;
		if (a < 0) negativeCount++;
		if (b < 0) negativeCount++;
		if (c < 0) negativeCount++;

		if (negativeCount%2==0)
		{
			result = '+';
		}
		else
		{
			result = '-';
		}
	}
	printf("%c\n", result);

	return 0;
}