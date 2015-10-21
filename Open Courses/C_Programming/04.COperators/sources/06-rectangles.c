/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		6. Rectangles
*				Write an expression that calculates rectangle's perimeter and area by given width and height
*/

#include <stdio.h>;

int main(void) {

    double width;
    double height;

    printf("Enter width: ");
    scanf("%lf", &width);
    printf("Enter height: ");
    scanf("%lf", &height);

    double area = width * height;
    double perimeter = 2 * width + 2 * height; 

    printf("Area: %.3lf\n", area);
    printf("Perimeter %.3lf\n", perimeter);

    return 0;
}