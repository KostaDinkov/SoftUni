/**
 * Software University
 * Course : Java Basics
 * Lecture: Loops, Methods, Classes
 * Problem: 11.Excel
 * Description:
 * Each office puts in this Excel file all their incomes
 * (office, date, description, income, 20% VAT, total income).
 * Your task is to read the report and to calculate the incomes
 * sub-totals for each office (with VAT). Order the offices alphabetically.
 * Print the result at the console in format town Total -> incomes.
 * Finally calculate and print the grand total (the sum of all incomes in all offices)
 * Created  on 05-09-2014.
 */

/*
IMPORTANT !!!
Due to the big size of the library used to work with Excel documents I have excluded it
from the homework zip archive. In order for this class to work, you have to manually download and extract this file:
http://www.apache.org/dyn/closer.cgi/poi/release/bin/poi-bin-3.10.1-20140818.zip
DIRECTLY into \Homework\Problem11_Files\poi-3.10.1
*/

import java.io.*;
import java.util.*;

import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

public class Problem11_Excel {
    public static void main(String[] args) {
        Map<String,Double> incomeList = new HashMap<String, Double>();
        try{
            FileInputStream file = new FileInputStream(new File("Problem11_Files\\3. Incomes-Report.xlsx"));
            XSSFWorkbook workbook = new XSSFWorkbook(file);
            XSSFSheet sheet = workbook.getSheetAt(0);
            int rowCount = sheet.getPhysicalNumberOfRows();

            for (int i = 1; i < rowCount; i++) {
                Row row = sheet.getRow(i);
                String office = row.getCell(0).getStringCellValue();
                double totalIncome = row.getCell(3).getNumericCellValue()* 1.2;

                if (incomeList.containsKey(office)) {
                    incomeList.put(office, incomeList.get(office) + totalIncome);
                }
                else {
                    incomeList.put(office,totalIncome);
                }
            }
            SortedSet<String> keys = new TreeSet<String>(incomeList.keySet());
            double totalSum = 0;
            for (String key: keys){
                double officeTotal = incomeList.get(key);
                totalSum = totalSum + officeTotal;
                System.out.printf("%s Total -> %.2f \n",key,officeTotal);
            }
            System.out.printf("Grand Total -> %.2f", totalSum);
        }
        catch (Exception e) {
            e.printStackTrace();
        }
    }

}
