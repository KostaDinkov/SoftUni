import java.util.*;

public class Main {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        String[] inputSplit = input.nextLine().split(" ");
        int[] numbers = new int[inputSplit.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(inputSplit[i]);
        }
        LinkedHashMap<String,Integer> map = new LinkedHashMap<String, Integer>();
        for (int i = 0; i < numbers.length - 1; i++) {
            String couple = numbers[i] + " " + numbers[i+1];
            if (map.containsKey(couple)){
                map.put(couple,map.get(couple)+1);
            }
            else map.put(couple,1);
        }
        int total = 0;
        for (int value:map.values()){
            total += value;
        }
        for (Map.Entry<String,Integer>couple:map.entrySet()){
            double percent = ((double)couple.getValue()/total)*100;
            System.out.printf("%s -> %.2f%%",couple.getKey(),percent);
            System.out.println();
        }

    }
}
