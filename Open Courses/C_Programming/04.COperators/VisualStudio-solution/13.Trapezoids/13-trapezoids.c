/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		13. Trapezoids
*				Write an expression that calculates trapezoid's area by given sides a and b and height h.
*/


#include <stdio.h>

int main(void) {

    double a;
    double b;
    double h;

    printf("Enter side a: ");
    scanf("%lf", &a);
    printf("Enter side b: ");
    scanf("%lf", &b);
    printf("Enter height: ");
    scanf("%lf", &h);

    double area = ((a + b)/2) *h ;
    printf("Area: %.3lf\n", area);
    
    return 0;
}