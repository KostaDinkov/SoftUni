/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     4.Categorize Numbers and Fing Min / Max /Average
 * Description: Write a program that reads N floating-point numbers from the console.
 *              Your task is to separate them in two sets, one containing only the round
 *              numbers (e.g. 1, 1.00, etc.) and the other containing the floating-point
 *              numbers with non-zero fraction. Print both arrays along with their minimum,
 *              maximum, sum and average (rounded to two decimal places). The numbers should
 *              be entered one at a line. On the first input line you will be given the count of
 *              the numbers.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        27.10.2015
 * 
 */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <limits.h>
#include <float.h>
#include <stdbool.h>
#include <math.h>

//Prototypes
char * GetString(void);
int GetInt(void);
double GetDouble(void);
void PrintArrayInfo(double *arr, int arrLen);

void MinMaxAvg(double arr[], int arrLen, double *min, double *max, double *sum, double *avg);

int main(void){

    printf("Enter the count of numbers to enter:");
    int n = GetInt();
    double *ints = (double*)malloc(sizeof(double)*n);
    int intsCount =0;
    double *floats = (double*)malloc(sizeof(double)*n);
    int floatsCount=0;
    for (int i = 0; i < n; ++i) {
        printf("Enter number #%i:",i);
        double input = GetDouble();
        double tmp;
        if(modf(input, &tmp)==0){
            ints[intsCount] = input;
            intsCount++;
        }
        else{
            floats[floatsCount]=input;
            floatsCount++;
        }
    }
    double min, max, sum, avg;

    //print the float results
    MinMaxAvg(floats,floatsCount,&min,&max,&sum,&avg);
    PrintArrayInfo(floats,floatsCount);
    printf("-> min: %.2f, max: %.2f, sum: %.2f, average: %.2f\n",min, max,sum, avg);

    //print the double results
    MinMaxAvg(ints,intsCount,&min,&max,&sum,&avg);
    PrintArrayInfo(floats,floatsCount);
    printf("-> min: %.2f, max: %.2f, sum: %.2f, average: %.2f\n",min, max,sum, avg);

    //free memory
    free(ints);
    free(floats);
    return 0;

}

void PrintArrayInfo(double *arr, int arrLen) {
    printf("[");
    for (int i = 0; i < arrLen; ++i) {
        printf("%.2f, ", arr[i]);
    }
    printf("]");
}

double GetDouble(void)
{
    while (true)
    {
        char * line = GetString();
        if (line == NULL)
        {
            return DBL_MAX;
        }

        double d; char c;
        if (sscanf(line, " %lf %c", &d, &c) == 1)
        {
            free(line);
            return d;
        }
        else
        {
            free(line);
            printf("Retry: ");
        }
    }
}
int GetInt(void)
{
    while (true)
    {
        char * line = GetString();
        if (line == NULL)
        {
            return INT_MAX;
        }

        int n; char c;
        if (sscanf(line, " %d %c", &n, &c) == 1)
        {
            free(line);
            return n;
        }
        else
        {
            free(line);
            printf("Retry: ");
        }
    }
}
char * GetString(void)
{
    char * buffer = NULL;

    unsigned int capacity = 0;

    unsigned int n = 0;

    int c;

    while ((c = fgetc(stdin)) != '\n' && c != EOF)
    {
        if (n + 1 > capacity)
        {
            if (capacity == 0)
            {
                capacity = 32;
            }
            else if (capacity <= (UINT_MAX / 2))
            {
                capacity *= 2;
            }
            else
            {
                free(buffer);
                return NULL;
            }

            char * temp = (char *) realloc(buffer, capacity * sizeof(char));
            if (temp == NULL)
            {
                free(buffer);
                return NULL;
            }
            buffer = temp;
        }

        buffer[n++] = c;
    }

    if (n == 0 && c == EOF)
    {
        return NULL;
    }

    char * minimal = (char *) malloc((n + 1) * sizeof(char));
    strncpy(minimal, buffer, n);
    free(buffer);

    minimal[n] = '\0';

    return minimal;
}
void MinMaxAvg(double arr[], int arrLen, double *min, double *max, double *sum, double *avg){

    *min = DBL_MAX;
    *max = DBL_MIN;
    *sum = 0;
    for (int i = 0; i < arrLen; ++i) {

        if(arr[i]< *min) *min = arr[i];
        if(arr[i]> *max) *max = arr[i];
        *sum += arr[i];
    }
    *avg = round((*sum / arrLen)*100)/100;

}
