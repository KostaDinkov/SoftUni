/**
 * Software University
 * Course : Java Basics
 * Lecture: Java Collection Basics
 * Problem: 11. Most Frequent Word
 * Description:Write a program to find the most frequent word in a text and
 * print it, as well as how many times it appears in format "word -> count".
 * Consider any non-letter character as a word separator. Ignore the character casing.
 * If several words have the same maximal frequency, print all of them in alphabetical order.
 * Created  on 10-09-2014.
 */

import java.util.*;
public class Problem11_MostFrequentWord {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("Enter text:");
        String text = input.nextLine();

        HashMap<String,Integer> wordsCount =new HashMap<>( countWords(text));
        LinkedHashMap<String,Integer> sorted = new LinkedHashMap<String,Integer>(sortHashMapByValuesD(wordsCount));
        TreeMap<String,Integer> results = getMostFrequent(sorted);

        for (Map.Entry<String,Integer> entry:results.entrySet()){
            System.out.print(entry.getKey() + " -> " + entry.getValue()+" times");
            System.out.println();
        }
    }

    private static TreeMap<String, Integer> getMostFrequent(LinkedHashMap<String, Integer> sorted) {
        //TODO some refactoring needed in this method
        TreeMap<String,Integer> results = new TreeMap<>();
        ArrayList<Integer> frequencies = new ArrayList<>(sorted.values());
        ArrayList<String> words = new ArrayList<>(sorted.keySet());
        // if there are multiple max value entries in the sorted list
        // count their number
        int counter = 1;
        for (int i = frequencies.size()-1; i >0 ; i--) {
            if (frequencies.get(i)==frequencies.get(i-1)){
                counter++;
            }
            else break;
        }
        //put all equal max value entries into 1 TreeMap
        for (int i = 0; i <counter; i++) {
            int startIndex = frequencies.size() -1;
            results.put(words.get(startIndex-i),frequencies.get(startIndex-i));
        }
        return results;
    }

    static LinkedHashMap sortHashMapByValuesD(HashMap passedMap) {
        List mapKeys = new ArrayList(passedMap.keySet());
        List mapValues = new ArrayList(passedMap.values());
        Collections.sort(mapValues);
        Collections.sort(mapKeys);

        LinkedHashMap sortedMap = new LinkedHashMap();

        Iterator valueIt = mapValues.iterator();
        while (valueIt.hasNext()) {
            Object val = valueIt.next();
            Iterator keyIt = mapKeys.iterator();

            while (keyIt.hasNext()) {
                Object key = keyIt.next();
                String comp1 = passedMap.get(key).toString();
                String comp2 = val.toString();

                if (comp1.equals(comp2)){
                    passedMap.remove(key);
                    mapKeys.remove(key);
                    sortedMap.put(key, val);
                    break;
                }
            }
        }
        return sortedMap;
    }

    static HashMap<String, Integer> countWords(String text) {
        text = text.toLowerCase();
        String[] words = text.split("[\\W\\s]+");
        Map<String,Integer> map = new HashMap<>();
        for (String word: words){
            if (map.containsKey(word)){
                map.put(word,map.get(word)+1);
            }
            else{
                map.put(word,1);
            }
        }
        return (HashMap<String, Integer>) map;

    }


}
