/**
 * Software University
 * Course : Java Basics
 * Lecture: Loops, Methods, Classes
 * Problem: 3. Full House
 * Description:
 * In most Poker games, the "full house" hand is defined as three cards of the
 * same face + two cards of the same face, other than the first, regardless of the card's suits.
 * The cards faces are "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" and "A".
 * The card suits are "♣", "♦", "♥" and "♠". Write a program to generate and print all
 * full houses and print their number.
 * Created  on 31-08-2014.
 */


public class Problem3_FullHouse {
        public static void main(String[] args) {

        String[] faces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        String[] suits = { "♠", "♥","♦","♣"};
        int comboCount = 0;

            for (String firstCard : faces) {
                for (int tripleSuit1 = 0; tripleSuit1 < suits.length; tripleSuit1++) {
                    for (int tripleSuit2 = tripleSuit1 + 1; tripleSuit2 < suits.length; tripleSuit2++) {
                        for (int tripleSuit3 = tripleSuit2 + 1; tripleSuit3 < suits.length; tripleSuit3++) {
                            for (String secondCard : faces) {
                                //if a card from the pair equals a card from the triple  - skip
                                if (firstCard.compareTo(secondCard) != 0) {
                                    for (int pairSuite1 = 0; pairSuite1 < suits.length; pairSuite1++) {
                                        for (int pairSuite2 = pairSuite1 + 1; pairSuite2 < suits.length; pairSuite2++) {
                                            comboCount++;
                                            System.out.println("(" + firstCard + suits[tripleSuit1] + " " + firstCard + suits[tripleSuit2] + " " + firstCard + suits[tripleSuit3] + " "
                                                    + secondCard + suits[pairSuite1] + " " + secondCard + suits[pairSuite2] + ")");

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        System.out.printf("%d full houses", comboCount);
    }



}
