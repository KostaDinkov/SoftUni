import java.time.LocalDateTime;

/**
 * Software University
 * Course : Java Basics
 * Lecture: Introduction to Java
 * Problem: 5
 * Description:
 * Create a simple Java program CurrentDateTime.java
 * to print the current date and time.
 * Submit the Java class CurrentDateTime as
 * part of your homework.
 *
 * Created  on 14-8-24.
 */
public class Problem5_CurrentDateTime {
    public static void main(String[] args) {
        LocalDateTime today = LocalDateTime.now() ;
        System.out.format("\nToday is : %1$td/%1$tm/%1$ty current time : %1$tH:%1$tM:%1$tS \n",today);
    }
}
