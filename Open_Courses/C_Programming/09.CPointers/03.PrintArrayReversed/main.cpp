/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     C Pointers
 * Problem:     3. Print Array Reversed
 * Description: you are given a sample array as input and your task is to print
 *              the array in reversed order using pointer arithmetic
 *              instead of indexing
 * IDE:         Clion on Windows 10 / mingw
 * Date:        02.11.2015
 * 
 */
#include <stdio.h>

//Prototypes
void Swap(int *a, int *b);
void ReverseArray(int arr[], int arrSize);

int main(void){
    int arrSize = 5;
    int arr[] = {1, 2, 3, 4, 5};
    ReverseArray(arr,arrSize);

    //print the  reversed array
    for (int i = 0; i <arrSize ; ++i) {
        printf("%i, ",*(arr+i));
    }
    printf("\n");
    return 0;
    
}
void ReverseArray(int arr[], int arrSize){

    int leftSide =0;
    int rightSide = arrSize -1;
    while(leftSide != rightSide){
        Swap(arr + leftSide, arr + rightSide);
        leftSide++;
        rightSide--;
    }
}
void Swap(int *a, int *b){
    int tmp = *a;
    *a = *b;
    *b = tmp;
}