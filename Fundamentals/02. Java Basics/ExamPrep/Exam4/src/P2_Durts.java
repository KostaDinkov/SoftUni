import java.lang.reflect.Array;
import java.util.Scanner;

public class P2_Durts {
    public static void main(String[] args) {
        //read the input
        Scanner input = new Scanner(System.in);
        int centerX =  input.nextInt();
        int centerY = input.nextInt();
        int radius = input.nextInt();
        int dartCount = input.nextInt();
        input.nextLine();
        String dartInput = input.nextLine();
        String [] tmp = dartInput.split("\\s+");
        int[][] darts = new int[dartCount][];
        int index =0;
        for (int i = 0; i < tmp.length-1; i+=2, index++) {
            int[] dartXY = new int[2];
            dartXY[0]= Integer.parseInt(tmp[i]);
            dartXY[1]= Integer.parseInt(tmp[i+1]);
            darts[index] = dartXY;
        }
        //test input parsing
        for (int[] dart:darts){
            //System.out.println(dart[0]+ " "+ dart[1]);
            //rect1
            double topLeftXr1 = (centerX-radius/2);
            double topLeftYr1 = centerY +radius;
            double bottomRightXr1 = centerX +radius/2;
            double bottomRightYr1 = centerY -radius;
            //rect2
            double topLeftXr2 = (centerX-radius);
            double topLeftYr2 = centerY +radius/2;
            double bottomRightXr2 = centerX +radius;
            double bottomRightYr2 = centerY -radius/2;

            boolean isInRect1 = isDartIn(dart,topLeftXr1,topLeftYr1, bottomRightXr1,bottomRightYr1);
            boolean isInRect2 = isDartIn(dart,topLeftXr2,topLeftYr2, bottomRightXr2,bottomRightYr2);
            if (isInRect1||isInRect2){
                System.out.println("yes");
            }
            else{
                System.out.println("no");

            }
        }



    }

    private static boolean isDartIn(int[] dart, double topLeftX, double topLeftY, double bottomRightX, double bottomRightY) {

        if(dart[0]>bottomRightX||dart[0]<topLeftX||dart[1]>topLeftY||dart[1]<bottomRightY){
            return false;
        }
        return true;
    }
}
