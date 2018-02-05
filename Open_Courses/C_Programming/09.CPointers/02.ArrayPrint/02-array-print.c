/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     C Pointers
 * Problem:     2. Array Print
 * Description: Declare an array of integers and print it on
 *              the console.Do not use the indexer operator [].
 * IDE:         Clion on Windows 10 / mingw
 * Date:        02.11.2015
 * 
 */
#include <stdio.h>
#include <stdlib.h>

int main(void){
    int arrSize = 5;
    //allocate a memory for arrSize integers and assign pointer to the address of the first int
    int *arr = (int*)malloc(arrSize * sizeof(int));
    //create additional pointer to be used for arithmetic

    //initialize the integers with numbers from 1 to arrSize
    for (int i = 0; i < arrSize; ++i) {
        *(arr + i) = i+1;
    }

    //print the integers
    for (int i = 0; i < arrSize; ++i) {
        printf("%i, ",*(arr+i));
    }
    printf("\n");

    free(arr);
    return 0;
    
}