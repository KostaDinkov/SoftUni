/*
* SoftUni
* Course:		C Programming
* Lecture:		Bit Manipulation
* Problem:		6 and 7. Bit Exchange
*				Write a program that exchanges bits {p, p+1, …, p+k-1} 
*				with bits {q, q+1, …, q+k-1} of a given 32-bit unsigned integer. 
*				The first and the second sequence of bits may not overlap.
*
* IDE:			Visual Studio 2015 / MSVC
* Date:			09-11-2015
*/

#include <stdio.h>
#include <math.h>

int main(void) 
{
	unsigned int input, p, q, k;
	printf("Integer: ");
	scanf("%u", &input);
	printf("First Index: ");
	scanf("%u", &p);
	printf("Second Index: ");
	scanf("%u", &q);
	printf("Sequence length: ");
	scanf("%u", &k);
	//validate input
	if (p + k >= 32 || q + k >= 32)
	{
		printf("out of range!\n");
		return;
	}
	if (abs(q - p) < k) {
		printf("overlapping!\n");
		return;
	}

	unsigned int mask = (unsigned int)(pow(2, k) - 1); // set the size of the mask
	
	unsigned int firstSequence = input & (mask << p); //extract sequence at position p
	firstSequence >>= p;  //shift the extracted sequence to index 0
	
	unsigned int secondSequence = input & (mask << q); //extract sequence at position q
	secondSequence >>= q; //shift the extracted sequence to index 0

	//clear (set to 0) the extracted regions in the original input
	input &= ~(mask << p);
	input &= ~(mask << q);

	//copy the extracted sequences to their new destinations
	input |= firstSequence << q;
	input |= secondSequence << p;
	
	printf("%u\n", input);

	return 0;
}