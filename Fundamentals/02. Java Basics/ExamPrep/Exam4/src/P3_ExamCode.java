import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class P3_ExamCode {
    public static void main(String[] args) {
        Scanner input = new Scanner (System.in);
        input.nextLine();
        input.nextLine();
        input.nextLine();
        TreeMap<Integer,TreeMap<String,Double>> scores = new TreeMap<Integer, TreeMap<String, Double>>();

        while(true){
            String inputLine = input.nextLine();
            if (inputLine.isEmpty()){
                break;
            }
            String[] parts = inputLine.split("\\s*\\|\\s*");
            if (parts.length !=4){
                break;
            }
            String name = parts[1];
            int score = Integer.parseInt(parts[2]);
            Double grade = Double.parseDouble(parts[3]);
            TreeMap<String,Double> nameGrade = new TreeMap<String, Double>();
            nameGrade.put(name,grade);
            if (scores.containsKey(score)) {
                scores.get(score).put(name, grade);
            }
            else{
                scores.put(score,nameGrade);
            }
        }



        for (int score:scores.keySet()){
            StringBuilder output = new StringBuilder();
            output.append(score+ " -> ");
            output.append(scores.get(score).keySet()+"; ");
            double sum = 0;
            for (double grade :scores.get(score).values()){
                sum+=grade;
            }
            double avg = sum/scores.get(score).values().size();

            output.append(String.format("avg=%.2f",avg));
            System.out.println(output);

        }

    }
}
