/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		14.Decimal to Binary
*				Using loops write a program that converts an integer number to its
*				binary representation. The input is entered as long. The output should be a variable
*				of type string.
*
* Date:			23-10-2015
*/

#include <stdio.h>

int main()
{
	int d[33];
	int decimal, i = 0;
	printf("Enter the decimal number you want to convert to binary: ");
	scanf("%d", &decimal);
	while (decimal > 0)
	{
		d[i] = decimal % 2;
		i++;
		decimal = decimal / 2;
	}
	printf("The binary version of the number you input is = ", decimal);
	for (int j = i - 1;j >= 0;j--)
	{
		printf("%d", d[j]);
	}
	printf("\n");
}