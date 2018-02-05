/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     3. Sorted Array of Numbers
 * Description: Write a program to read an array of numbers from the console,
 *              sort them and print them back on the console. Use a sorting algorithm
*               of your choosing. The numbers should be entered one at a line. On the
 *              first input line you will be given the count of the numbers.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        26.10.2015
 * 
 */
// NOTE: Decided to implement insertion sort because it was one of the easiest to do
// the bad thing is that its Average and Worst case running times are O(n^2)
#include <stdio.h>
#include <limits.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>

//Prototypes
char *GetString(void);
int GetInt(void);
void insertSort(int *a, int lower, int upper) ;

int main(void) {

    printf("Enter the count of numbers to sort: ");
    int numCount = GetInt();
    int numbers[numCount];
    for (int i = 0; i < numCount; ++i) {
        printf("Enter number #%i: ",i);
        numbers[i] = GetInt();
    }
    insertSort(numbers,0,numCount-1);
    printf("Sorted: \n");
    for (int i = 0; i < numCount; ++i) {
        printf("%i ", numbers[i]);
    }
    printf("\n");
    return 0;

}

int GetInt(void) {

    while (true) {

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
    if (n == 0 && c == EOF) return NULL;

    char *minimal = (char *) malloc((n + 1) * sizeof(char));
    strncpy(minimal, buffer, n);
    free(buffer);
    minimal[n] = '\0';
    return minimal;
}

void insertSort(int *a, int lower, int upper) {
    int t;
    int i,j;
    for (i = lower + 1; i <= upper; i++) {
        t = a[i];

        for (j = i - 1; j >= lower && a[j] > t; j--)
            a[j + 1] = a[j];

        /* insert */
        a[j + 1] = t;
    }
}
