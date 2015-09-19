/**
 * Software University
 * Course : Java Basics
 * Lecture: Introduction to Java
 * Problem: 6
 * Description:
 * Write a program SumTwoNumbers.java that enters two
 * integers from the console, calculates and prints their sum.
 * Search in Internet to learn how to read numbers from the console.
 *
 * Created  on 14-8-24.
 */

import java.util.Scanner;

public class Problem6_SumTwoNumbers {
    public static void main(String[] args) {
        int numCount = 2; //change this  to add more than 2 numbers
        int sum = 0;
        Scanner input = new Scanner(System.in);
        for (int i = 0; i < numCount; i++) {
            System.out.print("Enter a number: ");
            sum = sum + input.nextInt();
        }
        input.close();
        System.out.println("The sum of the numbers is :" + sum);
        
    }
}
