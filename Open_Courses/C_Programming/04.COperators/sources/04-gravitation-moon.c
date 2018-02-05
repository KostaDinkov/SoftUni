/*
* SoftUni
* Course:		C Programming
* Lecture:		C Operators
* Problem:		4. Gravitation on the Moon
*				The gravitational field of the Moon is approximately 
*               17% of that on the Earth. Write a program that calculates
*               the weight of a man on the moon by a given weight on the Earth
*/

#include <stdio.h>;

int main(void) {

    printf("Enter your weight: ");
    double weight;
    scanf("%lf", &weight);

    double moonWeight = weight * 0.83;
    printf("Weight on the moon: %.3lf\n", moonWeight);

	return 0;
}