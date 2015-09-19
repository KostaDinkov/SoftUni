/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 9. Lists of Letters
 * Description:
 * Write a program that reads two lists of letters l1 and l2
 * and combines them: appends all letters c from l2 to the end of l1,
 * but only when c does not appear in l1.
 * Print the obtained combined list. All lists are given as sequence of
 * letters separated by a single space, each at a separate line. Use ArrayList<Character>
 * of chars to keep the input and output lists.
 * Created  on 10-09-2014.
 */

import java.util.ArrayList;
import java.util.Scanner;
public class Problem9_ListsOfLetters {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        System.out.println("Enter line 1:");
        String inputA = input.nextLine();
        System.out.println("Enter line 2:");
        String inputB = input.nextLine();
        ArrayList<Character> listA = new ArrayList<>(extractLetters(inputA));
        ArrayList<Character> listB = new ArrayList<>(extractLetters(inputB));
        ArrayList<Character> appended = new ArrayList<>(listA);

        for (Character element : listB) {
            if (!listA.contains(element)) {
                appended.add(element);
            }
        }
        appended.stream().forEach(c-> System.out.print(c + " "));
    }

    static ArrayList<Character> extractLetters( String input){
        ArrayList<Character> result = new ArrayList<>();
        for (int i = 0; i < input.length(); i++) {
            if (!(input.charAt(i) == ' ')){
                result.add(input.charAt(i));
            }
        }
        return result;
    }
}
