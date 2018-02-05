/*
* SoftUni
* Course:		C Programming
* Lecture:		Formatted Input / Output
* Problem:		4. Formatting Numbers
*				Write a program that reads 3 numbers: an integer a (0 ? a ? 500), 
*               a floating-point b and a floating-point c and prints them in 4 virtual columns on 
*               the console. Each column should have a width of 10 characters. The number a should 
*               be printed in hexadecimal, left aligned; then the number a should be printed in binary 
*               form, padded with zeroes, then the number b should be printed with 2 digits after the 
*               decimal point, right aligned; the number c should be printed with 3 digits after the 
*               decimal point, left aligned.
*/

#include <stdio.h>;
//prototypes

const char *byte_to_binary(unsigned char x);
#define TABLE_FORMAT "|%-10x|%10s|%#10.2lf|%#-10.3lf|\n"

int main(void) {

    int a;
    double b;
    double c;

    printf("Enter number a: ");
    scanf("%d", &a);
    printf("Enter number b: ");
    scanf("%lf", &b);
    printf("Enter number c: ");
    scanf("%lf", &c);
 
    printf(TABLE_FORMAT, a, byte_to_binary(a), b, b);
	return 0;
}
const char *byte_to_binary(int x)
{
    static char b[17];
    b[0] = '\0';

    int z;
    for (z = 512; z > 0; z >>= 1)
    {
        strcat(b, ((x & z) == z) ? "1" : "0");
    }

    return b;
}