/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 4
 * Description:
 * Write a program that finds the smallest of three numbers.
 * Created  on 27-08-2014.
 */
import java.util.Arrays;
import java.util.Scanner;
public class Problem4SmallestOf3 {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double[] numbers = new double[3];
        System.out.println("This program compares three floating point numbers\nand prints the smallest one.");
        System.out.println("Enter first number: ");
        numbers[0]= input.nextDouble();
        System.out.println("Enter second number: ");
        numbers[1]= input.nextDouble();
        System.out.println("Enter third number: ");
        numbers[2]= input.nextDouble();
        Arrays.sort(numbers);
        System.out.println("The smallest number is: "+ numbers[0]);
    }
}
