/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		12. Prime Number Check
*				Write an expression that checks if given positive
*               integer number n (n ? 100) is prime (i.e. it is divisible without
*               remainder only to itself and 1). Print true or false:
*/

#include <stdio.h>
#include <math.h>

//prototypes
int isPrime(int num);

int main(void) {
    int input;
    printf("Enter a positive integer up to 100: ");
    scanf("%i", &input);
    printf("%s\n", isPrime(input) ? "true" : "false");

    return 0;
}
int isPrime(int num)
{
    if (num <= 1) return 0;
    if (num % 2 == 0) return 0;
    for (int i = 3; i <= floor(sqrt(num)); i += 2)
    {
        if (num % i == 0)
            return 0;
    }
    return 1;
}