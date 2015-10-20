/*
* SoftUni
* Course:		C Programming
* Lecture:		C Data Types
* Problem:		09. Bank Account Data
*				A bank account has a holder name (first name, middle name
*				and last name), available amount of money (balance),
*				bank name, IBAN and 3 credit card numbers associated with the account.
*				Declare the variables needed to keep the information for a single bank
*				account using the appropriate data types and descriptive names.
*/

#include <stdio.h>

int main(void) {
	char *firstName = "Minzuharcho";
	char *middleName = "Margaritkov";
	char *lastName = "Kokichkov";
	long double balance = 12345.12345678; //better to use external high precision decimal library
	char *bankName = "Evil Corp Bank";\
		char *iban = "BG80BNBG96611020345678";
	/* NOTE: At first I used unsigned long long for the credit card numbers,
	 * but after reading some info on the net decided to use string. After all we aren't going to
	 * do any mathematical operations with the number
	 */
	char *card1 = "5555555555554444"; //MasterCard
	char *card2 = "4012888888881881"; //Visa
	char *card3 = "378282246310005";  //American Express

	//using separate printf statements this time for better readability
	printf("First Name: %s\n", firstName);
	printf("Middle Name: %s\n", middleName);
	printf("Last Name: %s\n", lastName);
	printf("Balance: %Lf\n", balance);
	printf("Bank Name: %s\n", bankName);
	printf("IBAN: %s\n", iban);
	printf("Credit Card 1 = %s\n", card1);
	printf("Credit Card 2 = %s\n", card2);
	printf("Credit Card 3 = %s\n", card3);

	return 0;
}