/*
* SoftUni
* Course:		C Programming
* Lecture:		Loops
* Problem:		4. Print a Deck of 52 Cards
*				Write a program that generates and prints all possible cards
*				from a standard deck of 52 cards (without the jokers). The cards should be printed
*				using the classical notation (like 5S (?), AH (?), 9C (?) and KD (?)). The card faces
*				should start from 2 to A. Print each card face in its four possible suits: clubs, diamonds,
*				hearts and spades.
*
* Date:			23-10-2015
*/

#include <stdio.h>

#define FACE_COUNT 13
#define SUIT_COUNT 4

int main(void)
{
	char suits[SUIT_COUNT] = "SACD";
	char *faces[FACE_COUNT] = { "2","3","4","5","6","7","8","9","10","J","Q","K","A" };

	for (int suit = 0; suit < SUIT_COUNT; suit++)
	{
		for (int face = 0; face < FACE_COUNT; face++)
		{
			printf("%s%c ", faces[face], suits[suit]);
		}
		printf("\n");
	}
	return 0;
}