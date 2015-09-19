import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 8. Extract Emails
 * Description:
 * Write a program to extract all email addresses from given text.
 * The text comes at the first input line. Print the emails in the
 * output, each at a separate line. Emails are considered to be in format <user>@<host>, where:
 •	<user> is a sequence of letters and digits, where '.', '-' and '_' can appear between them.
    Examples of valid users: "stephan", "mike03", "s.johnson", "st_steward", "softuni-bulgaria", "12345".
    Examples of invalid users: ''--123", ".....", "nakov_-", "_steve", ".info".
 •	<host> is a sequence of at least two words, separated by dots '.'.
    Each word is sequence of letters and can have hyphens '-' between the letters.
    Examples of hosts: "softuni.bg", "software-university.com", "intoprogramming.info", "mail.softuni.org".
    Examples of invalid hosts: "helloworld", ".unknown.soft.", "invalid-host-", "invalid-".
 •	Example of valid emails: info@softuni-bulgaria.org, kiki@hotmail.co.uk, no-reply@github.com, s.peterson@mail.uu.net, info-bg@software-university.software.academy.

 * Created  on 09-09-2014.
 */
public class Problem8_ExtractEmails {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter a text :");
        String text = input.nextLine();
        ArrayList<String> mailList = extractEmails(text);
        mailList.stream().forEach(mail -> System.out.println(mail));

    }
    static ArrayList<String> extractEmails(String input){
        ArrayList<String> results = new ArrayList<>();
        Matcher m = Pattern.compile("[a-zA-Z0-9]+[a-zA-Z0-9_.+-]*[a-zA-Z0-9]+@([a-zA-Z]+[a-zA-Z-]*[a-zA-Z]+\\.[a-zA-Z]+[a-zA-Z-]*[a-zA-Z])?(\\.[a-zA-Z]+[a-zA-Z-]*[a-zA-Z]+)*").matcher(input);
        while (m.find()) {
            results.add(m.group());
        }
        return results;
    }
}
