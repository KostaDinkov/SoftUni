/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		5. Modify Bit At Given Position
*				We are given an integer number n, a bit value v (v=0 or 1) 
*				and a position p. Write a sequence of operators (a few
*				lines of C# code) that modifies n to hold the value v 
*				at the position p from the binary representation of n while
*				preserving all other bits in n.
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			09-11-2015
*/

#include <stdio.h>

int main(void) 
{
	int input, index, value;
	printf("Integer: ");
	scanf("%i", &input);
	printf("Index: ");
	scanf("%i", &index);
	printf("Value (0 or 1): ");
	scanf("%i", &value);

	if (value)	input |= 1 << index; //set
	else input &= ~(1 << index); //clear
	printf("Result: %i\n", input);
	
	return 0;
}