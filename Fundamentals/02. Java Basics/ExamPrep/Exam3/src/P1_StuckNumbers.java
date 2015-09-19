import java.util.Scanner;

public class P1_StuckNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner (System.in);
        int numCount = input.nextInt();
        input.nextLine();
        String [] numbers = input.nextLine().split(" ");
        boolean found = false;
        for (String a : numbers){
                for (String b: numbers){

                    if (!a.equals(b)) {
                        for( String c: numbers){
                            if (!b.equals(c) && !c.equals(a)) {
                                for ( String d: numbers){
                                    if (!d.equals(a)&& !d.equals(b)&& !d.equals(c)) {
                                        String ab = a+b;
                                        String cd = c+d;
                                        if (ab.equals(cd)) {
                                            System.out.println(a+"|"+b+"==" +c+"|"+d);
                                            found=true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
        }
        if(!found){
            System.out.println("No");
        }
    }
}
