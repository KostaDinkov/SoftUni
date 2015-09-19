/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 6
 * Description:
 * Write a program that reads 3 numbers: an integer a
 * (0 ≤ a ≤ 500), a floating-point b and a floating-point
 * c and prints them in 4 virtual columns on the console.
 * Each column should have a width of 10 characters.
 * The number a should be printed in hexadecimal, left aligned;
 * then the number a should be printed in binary form, padded with zeroes,
 * then the number b should be printed with 2 digits after the decimal point,
 * right aligned; the number c should be printed with 3 digits after the decimal point,
 * left aligned
 * Created  on 27-08-2014.
 */
import java.util.Locale;
import java.util.Scanner;
public class Problem6FormattingNumbers {
    public static void main(String[] args) {
        Locale.setDefault(Locale.US);
        Scanner input = new Scanner(System.in);
        int a = input.nextInt();
        double b = input.nextDouble();
        double c = input.nextDouble();
        String binaryA = String.format("%10s",Integer.toBinaryString(a)).replace(' ','0');
        System.out.printf("|%1$-10x|%2$s|%3$10.2f|%4$-10.3f|",a, binaryA,b,c);
    }
}
