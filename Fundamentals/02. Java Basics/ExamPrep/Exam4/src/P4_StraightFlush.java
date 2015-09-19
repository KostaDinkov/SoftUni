import java.util.*;

public class P4_StraightFlush {
    public static void main(String[] args) {
        String input = new Scanner(System.in).nextLine();
        String[] parts = input.split(", ");
        TreeMap<Integer,String> cards = new TreeMap<Integer, String>();
        for (String part: parts){
            int value = getNumericValue(part);
            cards.put(value,part);
        }
        System.out.println(cards);
        TreeMap<Integer,String> flushes = new TreeMap<Integer,String>();
        int tempVal = 0;
        int counter = 0;
        for(Map.Entry card:cards.entrySet()){
            int val = (Integer)card.getKey();
            if (counter == 5){
                System.out.println(flushes.values());
                flushes.clear();
                counter = 0;
                tempVal = 0;
            }
            else if (val-tempVal ==1|| tempVal == 0){
                flushes.put((Integer)card.getKey(),card.getValue().toString());
                counter +=1;
                tempVal = val;

            }
            else {
                flushes.clear();
                flushes.put((Integer)card.getKey(),card.getValue().toString());
                tempVal = val;
                counter = 0;
            }

        }





    }

    private static Integer getNumericValue(String card) {

        if (card.startsWith("2")) return 2;
        if (card.startsWith("3")) return 3;
        if (card.startsWith("4")) return 4;
        if (card.startsWith("5")) return 5;
        if (card.startsWith("6")) return 6;
        if (card.startsWith("7")) return 7;
        if (card.startsWith("8")) return 8;
        if (card.startsWith("9")) return 9;
        if (card.startsWith("10")) return 10;
        if (card.startsWith("J")) return 11;
        if (card.startsWith("Q")) return 12;
        if (card.startsWith("K")) return 13;
        if (card.startsWith("A")) return 14;
        throw new IllegalArgumentException("Invalid card: " + card);
    }
}
