import java.util.Arrays;
import java.util.Scanner;

/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: Sort Array of Numbers
 * Description:
 * Write a program to enter a number n and n integer
 * numbers and sort and print them. Keep the numbers in array of integers: int[].
 * Created  on 06-09-2014.
 */
public class Problem1_SortArrayOfNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter the count of numbers to be sorted:");
        int numCount = input.nextInt();
        int[] numbers = new int[numCount];
        System.out.println("Enter the numbers to be sorted:");
        for (int i = 0; i < numCount; i++) {
            numbers[i] = input.nextInt();
        }
        Arrays.sort(numbers);
        System.out.println("Sorted :");
        for (int number : numbers){
            System.out.print(number + " ");
        }
    }
}
