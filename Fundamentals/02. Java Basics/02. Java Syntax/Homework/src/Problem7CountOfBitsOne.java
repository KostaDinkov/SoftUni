/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 7
 * Description:
 * Write a program to calculate the count of bits 1 in
 * the binary representation of given integer number n
 * Created  on 30-08-2014.
 */
import java.util.Scanner;
public class Problem7CountOfBitsOne {
    public static void main(String[] args) {

        Scanner input = new Scanner(System.in);
        System.out.println("Enter an integer :");
        int number = input.nextInt();
        String binary = String.format("%16s",Integer.toBinaryString(number)).replace(' ','0');
        System.out.println("The input number in binary :" + binary);
        int counter = 0;
        for (int i = 0; i < binary.length(); i++) {
            if (binary.charAt(i) =='1'){
                counter++;
            }
        }
        System.out.println("Number of 1s in the binary code :" + counter);
    }
}
