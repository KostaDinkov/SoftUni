import java.math.BigDecimal;
import java.util.Arrays;
import java.util.Scanner;

public class P2_ThreeLargestNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner (System.in);
        int lineCount = Integer.parseInt(input.nextLine());
        BigDecimal[] numbers = new BigDecimal[lineCount];
        for (int i = 0; i < lineCount; i++) {
            String inputLine = input.nextLine();
            BigDecimal parsedLine = new BigDecimal(inputLine);
            numbers[i] = parsedLine;
        }
        Arrays.sort(numbers);
        int counter = 1;
        for (int i = numbers.length-1; i >=0 ; i--) {
            System.out.println(numbers[i].toPlainString());
            if (counter == 3){
                break;
            }
            else {
                counter ++;
            }
        }



    }
}
