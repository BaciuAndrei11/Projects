package Labirint;
import java.awt.Graphics;
import java.awt.Color;
import java.io.File;
import java.util.*;
import javax.swing.JPanel;

public class Labirint extends JPanel {

    enum Culori {
        Alb,
        Albastru,
        Negru,
        Rosu,
        Verde
    }

    private Vector<Vector<Integer>> matriceIntrare = new Vector<Vector<Integer>>();
    private Vector<Vector<Integer>> matriceNoduri = new Vector<Vector<Integer>>();
    private Vector<Vector<Integer>> listaAdiacenta = new Vector<Vector<Integer>>();
    private Vector<Integer> iesiri = new Vector<Integer>();
    private Vector<Vector<Culori>> noduriColorate = new Vector<Vector<Culori>>();
    private int numarNod = 0;
    private int nodStart;
    private boolean apasat = false;
    private Vector<Integer> p = new Vector<Integer>();

    public Labirint() {

        citireMatrice();
        creareMatriceNoduri();
        creareListaAdiacenta();
        repaint();
    }

    public void apasat() {
        apasat = true;
        PBF();
    }

    public void citireMatrice() {

        File fisier = new File("src/Labirint/Labirint.txt");
        try {
            Scanner citire = new Scanner(fisier);
            int numarLinii = citire.nextInt();
            int numarColoane = citire.nextInt();
            for (int linie = 0; linie < numarLinii; linie++) {
                Vector<Integer> vectorLinie = new Vector<Integer>();
                for (int nod = 0; nod < numarColoane; nod++) {
                    int numarNod = citire.nextInt();
                    vectorLinie.add(numarNod);
                }
                matriceIntrare.add(vectorLinie);
            }
            citire.close();
        } catch (Exception exceptie) {
            System.out.println("A aparut o eroare!");
        }
    }

    public void creareMatriceNoduri() {

        for (int linie = 0; linie < matriceIntrare.size(); linie++) {
            Vector<Integer> vectorLinie = new Vector<Integer>();
            Vector<Culori> culoriVector = new Vector<Culori>();
            for (int coloana = 0; coloana < matriceIntrare.get(linie).size(); coloana++) {
                if (matriceIntrare.get(linie).get(coloana) != 0) {
                    numarNod++;
                    vectorLinie.add(numarNod);
                    if (matriceIntrare.get(linie).get(coloana) == 2) {
                        nodStart = numarNod;
                    }
                    if (matriceIntrare.get(linie).get(coloana) == 3) {
                        iesiri.add(numarNod);
                    }
                } else {
                    vectorLinie.add(0);
                }
                culoriVector.add(Culori.Alb);
            }
            noduriColorate.add(culoriVector);
            matriceNoduri.add(vectorLinie);
        }
    }

    public void creareListaAdiacenta() {

        for (int indiceNod = 0; indiceNod < numarNod; indiceNod++) {
            Vector<Integer> vectorAuxiliar = new Vector<Integer>();
            listaAdiacenta.add(vectorAuxiliar);
        }
        for (int linie = 0; linie < matriceNoduri.size(); linie++) {
            for (int coloana = 0; coloana < matriceNoduri.get(linie).size(); coloana++) {
                if (matriceNoduri.get(linie).get(coloana) != 0) {
                    if (linie > 0 && matriceNoduri.get(linie - 1).get(coloana) != 0) {
                        listaAdiacenta.get(matriceNoduri.get(linie - 1).get(coloana) - 1).add(matriceNoduri.get(linie).get(coloana));
                    }
                    if (linie < matriceNoduri.size() - 1 && matriceNoduri.get(linie + 1).get(coloana) != 0) {
                        listaAdiacenta.get(matriceNoduri.get(linie + 1).get(coloana) - 1).add(matriceNoduri.get(linie).get(coloana));
                    }
                    if (coloana > 0 && matriceNoduri.get(linie).get(coloana - 1) != 0) {
                        listaAdiacenta.get(matriceNoduri.get(linie).get(coloana - 1) - 1).add(matriceNoduri.get(linie).get(coloana));
                    }
                    if (coloana < matriceNoduri.get(linie).size() - 1 && matriceNoduri.get(linie).get(coloana + 1) != 0) {
                        listaAdiacenta.get(matriceNoduri.get(linie).get(coloana + 1) - 1).add(matriceNoduri.get(linie).get(coloana));
                    }
                }
            }
        }
    }

    private void PBF() {

        int inf = Integer.MAX_VALUE;
        Vector<Boolean> U = new Vector<Boolean>();
        Vector<Integer> V = new Vector<Integer>();
        Vector<Integer> W = new Vector<Integer>();
        Vector<Integer> l = new Vector<Integer>();
        for (int indice = 0; indice < listaAdiacenta.size(); indice++) {
            p.add(0);
            l.add(inf);
            U.add(false);
        }
        U.set(nodStart - 1, true);
        V.add(nodStart);
        W = new Vector<Integer>();
        l.set(nodStart - 1, 0);
        while (V.size() != 0) {
            int x = V.firstElement();
            for (int y : listaAdiacenta.get(x - 1)) {
                if (U.get(y - 1) == false) {
                    U.set(y - 1, true);
                    V.add(y);
                    p.set(y - 1, x);
                    l.set(y - 1, l.get(x - 1) + 1);
                    if (iesiri.contains(y)) {
                        existaDrum(y);
                    }
                }
            }
            V.remove(V.firstElement());
            W.add(x);
        }
        repaint();
    }

    private void existaDrum(int iesire) {
        while (iesire != nodStart) {
            for (int linie = 0; linie < matriceNoduri.size(); linie++) {
                for (int coloana = 0; coloana < matriceNoduri.get(linie).size(); coloana++) {
                    if (matriceNoduri.get(linie).get(coloana) == iesire) {
                        noduriColorate.get(linie).set(coloana,Culori.Verde);
                        break;
                    }
                }
            }
            iesire = p.get(iesire - 1);
        }
    }

    protected void paintComponent(Graphics grafica) {
        super.paintComponent(grafica);
        if (apasat == false) {
            for (int linie = 0; linie < matriceIntrare.size(); linie++) {
                for (int coloana = 0; coloana < matriceIntrare.get(linie).size(); coloana++) {
                    if (matriceIntrare.get(linie).get(coloana) == 0) {
                        noduriColorate.get(linie).set(coloana, Culori.Negru);
                        grafica.setColor(Color.BLACK);
                        grafica.fillRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                        grafica.setColor(Color.BLACK);
                        grafica.drawRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                    } else if (matriceIntrare.get(linie).get(coloana) == 2) {
                        noduriColorate.get(linie).set(coloana, Culori.Albastru);
                        grafica.setColor(Color.BLUE);
                        grafica.fillRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                        grafica.setColor(Color.BLACK);
                        grafica.drawRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                    } else if (matriceIntrare.get(linie).get(coloana) == 1) {
                        noduriColorate.get(linie).set(coloana, Culori.Alb);
                        grafica.setColor(Color.WHITE);
                        grafica.fillRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                        grafica.setColor(Color.BLACK);
                        grafica.drawRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                    }else if (matriceIntrare.get(linie).get(coloana) == 3) {
                        noduriColorate.get(linie).set(coloana, Culori.Rosu);
                        grafica.setColor(Color.RED);
                        grafica.fillRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                        grafica.setColor(Color.BLACK);
                        grafica.drawRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                    }
                }
            }
        } else {
            for (int linie = 0; linie < matriceNoduri.size(); linie++) {
                for (int coloana = 0; coloana < matriceNoduri.get(linie).size(); coloana++) {
                    switch (noduriColorate.get(linie).get(coloana)) {
                        case Alb:
                            grafica.setColor(Color.WHITE);
                            break;
                        case Negru:
                            grafica.setColor(Color.BLACK);
                            break;
                        case Albastru:
                            grafica.setColor(Color.BLUE);
                            break;
                        case Rosu:
                            grafica.setColor(Color.RED);
                            break;
                        case Verde:
                            grafica.setColor(Color.GREEN);
                            break;
                        default:
                            break;
                    }
                    grafica.fillRect(50 * coloana + 100, 50 * linie + 100, 50, 50);
                    grafica.setColor(Color.BLACK);
                    grafica.drawRect(50 * coloana + 100, 50 * linie + 100,50, 50);
                }
            }
        }
    }
}
