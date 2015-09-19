import java.util.ArrayList;
import java.util.Scanner;

public class P1_CountBeers {
    public static void main(String[] args) {
        Scanner input = new Scanner (System.in);
        ArrayList<String[]> lines = new ArrayList<String[]>();
        while(true){
            String nextLine = input.nextLine();
            if (nextLine.equals("End")){
                break;
            }
            else {
                lines.add(nextLine.split( " "));
            }
        }
        int stacks = 0;
        int beers = 0;
        for ( String[] array:lines){
            if (array[1].equals("stacks")){
                stacks+=Integer.parseInt(array[0]);
            }
            else {
                beers += Integer.parseInt(array[0]);
            }

        }
        stacks += (beers/20);
        int leftOverBeers = beers%20;
        System.out.printf("%d stacks + %d beers",stacks,leftOverBeers);

    }
}
