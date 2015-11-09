/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Pointers
 * Problem:     1. Swap Numbers
 * Description: Implement a function which takes as input two numbers and swaps their values. The declaration of the function should be something like:
 * IDE:         Clion on Windows 10 / mingw
 * Date:        29.10.2015
 * 
 */
#include <stdio.h>

void swap(int *first, int *second);
int main(void){

    int a = 1;
    int b = 10;
    swap(&a,&b);
    printf("a = %i, b= %i", a , b);
    return 0;
    
}
void swap(int *first, int *second){

    int tmp = *first;
    *first = *second;
    *second = tmp;
}
