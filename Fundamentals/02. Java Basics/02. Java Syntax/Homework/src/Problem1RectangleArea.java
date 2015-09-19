/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 1
 * Description:
 * Write a program that enters the sides of a rectangle
 * (two integers a and b) and calculates and prints the
 * rectangle's area.
 *
 * Created  on 26-08-2014.
 */
import java.util.Scanner;

public class Problem1RectangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter value for side A :");
        int sideA = input.nextInt();
        System.out.println("Enter value for side B :");
        int sideB = input.nextInt();
        int area = sideA*sideB;
        System.out.printf("The area of the rectangle with sides %d and %d is %d", sideA, sideB, area);
    }
}
