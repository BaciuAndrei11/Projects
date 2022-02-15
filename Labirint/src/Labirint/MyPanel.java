package Labirint;

import java.awt.Button;
import java.awt.Dimension;
import java.awt.Toolkit;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JFrame;
import javax.swing.SwingUtilities;



public class MyPanel {
	public static void initializarePanel() {
		 Labirint fereastra = new Labirint();
	     Button buton = new Button();
	     buton.setSize(150, 50);
	     buton.setLabel("Afisare drumuri");
	     buton.addActionListener( new ActionListener() {

	          public void actionPerformed(ActionEvent ae) {

	             fereastra.apasat();
	         }
	     });
		 JFrame frame = new JFrame("Algoritmica Grafurilor");
		 frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		 frame.setSize(500, 500);
	     frame.add(buton);
	     frame.add(fereastra);
		 frame.setVisible(true);
	}
	public static void main (String[] args) {

        SwingUtilities.invokeLater( new Runnable() {

            public void run() {

            	initializarePanel();
            }
        });
    }
}