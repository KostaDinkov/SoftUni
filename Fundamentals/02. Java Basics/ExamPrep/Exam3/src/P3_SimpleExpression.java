import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class P3_SimpleExpression {
    public static void main(String[] args) {
        String input = new Scanner(System.in).nextLine();
        String stripped = input.replaceAll("\\s+", "");
        Pattern pattern = Pattern.compile("[+-]?[\\d\\.]+");
        Matcher matcher = pattern.matcher(stripped);

        ArrayList<BigDecimal> numbers = new ArrayList<>();
        while(matcher.find()){
            numbers.add(new BigDecimal( matcher.group()));
        }

        BigDecimal sum = new BigDecimal(0);
        for (BigDecimal number: numbers){
            sum =sum.add(number);
        }
        System.out.printf("%.7f",sum);

    }
}
