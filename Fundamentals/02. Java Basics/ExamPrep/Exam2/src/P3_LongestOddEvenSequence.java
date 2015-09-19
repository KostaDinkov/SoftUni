import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P3_LongestOddEvenSequence {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        Pattern pattern = Pattern.compile("\\d+");
        Matcher matcher = pattern.matcher(input.nextLine());
        ArrayList < Integer> numbers = new ArrayList<Integer>();
        while(matcher.find()){
            numbers.add(Integer.parseInt(matcher.group()));
        }
        boolean currentState = numbers.get(0)%2 !=0;
        int bestResult = 0;
        int currentResult = 0;
        for (int number: numbers){
            if(isEven(number)==currentState || number==0){
                currentResult++;
                currentState = !currentState;
            }
            else{
                currentResult = 1;
            }
            if (currentResult> bestResult){
                bestResult = currentResult;
            }
        }
        System.out.println(bestResult);

    }
    static boolean isEven ( int number){
        return number%2==0;
    }


}
