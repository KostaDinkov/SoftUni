/*
 * SoftUni
 * Course:      C Programming
 * Lecture:     C Pointers
 * Problem:     5. Create New integer
 * Description: Write a function that declares and initializes and
 *              integer on the stack, then returning it.
 *              Try creating the function with two different declarations:
 *              int new_integer()
 *              int* new_integer_ptr()
 *              What is the difference between the two declarations?
 *              Why is the second declaration not safe to use?
 *              Given an example.
 * IDE:         Clion on Windows 10 / mingw
 * Date:        
 * 
 */
#include <stdio.h>

int* new_integer_ptr();

int new_integer();

int main(void){

    int a = *new_integer_ptr(); // now a should be 10
    int b = new_integer(); // and b is 5

    printf("At address : %x : %i\n",&a, a);
    printf("At address : %x : %i\n",&b, b);

    printf("When the first function completes, it frees the mamory\n"
                   "on the stack that it was occupying, but the variable\n"
                   "that was created in this function remains in the same, freed memory\n"
                   "When a new function is called, it might be allocated at the same memory as\n"
                   "the previous function and may overwrite the value of the first variable\n"
                   "and when we try to access its location by using the pointer, the result may\n"
                   "be completely different");
    return 0;
    
}
int new_integer(){
    int number  = 5;
    return number;
}
int* new_integer_ptr(){
    int number = 10;
    return &number; //here my IDE yells at me that "Value escapes local scope"
}