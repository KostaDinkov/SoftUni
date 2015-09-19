/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 6. Count Specific Word
 * Description: Write a program to find how many times a word appears in given text.
 * The text is given at the first input line. The target word is given
 * at the second input line. The output is an integer number. Please ignore the
 * 7character casing. Consider that any non-letter character is a word separator.
 * Created  on 09-09-2014.
 */

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem6_CountSpecificWord {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter text:");
        String text = input.nextLine();
        System.out.println("Enter target word:");
        String word = input.nextLine();
        System.out.println(countOcurancesOfWord(text,word));

    }
    static int countOcurancesOfWord(String text, String word){
        Pattern pattern = Pattern.compile("(?i)\\b" + word+"\\b");
        Matcher matcher = pattern.matcher(text);
        int count = 0;
        while (matcher.find()) count++;
        return count;
    }
}
