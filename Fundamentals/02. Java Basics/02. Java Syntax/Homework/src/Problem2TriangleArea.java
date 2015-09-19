/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 2
 * Description:
 * Write a program that enters 3 points in the plane
 * (as integer x and y coordinates), calculates and prints the
 * area of the triangle composed by these 3 points. Round the result
 * to a whole number. In case the three points do not form a
 * triangle, print "0" as result.
 *
 * Created  on 26-08-2014.
 */
import java.util.Scanner;

public class Problem2TriangleArea {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int Ax,Ay,Bx,By,Cx,Cy;
        System.out.print("Enter the x and y coordinates for point A:");
        Ax = input.nextInt();
        Ay = input.nextInt();
        System.out.print("Enter the x and y coordinates for point B:");
        Bx = input.nextInt();
        By = input.nextInt();
        System.out.print("Enter the x and y coordinates for point C:");
        Cx = input.nextInt();
        Cy = input.nextInt();
        int area = Math.abs((Ax*(By-Cy)+ Bx*(Cy-Ay)+Cx*(Ay- By))/2);
        System.out.println("The area of the triangle\nconstructed by the three points is: " + area);
    }
}
