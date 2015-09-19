package HelperClasses;

public class Rectangle{
    private Point topLeft = new Point();
    private Point bottomRight = new Point();

    public Rectangle(double topX,double topY ,double bottomX,double bottomY){
        this.topLeft.setX(topX);
        this.topLeft.setY(topY);
        this.bottomRight.setX(bottomX);
        this.bottomRight.setY(bottomY);
    }
    public boolean isPointInside(Point point){
        boolean result = true;

        if (point.getX()>this.bottomRight.getX()
                || point.getX() <this.topLeft.getX()
                || point.getY()<this.topLeft.getY()
                || point.getY()> this.bottomRight.getY()){
            result = false;
        }
        return result;
    }
}
