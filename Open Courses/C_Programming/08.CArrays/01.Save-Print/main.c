/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     1. Save and Print Numbers in range
 * Description: Write a program that reads n numbers from the console and saves them in an array.
 *              The program should then print the elements of
 *              the array on the console.
 * IDE:         Clion on Windows 10
 * Date:        26.10.2015
 * 
 */
#include <stdio.h>

int main(void) {
    int nCount;
    printf("Enter the count of numbers to input: ");
    scanf("%i", &nCount);

    int numbers[nCount];
    for (int i = 0; i < nCount; ++i) {
        printf("Enter number#%i:", i );
        scanf("%i", &numbers[i]);
    }

    for (int i = 0; i < nCount; ++i) {
        printf("%i ", numbers[i]);
    }
    printf("\n");
    return 0;

}