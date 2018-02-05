/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		8. Employee Data
*				A marketing company wants to keep record of its employees. 
*				Each record would have the following characteristics:
*					- First name
*					- Last name
*					- Age (0...100)
*					- Gender (m or f)
*					- Personal ID number (e.g. 8306112507)
*					- Unique employee number (27560000…27569999)
*				Declare the variables needed to keep the information for a single 
*				employee using appropriate primitive data types. Use descriptive names. Print the data at the console.
*/

#include <stdio.h>

int main(void) {

	char *firstName = "Minzuharcho";
	char *lastName = "Kokichkov";
	unsigned int age = 55;
	char gender = 'm';
	long long pid = 8306112507;
	unsigned long uen = 27569999;
	printf("First Name: %s\nLast Name: %s\nAge: %u\nGender: %c\nPID : %lld\nUEN: %lu\n", firstName, lastName, age, gender,pid,uen);
	return 0;
}