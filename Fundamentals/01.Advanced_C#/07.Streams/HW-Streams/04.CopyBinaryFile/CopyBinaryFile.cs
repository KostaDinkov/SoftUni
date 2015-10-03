//SoftUni
//Course:   Advanced C#
//Lecture:  Streams and Files
//Problem:  4. Copy Binary File  
//          Write a program that copies the contents of a binary file
//          (e.g.image, video, etc.) to another using FileStream. 
//          You are not allowed to use the File class or similar helper classes

using System.IO;


namespace _04.CopyBinaryFile
{
    class CopyBinaryFile
    {
        static void Main()
        {
            string originalFile = "../../darthmaul.jpg";
            string fileCopy = "../../darthmaul_copy.jpg";

            using (FileStream inputStream = new FileStream(originalFile,FileMode.Open))
            {
                using (FileStream outputStream = new FileStream(fileCopy,FileMode.Append))
                {
                    Copy(inputStream,outputStream);
                }
            }
        }
        static void Copy(Stream input, Stream output)
        {
            byte[] buffer = new byte[32 * 1024];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) != 0)
            {
                output.Write(buffer, 0, bytesRead);
            }
        }
    }
}
