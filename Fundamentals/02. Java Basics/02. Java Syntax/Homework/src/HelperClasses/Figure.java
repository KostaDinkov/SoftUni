package HelperClasses;
import java.util.ArrayList;

public class Figure {
    private ArrayList<Rectangle> rectangles = new ArrayList<Rectangle>();
    private ArrayList<Triangle> triangles = new ArrayList<Triangle>();
    public void addPart(Rectangle rect){
        this.rectangles.add(rect);
    }
    public void addPart(Triangle triangle){
        this.triangles.add(triangle);
    }

    public boolean checkPoint(Point point){

        for (int i = 0; i<this.rectangles.size();i++){
            if (this.rectangles.get(i).isPointInside(point)){
                return true;
            }
        }
        for (int i = 0; i<this.triangles.size();i++){
            if (this.triangles.get(i).isPointInside(point)){
                return true;
            }
        }
        return false;
    }

}
