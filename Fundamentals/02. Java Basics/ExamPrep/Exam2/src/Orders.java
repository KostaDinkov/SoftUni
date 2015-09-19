import java.util.*;

public class Orders {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int lineCount = input.nextInt();
        input.nextLine();
        String []lines = new String[lineCount];
        for (int i = 0; i < lineCount; i++) {
            lines[i] = input.nextLine();
        }
        LinkedHashMap<String,TreeMap<String,Integer>> orderList = new LinkedHashMap<String, TreeMap<String, Integer>>();

        for (String line : lines){
            String[] parts = line.split(" ");
            String customer = parts[0];
            int amount = Integer.parseInt(parts[1]);
            String product = parts[2];
            if (orderList.containsKey(product)){
                if (orderList.get(product).containsKey(customer)){
                    orderList.get(product).put(customer,orderList.get(product).get(customer)+amount);
                }
                else {
                    orderList.get(product).put(customer,amount);
                }
            }
            else {
                TreeMap<String,Integer> customerAmount = new TreeMap<String, Integer>();
                customerAmount.put(customer,amount);
                orderList.put(product,customerAmount);
            }
        }

        for (Map.Entry entry : orderList.entrySet()){
            StringBuilder output = new StringBuilder();
            String product = entry.getKey().toString();
            output.append(product + ":");
            for (Map.Entry customerAmmount: orderList.get(entry.getKey()).entrySet()){
                String customer = customerAmmount.getKey().toString();
                int amount = Integer.parseInt( customerAmmount.getValue().toString());

                output.append(" "+ customer+ " " + amount + ",");

            }
            output.deleteCharAt(output.length()-1);
            System.out.println(output);


        }
    }
}



