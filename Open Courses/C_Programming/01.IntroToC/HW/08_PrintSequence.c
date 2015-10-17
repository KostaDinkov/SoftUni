/* Problem 8
 * Write a program that prints the first 10 
 * members of the sequence: 2, -3, 4, -5, 6, -7, ...
 * Extra: 
 * Modify your program to read a number n from the console 
 * and then finds the first n members from the 
 * sequence, starting from 2.
*/

#include <stdio.h>


int main(void)
{
	int count;
        int n = 1;
        
	printf("Enter an number : ");
	scanf("%i", &count);
	
        for(int i = 2; i<count+2;i++){
            
            int result = i*n;
            printf("%i, ", result);
            n=-n;
        }
        printf("\n");
	
	return(0);
}

