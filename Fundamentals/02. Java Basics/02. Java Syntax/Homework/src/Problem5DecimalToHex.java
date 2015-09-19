/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 5
 * Description:
 * Write a program that enters a positive integer
 * number num and converts and prints it in hexadecimal form.
 * You may use some built-in method from the standard Java libraries.
 * Created  on 27-08-2014.
 */
import java.util.Scanner;

public class Problem5DecimalToHex {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter a positive integer:");
        int number = input.nextInt();
        String hex = Integer.toHexString(number);
        System.out.printf("The number %d in hexadecimal form is %s\n",number,hex);
    }
}
