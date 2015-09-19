/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Syntax
 * Problem: 3
 * Description:
 * Write a program to check whether a point is inside or outside of
 * the figure below. The point is given as a pair of floating-point
 * numbers, separated by a space. Your program should print "Inside"
 * or "Outside"
 * Created  on 26-08-2014.
 */
import HelperClasses.Figure;
import HelperClasses.Point;
import HelperClasses.Rectangle;

import java.util.Scanner;

public class Problem3PointsInsideFigure {

    public static void main(String[] args) {

        //construct Figure parts
        Figure figure = new Figure();
        figure.addPart(new Rectangle(12.5,8.5,17.5,13.5));
        figure.addPart(new Rectangle(20,8.5,22.5,13.5));
        figure.addPart(new Rectangle(12.5,6,22.5,8.5));

        //construct some test points as given in the homework spec
        Point[] testPoints = new Point[]{
                new Point(10.0, 9.7),
                new Point(11.6, 7),
                new Point(12.5, 6),
                new Point(12.5, 14.5),
                new Point(13.13, 9.15),
                new Point(15.02, 4.83),
                new Point(15.11, 7.01),
                new Point(16.33, 14.03),
                new Point(17.5, 13.5),
                new Point(17.60, 8.50)
        };
        // printing the hard coded test cases
        System.out.println("Running some hardcoded tests...");
        for (int i = 0; i < testPoints.length; i++) {
            System.out.printf("Test case %2$d : %1s\n", figure.checkPoint(testPoints[i]) ? "Inside" : "Outside", i + 1);
        };

        //testing with user input

        Point userPoint = new Point();
        Scanner input = new Scanner(System.in);
        System.out.println("Now you try some values.");
        System.out.println("Enter the x and y coordinates\n(separated by space or new line)\nof the point to be checked :");
        userPoint.setX(input.nextDouble());
        userPoint.setY(input.nextDouble());

        System.out.printf("The point %1$f %2$f is %3$s the figure",
                userPoint.getX(),
                userPoint.getY(),
                figure.checkPoint(userPoint) ? "Inside" : "Outside of");
    }
}
