/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		2.Extract Bit #3
*				Using bitwise operators, write an expression for finding 
*				the value of the bit #3 of a given unsigned integer. The bits are counted 
*				from right to left, starting from bit #0. The result of the expression 
*				should be either 1 or 0.
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			09-11-2015
*/

#include <stdio.h>

int main(void) 
{
	unsigned int input;
	scanf("%u", &input);
	int position = 3;
	
	unsigned int mask = 1 << position;
	mask = input & mask;
	mask = mask >> position;
	
	printf("%u\n", mask);
		
	return 0;
}