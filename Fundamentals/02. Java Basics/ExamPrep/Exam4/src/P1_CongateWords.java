import java.util.HashSet;
import java.util.Scanner;

public class P1_CongateWords {
    public static void main(String[] args) {
        //Parse input string
        String input = new Scanner(System.in).nextLine();
        String [] words = input.split("[\\W\\d]+");

        //only for debugging
//        for (String word : words){
//            System.out.println(word);
//        }

        //using HashSet to store only unique results;
        HashSet<String> uniqueResults=new HashSet<String>();

        //compare strings by reference not by value!
        for (String a : words){
            for(String b : words){
                if (a!=b){
                    for (String c:words){
                        if(a!=c && b!=c){
                            String ab = a+b;
                            if (ab.equals(c)){
                                uniqueResults.add(a + "|" + b + "=" + c);
                            }
                        }
                    }
                }
            }
        }

        //Print the result
        if (uniqueResults.isEmpty()){
            System.out.println("No");
        }
        else {
            for (String unique : uniqueResults) {
                System.out.println(unique);
            }
        }

    }
}
