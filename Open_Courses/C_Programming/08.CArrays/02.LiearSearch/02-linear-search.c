/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     Arrays
 * Problem:     2. Linear Search
 * Description: Given an array of n integers, write a linear search function that determines
 *              whether a given element exists in the array. On the first line you will receive
 *              the number n. On the second line, there will be n numbers, space-separated.
 *              On the third line, the search number will be given.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        26.10.2015
 * 
 */
#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>
#include <stdbool.h>

void IntsFromString(char *string, int numbers[]);
bool isInArray(int arr[], int arrLen, int term);

int main(void){

    int numCount;
    printf("Enter the count of numbers:");
    scanf("%i",&numCount);
    char c;
    while((c = getchar()) != '\n' && c != EOF)
        /* discard */ ;
    int numbers [numCount];

    printf("Enter the numbers: \n");
    char  input[numCount*10];
    fgets(input, numCount*10,stdin);
    IntsFromString(input,numbers);
    int searchTerm;
    printf("Enter the number to find: ");
    scanf("%i",&searchTerm);
    bool isNumberInArray = isInArray(numbers,numCount, searchTerm);
    printf("%s\n",isNumberInArray?"yes":"no");

    return 0;
    
}

bool isInArray(int arr[], int arrLen, int term)
{
    for (int i = 0; i < arrLen; ++i) {
        if(arr[i] == term){
            return true;
        }
    }
    return false;
}

void IntsFromString(char *string, int numbers[])
{
    int index = 0;
    while (1) {
        char *tail;
        int next;

        /* Skip whitespace by hand, to detect the end.  */
        while (isspace (*string)) string++;
        if (*string == 0)
            break;

        /* There is more nonwhitespace,  */
        /* so it ought to be another number.  */
        errno = 0;
        /* Parse it.  */
        next = strtol (string, &tail, 10);
        /* Add it in, if not overflow.  */
        if (errno){
            printf ("Overflow\n");
        }

        else
        {
            numbers [index] = next;
            index++;
        }
        /* Advance past it.  */
        string = tail;
    }


}