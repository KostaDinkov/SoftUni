/*
* SoftUni
* Course:		C Programming
* Lecture:		Formated Input / Output
* Problem:		Circle Perimeter and Area
*				Write a program that reads the radius r of a circle and
*               prints its perimeter and area formatted with 2 digits after the decimal point.
*/

#include <stdio.h>;

#define PI 3.1415926
int main(void) {

    double radius;

    printf("Enter circle radius: ");
    scanf("%lf", &radius);
    double area = PI * radius * radius;
    printf("Circle Area = %.2lf\n", area);

    double perimeter = 2 * PI * radius;
    printf("Circle Perimeter = %.2lf\n", perimeter);
    return 0;
}