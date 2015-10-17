/* Problem 7
** Create a console application that calculates and 
** prints the square root of the number 12345.
*/

#include <stdio.h>
#include <math.h>

int main(void)
{
	double n;
	printf("Enter an number : ");
	scanf("%lf", &n);
	double result = sqrt(n);
	printf("The square root of is %.2lf :", n);
	
	return(0);
}