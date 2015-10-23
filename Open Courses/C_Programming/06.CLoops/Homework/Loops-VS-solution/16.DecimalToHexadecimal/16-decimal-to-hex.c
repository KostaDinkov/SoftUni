/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		16. Decimal to Hexadecimal
*				Using loops write a program that converts an integer number to its
*				hexadecimal representation. The input is entered as long. The output should be a
*				variable of type string. Do not use the built-in .NET functionality.
*
* Date:			23-10-2015
*/

//Note: I'm not using any .NET functionality ;)
//But anyway, the homework problem specifications are copied directly form the ones for C# basics.
//They didn't even edit the text a bit, so that at least the ".NET functionality" is erased.
#include <stdio.h>

int main(void)
{
	long long decNum;
	printf("Enter a decimal number: ");
	scanf("%lli", &decNum);
	printf("%llx\n", decNum);
}