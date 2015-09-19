import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String inputParts = input.nextLine();
        Pattern pattern = Pattern.compile("\\d+,?\\d?");
        Matcher matcher = pattern.matcher(inputParts);
        ArrayList<Double> numbers = new ArrayList<Double>();
        while(matcher.find()){
            numbers.add(Double.parseDouble(matcher.group()));
        }
        ArrayList<Double> areas= new ArrayList<Double>();
        for (int i = 0; i < numbers.size() - 1; i+=2) {
            areas.add(numbers.get(i)*numbers.get(i+1));
        }
        double maxTotal = Double.MIN_VALUE;
        for (int i = 0; i < areas.size()-2; i++) {
            double tempTotal = areas.get(i)+ areas.get(i+1)+ areas.get(i+2);
            if (tempTotal>maxTotal){
                maxTotal=tempTotal;
            }
        }

        DecimalFormat df = new DecimalFormat("0.#");
        System.out.println(df.format(maxTotal));


    }
}
