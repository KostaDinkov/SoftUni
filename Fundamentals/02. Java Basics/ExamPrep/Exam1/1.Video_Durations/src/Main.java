import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        final ArrayList<Integer> hours = new ArrayList<Integer>();
        ArrayList<Integer> minutes = new ArrayList<Integer>();
        while(true){
            String nextLine = input.nextLine();
            if (nextLine.equals("End")){
                break;
            }
            else{
                String[] parts = nextLine.split(":");
                hours.add(Integer.parseInt(parts[0]));
                minutes.add(Integer.parseInt(parts[1]));
            }
        }
        int hourSum = hours.stream().mapToInt(Integer::intValue).sum();
        int minuteSum = minutes.stream().mapToInt(Integer::intValue).sum();
        int minutesToHours = minuteSum/60;
        int totalHours = hourSum + minutesToHours;
        int leftOverMinutes = minuteSum%60;

        System.out.printf("%d:%02d",totalHours,leftOverMinutes);
    }
}
