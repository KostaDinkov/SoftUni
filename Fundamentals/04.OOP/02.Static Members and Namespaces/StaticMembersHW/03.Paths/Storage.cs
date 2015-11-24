using System.IO;
using System.Linq;

namespace _03.Paths
{
    internal static class Storage
    {
        public static void SavePath(Path3D path, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var point in path.Points)
                {
                    string output = $"{point.X}|{point.Y}|{point.Z}";
                    sw.WriteLine(output);
                }
            }
        }

        public static Path3D LoadPath(string fileName)
        {
            Path3D result = new Path3D();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = string.Empty;
                while ((line = sr.ReadLine()) != null)
                {
                    double[] numbers = new double[3];
                    Point3D point = new Point3D();
                    numbers = line.Split('|').Select(double.Parse).ToArray();
                    point.X = numbers[0];
                    point.Y = numbers[1];
                    point.Z = numbers[2];
                    result.Points.Add(point);
                }
            }
            return result;
        }
    }
}