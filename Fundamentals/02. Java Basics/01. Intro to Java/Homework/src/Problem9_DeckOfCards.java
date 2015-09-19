/**
 * Software University
 * Course : Java Basics
 * Lecture: Introduction to Java
 * Problem: 9. Generate a PDF by external library
 * Description:
 * Write a program to generate a PDF document called Deck-of-Cards.pdf and print in it a
 * standard deck of 52 cards, following one after another. Each card should be a rectangle
 * holding its face and suit. A few examples are shown below:
 * You are free to choose the size of each card, the spacing between the cards, how many cards to put in each line, etc.
 * Note: you will need to use an external Java library for creating PDF documents. Find some in Internet.
 * Put your JAR files in a folder called "lib" (this is a standard approach in Java projects) and reference them in the build path.
 * Hint: solve the problem step by step:
 * 1.	Generate the deck of cards and print it at the console (the console in Eclipse fully supports Unicode).
 * 2.	Find a Java library for generating PDF documents and play with it. Try to print some string in a PDF document.
 * 3.	Print the cards in PDF file (without the rectangular border).
 * 4.	Try to change the colors of the red cards.
 * 5.	Try to add the rectangular border around each card, e.g. by putting tables in the PDF.
 * Created  on 14-8-24.
 */

//Note : Using the PDFJet library
//Note : The PDF file doesn't exist yet in the folder.
//       Run the current class to create the PDF 
import java.io.BufferedOutputStream;
import java.io.FileOutputStream;
import com.pdfjet.*;

public class Problem9_DeckOfCards {
    public Problem9_DeckOfCards() throws Exception {
        PDF pdf = new PDF(new BufferedOutputStream(new FileOutputStream("Cards.pdf")));
        Page page = new Page(pdf, Letter.LANDSCAPE);
        Font f1 = new Font(pdf,CoreFont.SYMBOL);
        f1.setSize(20);
        float posX = 10f;
        float posY = 70f;
        char color = ' ';

        for (int i = 0; i < 4; i++) {
            for (int j = 2; j < 15; j++) {

                Box card = new Box();
                TextLine symbol = new TextLine(f1);
                String cardNum=Integer.toString(j);

                if (j>=11){
                    switch (j){
                        case (11): cardNum = "J";
                            break;
                        case (12): cardNum = "Q";
                            break;
                        case (13): cardNum = "K";
                            break;
                        case (14): cardNum = "A";
                            break;
                    }
                }
                switch (i){
                    case(0): color = 0xAA;
                        symbol.setColor(Color.black);
                        break;
                    case(1): color = 0xA8;
                        symbol.setColor(Color.red);
                        break;
                    case(2): color = 0xA7;
                        symbol.setColor(Color.black);
                        break;
                    case(3): color = 0xA9;
                        symbol.setColor(Color.red);
                        break;
                }
                card.setLocation(posX,posY);
                card.setSize(55f,100f);
                card.drawOn(page);
                symbol.setText(cardNum+(color));
                symbol.placeIn(card, 15f, 50f);
                symbol.drawOn(page);
                posX += 60f;
            }
            posY +=125f;
            posX = 10f;
        }
        pdf.close();
    }

    public static void main(String[] args) {

        try {
            new Problem9_DeckOfCards();
            System.out.println("Creating file Cards.pdf in \\Homework directory");
        } catch (Exception e) {
            e.printStackTrace();
        }

    }

}
