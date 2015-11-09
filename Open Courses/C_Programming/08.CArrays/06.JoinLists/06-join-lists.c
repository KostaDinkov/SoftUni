/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     6.Join Arrays
 * Description: Write a program that takes as input two arrays of integers and
 *              joins them. The result should hold all numbers from the first array,
 *              and all numbers from the second array, without repeating numbers,
 *              and arranged in increasing order. On the first input line, you are
 *              given the count of the elements of the first array. On the next line
 *              you are given the length of the second array.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        29.10.2015
 * 
 */
#include <stdio.h>
#include <stdlib.h>
#include <limits.h>
#include <string.h>

// Creating a data structure for easier manipulation of adding
// and new elements and keeping track of its size
#define VECTOR_INITIAL_CAPACITY 10
struct Vector{
    int size;      // slots used so far
    int capacity;  // total available slots
    int *data;     // array of integers we're storing
} ;

int GetInt(void) ;
char *GetString(void) ;
void VectorInit(struct Vector *vector) ;
void VectorDoubleCapacityIfFull(struct Vector *vector) ;
void VectorAppendIfNotIn(struct Vector *vector, int value);

int cmpfunc (const void * a, const void * b);

int main(void){

    int firstArrLen = GetInt();
    int secArrLen = GetInt();
    struct Vector result;
    VectorInit(&result);

    // Adding the new inputs only if they don't exist yet in the vector
    for (int i = 0; i < firstArrLen + secArrLen; ++i) {
        int input = GetInt();
        VectorAppendIfNotIn(&result,input);
    }

    //sorting the data
    qsort(result.data, result.size,sizeof(int),cmpfunc);

    //printing the result
    for (int i = 0; i < result.size; ++i) {
        printf("%i ", result.data[i]);
    }
    printf("\n");
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

void VectorInit(struct Vector *vector) {
    // initialize size and capacity
    vector->size = 0;
    vector->capacity = VECTOR_INITIAL_CAPACITY;

    // allocate memory for vector->data
    vector->data = malloc(sizeof(int) * vector->capacity);
}

void VectorAppend(struct Vector *vector, int value) {
    // make sure there's room to expand into
    VectorDoubleCapacityIfFull(vector);

    // append the value and increment vector->size
    vector->data[vector->size++] = value;
}

void VectorAppendIfNotIn(struct Vector *vector, int value){

    for (int i = 0; i < vector->size; ++i) {
        if (vector->data[i]==value){
            return;
        }
    }
    VectorAppend(vector,value);
}

void VectorDoubleCapacityIfFull(struct Vector *vector) {
    if (vector->size >= vector->capacity) {
        // double vector->capacity and resize the allocated memory accordingly
        vector->capacity *= 2;
        vector->data = realloc(vector->data, sizeof(int) * vector->capacity);
    }
}

void VectorFree(struct Vector *vector) {
    free(vector->data);
}

int cmpfunc (const void * a, const void * b)
{
    return ( *(int*)a - *(int*)b );
}