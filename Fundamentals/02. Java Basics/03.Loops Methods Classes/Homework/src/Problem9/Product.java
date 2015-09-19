package Problem9;

public class Product implements Comparable<Product>{
    private String name;
    private double price;

    public double getPrice() {
        return price;
    }

    public String getName() {
        return name;
    }

    public Product(String name, double price){
        this.name = name;
        this.price = price;
    }

    public int compareTo(Product other) {
        if(this.price == other.getPrice()) {
            return 0;
        }
        return (this.price<other.getPrice()? -1:1);

    }

}
