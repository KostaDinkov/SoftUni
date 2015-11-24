/*
** SoftUni
** Course:		OOP
** Lecture:		Static Members and Namespaces
** Problem:		4.Namespaces
** Description:	
**              Design a group of classes to work with geometric figures. 
**              Put them into namespaces. You do not need to implement the classes, 
**              just create them and put them into namespaces. Make sure the files are 
**              placed in directories corresponding to the namespaces.
**              Namespace Geometry.Geometry2D holds classes:
**              •	Point2D
**              •	Figure2D
**              •	Square
**              •	Rectangle
**              •	Polygon
**              •	Circle
**              •	Ellipse
**              •	DistanceCalculator2D
**              Namespace Geometry.Geometry3D holds classes:
**              •	Point3D
**              •	Path3D
**              •	DistanceCalculator3D
**              Namespace Geometry.Storage holds classes:
**              •	GeometryXMLStorage
**              •	GeometryBinaryStorage
**              •	GeometrySVGStorage
**              Namespace Geometry.UI holds classes:
**              •	Screen2D
**              •	Screen3D
**              
** 	
** Date:		Thursday 11.2015 21:51 
*/

using _04.Namespaces.Geometry.Geometry2D;
using _04.Namespaces.Geometry.Geometry3D;
using _04.Namespaces.Geometry.Storage;
using _04.Namespaces.Geometry.UI;

namespace _04.Namespaces.Geometry.UI
{
    class Screen3D
    {
        Circle circle = new Circle();
        Point2D point = new Point2D();
        Point3D point3D = new Point3D();
        // etc...
    }
}
