/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		11. Point in Circle
*				Write an expression that checks if given point(x,y) is inside a circle K({0,0},2)
*/

#include <stdio.h>;

int main(void) {
    int radius = 2;
    double x;
    double y;
    
    printf("Enter x coordinate of the point: ");
    scanf("%lf", &x);
    printf("Enter y coordinate of the point: ");
    scanf("%lf", &y);
    
    double distanceSquared = x*x + y*y;
    printf("%s\n", distanceSquared > radius*radius ? "No" : "Yes");
	return 0;
}