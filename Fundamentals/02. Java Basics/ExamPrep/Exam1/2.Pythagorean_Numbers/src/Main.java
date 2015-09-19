import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int inputCount = input.nextInt();
        int[] numbers = new int[inputCount];
        for (int i = 0; i < inputCount; i++) {
            numbers[i] = input.nextInt();
        }
        boolean isTrippleFound = false;
        for (int i = 0; i < inputCount; i++) {
            for (int j = i; j < inputCount; j++) {
                for (int k = j; k <inputCount ; k++) {
                    ArrayList<Integer> testTriple = new ArrayList<Integer>();
                    testTriple.add(numbers[i]);
                    testTriple.add(numbers[j]);
                    testTriple.add(numbers[k]);
                    Collections.sort(testTriple);
                    int a = testTriple.get(0);
                    int b = testTriple.get(1);
                    int c = testTriple.get(2);
                    if ((a*a)+(b*b)==(c*c)){
                        System.out.printf("%1$d*%1$d + %2$d*%2$d = %3$d*%3$d", a, b, c);
                        System.out.println();
                        isTrippleFound = true;
                    }

                }

            }
        }
        if (!isTrippleFound){
            System.out.println("No");
        }
    }
}
