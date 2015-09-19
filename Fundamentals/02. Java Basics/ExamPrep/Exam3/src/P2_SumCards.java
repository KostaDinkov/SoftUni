import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P2_SumCards {
    public static void main(String[] args) {
        String input = new Scanner (System.in).nextLine();
        ArrayList<String> letters = new ArrayList<String>();
        Pattern letPattern = Pattern.compile("[\\dJKAQ]+");
        Matcher lettersMatcher = letPattern.matcher(input);
        while(lettersMatcher.find()){
            String letter = lettersMatcher.group();
            letters.add(letter);
        }

        int letterSum = getSum(extractNumeric(letters));
        System.out.println(letterSum);
    }
    static ArrayList extractNumeric(ArrayList<String> list){
        ArrayList<Integer> numeric = new ArrayList<Integer>();
        for (String letter: list){
            switch (letter){
                case ("A"):
                    numeric.add(15);
                    break;
                case ("J"):
                    numeric.add(12);
                    break;
                case ("Q"):
                    numeric.add(13);
                    break;
                case ("K"):
                    numeric.add(14);
                    break;
                case ("2"):
                    numeric.add(2);
                    break;
                case ("3"):
                    numeric.add(3);
                    break;
                case ("4"):
                    numeric.add(4);
                    break;
                case ("5"):
                    numeric.add(5);
                    break;
                case ("6"):
                    numeric.add(6);
                    break;
                case ("7"):
                    numeric.add(7);
                    break;
                case ("8"):
                    numeric.add(8);
                    break;
                case ("9"):
                    numeric.add(9);
                    break;
                case ("10"):
                    numeric.add(10);
                    break;

            }
        }
        return numeric;
    }

    static int getSum(ArrayList<Integer> list){
        int lastNumber = 0 ;
        int sum = 0;
        int tempSum = 0;

        boolean shouldDouble = false;
        for (int number: list){
            if (number == 0){
                tempSum+=number;
                lastNumber = number;
            }
            else if(number == lastNumber ){

                shouldDouble = true;
                tempSum = tempSum+ number;
                lastNumber = number;
            }
            else
            {
                if (shouldDouble){
                    tempSum= tempSum*2;
                }
                sum+=tempSum;
                shouldDouble = false;
                tempSum = 0;
                tempSum+=number;
                lastNumber = number;
            }
        }
        if (shouldDouble){
            tempSum*=2;
        }
        sum+=tempSum;

        return sum;
    }
}
