/*
* SoftUni
* Course:		C Programming
* Lecture:		Functions
* Problem:		6. First Larger Than Neighbours
*				Write a method that returns the index of the first element in array 
*				that is larger than its neighbours, or -1 if there's no such element. Declare a function 
*				prototype before defining the function
*
* Date:			24-10-2015
*/
//NOTE: Assuming that the first and the last elements are not solutions because they both have only 1 neighbor

#include <stdio.h>

// Prototype
int FirstLarger(int arr[], int arrLen);

int main(void) 
{
	int sequenceOne[] = { 1, 3, 4, 5, 1, 0, 5 };
	int sequenceTwo[] = { 1, 2, 3, 4, 5, 6, 6 };
	int sequenceThree[] = { 1, 1, 1 };
	int sOneLen = sizeof(sequenceOne) / sizeof(int);
	int sTwoLen = sizeof(sequenceTwo) / sizeof(int);
	int sThreeLen = sizeof(sequenceThree) / sizeof(int);
	printf("%i\n", FirstLarger(sequenceOne, sOneLen));
	printf("%i\n", FirstLarger(sequenceTwo, sTwoLen));
	printf("%i\n", FirstLarger(sequenceThree, sThreeLen));

	return 0;
}
int FirstLarger(int arr[], int arrLen)
{
	for (int i = 1; i < arrLen -1; i++)
	{
		if (arr[i]>arr[i-1] && arr[i]> arr[i+1])
		{
			return i;
		}
	}
	return -1;
}