/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     5.Longest Increasing Sequence
 * Description: Write a program to find all increasing sequences inside an array of integers.
 *              The numbers should be entered one at a line. On the first input line you will
 *              be given the count of the numbers. Print the sequences in the order of their
 *              appearance in the input array, each at a single line. Separate the sequence
 *              elements by a space. Find also the longest increasing sequence and print it
 *              at the last line. If several sequences have the same longest length, print
 *              the left-most of them.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        28.10.2015
 * 
 */
#include <stdio.h>
#include <limits.h>
#include <stdlib.h>
#include <string.h>


int GetInt(void);

char *GetString(void);

int main(void) {

    // Get the input
    printf("Enter the count of elements in the int array: ");
    int arrLen = GetInt();
    int *arr = (int *) malloc(arrLen * sizeof(int));
    for (int i = 0; i < arrLen; i++) {
        printf("Enter element #%i: ",i+1);
        arr[i] = GetInt();
    }

    int maxLen = 1;
    int maxLenIndex = 0;
    int currLen = 1;
    int start = 0;
    int end = 0;

    while (1) {
        if (end == arrLen - 1) {
            if (currLen > maxLen) {
                maxLen = currLen;
                maxLenIndex = start;
            }
            for (int i = start; i <= end; ++i) {
                printf("%i ", arr[i]);
            }

            printf("\n");
            break;
        }
        if (arr[end] < arr[end + 1]) {
            currLen++;
        }
        else {
            for (int i = start; i <= end; ++i) {
                printf("%i ", arr[i]);
            }
            printf("\n");
            if (currLen > maxLen) {
                maxLen = currLen;
                maxLenIndex = start;
            }
            start = end + 1;
            currLen = 1;
        }
        end++;
    }
    printf("Longest: ");
    for (int i = maxLenIndex; i <= maxLenIndex + maxLen - 1; ++i) {
        printf("%i ", arr[i]);
    }
    printf("\n");
    getchar();
    return 0;

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