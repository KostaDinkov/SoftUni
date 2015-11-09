/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     7. Reverse Array
 * Description: Write a program that reverses an array of numbers.
 *              The numbers should be entered one at a line. On the first input
 *              line you will be given the count of the numbers.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        29.10.2015
 * 
 */

#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <string.h>

int GetInt(void) ;
char *GetString(void) ;

void Reverse(int arr[], int arrLen);

int main(void){

    int numCount = GetInt();
    int *arr = (int*)malloc(numCount*sizeof(int));
    for (int i = 0; i < numCount; ++i) {
        arr[i] = GetInt();
    }
    Reverse(arr,numCount);
    for (int i = 0; i < numCount; ++i) {
        printf("%i ", arr[i]);
    }
    printf("\n");

    return 0;
}

void Reverse(int arr[], int arrLen) {
    int start = 0;
    int end = arrLen-1;
    while(start<end){
        int tmp = arr[start];
        arr[start] = arr[end];
        arr[end] = tmp;
        start++;
        end--;
    }
}

int GetInt(void) {
    while (1) {
        char *line = GetString();
        if (line == NULL) {
            return INT_MAX;
        }

        int n;
        char c;
        if (sscanf(line, " %d %c", &n, &c) == 1) {
            free(line);
            return n;
        }
        else {
            free(line);
            printf("Retry: ");
        }
    }
}

char *GetString(void) {
    char *buffer = NULL;

    unsigned int capacity = 0;

    unsigned int n = 0;

    int c;

    while ((c = fgetc(stdin)) != '\n' && c != EOF) {
        if (n + 1 > capacity) {
            if (capacity == 0) {
                capacity = 32;
            }
            else if (capacity <= (UINT_MAX / 2)) {
                capacity *= 2;
            }
            else {
                free(buffer);
                return NULL;
            }

            char *temp = (char *) realloc(buffer, capacity * sizeof(char));
            if (temp == NULL) {
                free(buffer);
                return NULL;
            }
            buffer = temp;
        }

        buffer[n++] = c;
    }

    if (n == 0 && c == EOF) {
        return NULL;
    }

    char *minimal = (char *) malloc((n + 1) * sizeof(char));
    strncpy(minimal, buffer, n);
    free(buffer);

    minimal[n] = '\0';

    return minimal;
}