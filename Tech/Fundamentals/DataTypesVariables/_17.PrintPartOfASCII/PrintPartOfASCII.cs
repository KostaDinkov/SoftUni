﻿using System;
 
 
 class PrintPartOfASCII
 {
     static void Main()
     {
         int start = int.Parse(Console.ReadLine());
         int end = int.Parse(Console.ReadLine());
 
         for (int i = start; i <= end; i++)
         {
             Console.Write((char) i + " ");
         }
 
         Console.WriteLine();
     }
 }