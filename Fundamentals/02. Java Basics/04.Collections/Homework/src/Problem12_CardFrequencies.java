/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 12.Card Frequencies
 * Description:
 * We are given a sequence of N playing cards from a standard deck.
 * The input consists of several cards (face + suit), separated by a space.
 * Write a program to calculate and print at the console the frequency of each
 * card face in format "card_face -> frequency".
 * The frequency is calculated by the formula appearances / N and is expressed in
 * percentages with exactly 2 digits after the decimal point.
 * The card faces with their frequency should be printed in the order of the card face's first appearance in the input.
 * The same card can appear multiple times in the input, but it's face should be listed only once in the output.
 * Created  on 10-09-2014.
 */
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
public class Problem12_CardFrequencies {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter card sequence");
        String sequence = input.nextLine();
        String[]cards = sequence.split(" ");

        // strip the suit char
        String[] ranks = new String[cards.length];
        for (int i = 0; i < ranks.length; i++) {
            ranks[i] = cards[i].substring(0,cards[i].length()-1);
        }

        LinkedHashMap<String,Integer> cardFreq = new LinkedHashMap<>();
        for (String rank: ranks){
            if (cardFreq.containsKey(rank)){
                cardFreq.put(rank,(cardFreq.get(rank)+1));
            }
            else{
                cardFreq.put(rank,1);
            }
        }
        //Print results
        for (Map.Entry<String,Integer> entry: cardFreq.entrySet()){
            double cardsCount = cards.length;
            double freq = (entry.getValue()/cardsCount)*100;
            System.out.printf("%s -> %.2f%%", entry.getKey(), freq);
            System.out.println();
        }


    }
}
