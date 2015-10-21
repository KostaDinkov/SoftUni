/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		14. Point Inside a Circle and Outside of a Rectangle
*				Write an expression that checks for given point (x, y) if it
*               is within the circle K({1, 1}, 1.5) and out of the
*               rectangle R(top=1, left=-1, width=6, height=2). Print yes or no:
*/

#include <stdio.h>;
//prototypes
int isInsideCircle(double x, double y, double circleX, double circleY, double radius);
int isInsideRectangle(double x, double y, double rectX, double rectY, double rectHeight, double rectWidth);

int main(void) {

    double radius = 1.5;
    double circleX = 1;
    double circleY = 1;
    double rectX = -1; // the x coordinate of the top left corner of the rectangle
    double rectY = 1;  // the y coordinate of the top left corner of the rectangle
    double rectWidth = 6;
    double rectHeight = 2;

    double x;
    double y;
    printf("Enter x coordinate of the point: ");
    scanf("%lf", &x);
    printf("Enter y coordinate of the point: ");
    scanf("%lf", &y);

    if (isInsideCircle(x, y, circleX, circleY, radius) &&
        !isInsideRectangle(x, y, rectX, rectY, rectHeight, rectWidth))
    {
        printf("%s\n", "yes" );
    }
    else
    {
        printf("%s\n", "no");
    }

    return 0;
}
int isInsideCircle(double x, double y, double circleX, double circleY, double radius) {
    double distanceSquared = (x - circleX)*(x - circleX) + (y - circleY)*(y - circleY);
    return distanceSquared <= radius*radius;
}
int isInsideRectangle(double x, double y, double rectX, double rectY, double rectHeight, double rectWidth) {

    if (x < rectX + rectWidth && 
        x >= rectX && 
        y >= rectY - rectHeight && 
        y <= rectY)
    {
        return 1;
    }
    return 0;

}