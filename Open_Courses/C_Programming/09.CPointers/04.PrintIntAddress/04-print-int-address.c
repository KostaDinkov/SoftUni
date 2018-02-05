/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     C Pointers
 * Problem:     4. Print integer Address
 * Description: Write a function which takes as input an integer and
 *              prints the address of it in the memory.
 *              Try printing the address of the integer in the function
 *              and in the main function. What is the difference and why?
 * IDE:         Clion on Windows 10 / mingw
 * Date:        02.11.2015
 * 
 */
#include <stdio.h>

void PrintIntAddress(int number);
 
int main(void){

    int number = 5;
    printf("The number's address in the main function: %x\n",&number);
    PrintIntAddress(number);

    printf("In the C programming languages, integer data types are passed by value,\n"
                   "meaning that when a function is called with an int argument,\n"
                   "the value of this argument is being copied in a new address in the stack.\n"
                   "Changes made to this variable  will not be caried 'outsitde' the function's scope\n"
                   "leaving the original variable intackt\n");
    return 0;

}
void PrintIntAddress(int number){

    printf("The number's address in the PrintIntFunction: %x\n",&number);
}