package HelperClasses;

public class Triangle {
    private Point p1 = new Point();
    private Point p2 = new Point();
    private Point p3 = new Point();
    public Triangle(Point p1, Point p2, Point p3){
        this.p1.setX(p1.getX());
        this.p2.setX(p2.getX());
        this.p3.setX(p3.getX());
        this.p1.setY(p1.getY());
        this.p2.setY(p2.getY());
        this.p3.setY(p3.getY());
    }
    public boolean isPointInside(Point point){
        double alpha = ((p2.getY()-p3.getY())*(point.getX() - p3.getX()) + (p3.getX() - p2.getX())*(point.getY() - p3.getY())) /
                ((p2.getY() - p3.getY())*(p1.getX() - p3.getX()) + (p3.getX() - p2.getX())*(p1.getY() - p3.getY()));
        double beta = ((p3.getY() - p1.getY())*(point.getX() - p3.getX()) + (p1.getX() - p3.getX())*(point.getY() - p3.getY())) /
                ((p2.getY() - p3.getY())*(p1.getX() - p3.getX()) + (p3.getX() - p2.getX())*(p1.getY() - p3.getY()));
        double gamma = 1.0 - alpha - beta;
        if (alpha>=0 && beta >=0 && gamma >= 0 ){
            return true;
        }
        return false;
    }
}
