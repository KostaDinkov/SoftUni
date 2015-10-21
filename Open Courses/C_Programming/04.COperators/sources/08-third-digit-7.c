/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		8. Third Digit is 7
*				Write an expression that checks for given integer if its third digit from fight to left is 7. 
*               Print true of false
*/


#include <stdio.h>;

int main(void) {

    int number;
    printf("Enter a number:  ");
    scanf("%i", &number);

    printf("%s\n", (number / 100) % 10 == 7 ? "true" : "false");
        
	return 0;
}