/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 5. Count All Words
 * Description:
 * Write a program to count the number
 * of words in given sentence.
 * Use any non-letter character as word separator.
 * Created  on 09-09-2014.
 */

// working with multiline input
import java.util.Scanner;

public class Problem5_CountAllWords {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter some text:");
        StringBuilder text = new StringBuilder();
        while(true){
            String nextLine = input.nextLine();
            if (nextLine.equals("")) {
                break;
            }
            text.append(nextLine);
            text.append( " ");
        }
        System.out.println(countWords(text.toString()));
    }
    static int countWords(String input){
        String[] words = input.split("[\\W\\s]+");

        return words.length;
    }
}
