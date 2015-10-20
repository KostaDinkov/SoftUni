/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types	
* Problem:		7. Exchange Variable Values
*				Declare two integer variables a and b and assign them with 
*				5 and 10 and after that exchange their values by using some programming logic. 
*				Print the variable values before and after the exchange.
*/

#include <stdio.h>;

int main(void) {

	int a = 5;
	int b = 10;
	printf("Before:\n a = %d\n b = %d\n", a, b);
	int tmp = a;
	a = b;
	b = tmp;
	printf("After:\n a = %d\n b = %d\n", a, b);
	return 0;
}