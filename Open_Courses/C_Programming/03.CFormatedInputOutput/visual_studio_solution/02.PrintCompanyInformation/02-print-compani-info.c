/*
* SoftUni
* Course:		C Programming
* Lecture:		Formatted Input / Output
* Problem:		Print Company Information
*				A company has name, address, phone number, fax number,
*               web site and manager. The manager has first name, last name, age and a
*               phone number. Write a program that reads the information about a company
*               and its manager and prints it back on the console.
*/

#include <stdio.h>;
//prototypes
static void getLine(char *prmpt, char *buff, size_t sz);

// hard coding the maximum length of the input string
#define INPUTSIZE 35

int main(void)
{
    //NOTE: since I have no idea how the info will be used, i decide to take everything as string
    char companyName[INPUTSIZE];
    char companyAddress[INPUTSIZE];
    char phoneNumber[INPUTSIZE];
    char faxNumber[INPUTSIZE];
    char webSite[INPUTSIZE];
    char mFirstName[INPUTSIZE];
    char mLastName[INPUTSIZE];
    char mAge[INPUTSIZE];
    char mPhone[INPUTSIZE];

    getLine("Company Name: ", companyName, INPUTSIZE);
    getLine("Company Address: ", companyAddress, INPUTSIZE);
    getLine("Phone Number: ", phoneNumber, INPUTSIZE);
    getLine("Fax Number: ", faxNumber, INPUTSIZE);
    getLine("Web Site: ", webSite, INPUTSIZE);
    getLine("Manager First Name: ", mFirstName, INPUTSIZE);
    getLine("Manager Last Name: ", mLastName, INPUTSIZE);
    getLine("Manager Age: ", mAge, INPUTSIZE);
    getLine("Manager Phone: ", mPhone, INPUTSIZE);

    printf("%s\n", companyName);
    printf("Address: %s\n", companyAddress);
    printf("Tel. %s\n", phoneNumber);
    printf("Fax: %s\n", faxNumber);
    printf("Web Site: %s\n", webSite);
    printf("Manager: %s %s(%s: %s, tel. %s)\n", mFirstName, mLastName, mAge, mPhone);

    return 0;
}
static void getLine(char *prmpt, char *buff, size_t sz) {
    int ch, extra;
    int isValid = 0;

    // Get line with buffer overrun protection.
    do
    {
        if (prmpt != NULL) {
            printf("%s", prmpt);
            fflush(stdout);
        }
        if (fgets(buff, sz, stdin) == NULL) {
            printf("No input. Try again!\n");
        }

        // If it was too long, there'll be no newline. In that case, we flush
        // to end of line so that excess doesn't affect the next call.
        else if (buff[strlen(buff) - 1] != '\n') {
            extra = 0;
            while (((ch = getchar()) != '\n') && (ch != EOF))
                extra = 1;
            printf("Entry is too long. Try shorter!\n");
        }
        else
        {
            isValid = 1;
        }
    } while (isValid == 0);

    // Otherwise remove newline and give string back to caller.
    buff[strlen(buff) - 1] = '\0';

}