/*
* SoftUni
* Course:		C Programming
* Lecture:		Conditional Statements
* Problem:		2. Bonus Score
*				Write a program that applies bonus score to given score in the range [1…9] by the following rules:
*				-If the score is between 1 and 3, the program multiplies it by 10.
*				-If the score is between 4 and 6, the program multiplies it by 100.
*				-If the score is between 7 and 9, the program multiplies it by 1000.
*				-If the score is 0 or more than 9, the program prints “invalid score”.
*/

#include <stdio.h>;

int main(void) {
	int score;
	printf("Enter score: ");
	scanf("%i", &score);
	int bonuScore;
	if (score<1 || score > 9)
	{
		printf("invalid score\n");
		return 0;
	}
	else if (score >= 1 && score <= 3) {
		bonuScore = score * 10;
	}
	else if (score >= 4 && score <= 6) {
		bonuScore = score * 100;
	}
	else if (score >= 7 && score <= 9) {
		bonuScore = score * 1000;
	}
	printf("%i\n", bonuScore);
	return 0;
}