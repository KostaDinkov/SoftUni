#ifndef _UTILS_H
#define _UTILS_H

#include <float.h>
#include <limits.h>
#include <stdbool.h>
#include <stdlib.h>

/**
* Our own data type for string variables.
*/
typedef char* string;

/**
* Reads a line of text from standard input and returns the equivalent
* char; if text does not represent a char, user is prompted to retry.
* Leading and trailing whitespace is ignored.  If line can't be read,
* returns CHAR_MAX.
*/
char GetChar(void);

/**
* Reads a line of text from standard input and returns the equivalent
* double as precisely as possible; if text does not represent a
* double, user is prompted to retry.  Leading and trailing whitespace
* is ignored.  For simplicity, overflow and underflow are not detected.
* If line can't be read, returns DBL_MAX.
*/
double GetDouble(void);

/**
* Reads a line of text from standard input and returns it as an
* int in the range of [-2^31 + 1, 2^31 - 2], if possible; if text
* does not represent such an int, user is prompted to retry.  Leading
* and trailing whitespace is ignored.  For simplicity, overflow is not
* detected.  If line can't be read, returns INT_MAX.
*/
int GetInt(void);

/**
* Reads a line of text from standard input and returns an equivalent
* long long in the range [-2^63 + 1, 2^63 - 2], if possible; if text
* does not represent such a long long, user is prompted to retry.
* Leading and trailing whitespace is ignored.  For simplicity, overflow
* is not detected.  If line can't be read, returns LLONG_MAX.
*/
long long GetLongLong(void);

/**
* Reads a line of text from standard input and returns it as a
* string (char *), sans trailing newline character.  (Ergo, if
* user inputs only "\n", returns "" not NULL.)  Returns NULL
* upon error or no input whatsoever (i.e., just EOF).  Leading
* and trailing whitespace is not ignored.  Stores string on heap
* (via malloc); memory must be freed by caller to avoid leak.
*/
string GetString(void);

/**
* Checks if array of ints contains certain number and returns 1 if true or 0 if false
*/
int ArrContains(int arr[], int arrLen, int number);

/**
* Sets all int array elements to 0
*/
void ArrClear(int arr[], int arrLen);

/**
* Returns the average of the sum of elements in an array of integers
*/
double ArrAvg(int arr[], int arrLen);

/**
* Returns the sum of the elements in an array of integers
*/
int ArrSum(int arr[], int arrLen);

/**
* Returns the maximum element in an array of integers
*/
int ArrMax(int arr[], int arrLen);

/**
* Returns the minimum element in an array of integers
*/
int ArrMin(int arr[], int arrLen);
/**
* Prints the elements in an array of ints 
*/
void ArrPrint(int arr[], int arrLen);

#endif
