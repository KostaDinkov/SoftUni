﻿//SoftUni
//Course:   Advanced C#
//Lecture:  Streams and Files
//Problem:  5. Slicing File  
//          Write a program that takes any file and 
//          slices it to n parts.Write the following methods:
//          •	Slice(string sourceFile, string destinationDirectory, int parts) - 
//              slices the given source file into n parts and saves them in destinationDirectory.
//          •	Assemble(List<string> files, string destinationDirectory) - 
//              combines all files into one, in the order they are passed, 
//              and saves the result in destinationDirectory
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Slice(string sourcefile, string destinationDirectory, int parts)
        {
            
        }
        public bool SplitFile(string SourceFile, int nNoofFiles)
        {
            bool Split = false;
            try
            {
                FileStream fs = new FileStream(SourceFile, FileMode.Open, FileAccess.Read);
                int SizeofEachFile = (int)Math.Ceiling((double)fs.Length / nNoofFiles);
                for (int i = 0; i < nNoofFiles; i++)
                {
                    string baseFileName = Path.GetFileNameWithoutExtension(SourceFile);
                    string Extension = Path.GetExtension(SourceFile);
                    FileStream outputFile = new FileStream(Path.GetDirectoryName(SourceFile) + "\\" + baseFileName + "." +
                        i.ToString().PadLeft(5, Convert.ToChar("0")) + Extension + ".tmp", FileMode.Create, FileAccess.Write);
                    mergeFolder = Path.GetDirectoryName(SourceFile);
                    int bytesRead = 0;
                    byte[] buffer = new byte[SizeofEachFile];
                    if ((bytesRead = fs.Read(buffer, 0, SizeofEachFile)) > 0)
                    {
                        outputFile.Write(buffer, 0, bytesRead);
                        //outp.Write(buffer, 0, BytesRead);
                        string packet = baseFileName + "." + i.ToString().PadLeft(3, Convert.ToChar("0")) + Extension.ToString();
                        Packets.Add(packet);
                    }
                    outputFile.Close();
                }
                fs.Close();
            }
            catch (Exception Ex)
            {
                throw new ArgumentException(Ex.Message);
            }

            return Split;
        }
        public bool MergeFile(string inputfoldername1)
        {
            bool Output = false;
            try
            {
                string[] tmpfiles = Directory.GetFiles(inputfoldername1, "*.tmp");
                FileStream outPutFile = null;
                string PrevFileName = "";
                foreach (string tempFile in tmpfiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(tempFile);
                    string baseFileName = fileName.Substring(0, fileName.IndexOf(Convert.ToChar(".")));
                    string extension = Path.GetExtension(fileName);
                    if (!PrevFileName.Equals(baseFileName))
                    {
                        if (outPutFile != null)
                        {
                            outPutFile.Flush();
                            outPutFile.Close();
                        }
                        outPutFile = new FileStream(SaveFileFolder + "\\" + baseFileName + extension, FileMode.OpenOrCreate, FileAccess.Write);
                    }
                    int bytesRead = 0;
                    byte[] buffer = new byte[1024];
                    FileStream inputTempFile = new FileStream(tempFile, FileMode.OpenOrCreate, FileAccess.Read);
                    while ((bytesRead = inputTempFile.Read(buffer, 0, 1024)) > 0)
                        outPutFile.Write(buffer, 0, bytesRead);
                    inputTempFile.Close();
                    File.Delete(tempFile);
                    PrevFileName = baseFileName;
                }
                outPutFile.Close();
                
            }
            catch
            {
            }
            return Output;
        }
    }
}
