using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int nfilas = 11;
        int ncol = 11;
        string[] corte_coor;
        int x;
        int y;
        int Arreglo_0;
        int Arreglo_1;
        string Arreglo_01;
        int[,] Laberinto = new int[11, 11];
        object Coordenadas;
        int[] Coor = new int[2];
        string estado = "";
        string Coor_cadena = "";
        Queue cola = new Queue();
        Stack pila = new Stack();

        public Form1()
        {
            InitializeComponent();
        }

        // ******************************************************************************* BOTON GRAFICOS
        private void bt_Graphics_Click(object sender, EventArgs e)
        {
            Random k;
            k = new Random();
            int aleat, valor;
            Graphics g = pB.CreateGraphics();
            Pen lapiz = new Pen(Color.DarkBlue);
            Size s = new System.Drawing.Size(50, 50);
            Image pasto = Image.FromFile(@"pasto.bmp");
            Image pared = Image.FromFile(@"pared.bmp");
            Image entrada = Image.FromFile(@"entrada.bmp");
            Image textura;
            Point p = new Point(0, 0);
            Rectangle[,] r;
            r = new Rectangle[nfilas, ncol];
            for (int i = 0; i < nfilas; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    if ((i == 0 && j == 0) || (i == nfilas - 1 && j == ncol - 1))
                    {
                        if (i == 0)
                            textura = entrada;
                        else
                            textura = pasto;
                        valor = 0;
                    }
                    else
                    {
                        if (i % 2 == 0 && j % 2 != 0)
                        {
                            textura = pasto;
                            valor = 0;
                        }
                        else
                        {
                            aleat = k.Next(2);
                            if (aleat == 0)
                                textura = pasto;
                            else
                                textura = pared;
                            valor = aleat;
                        }
                    }
                    Laberinto[i, j] = valor;
                    r[i, j].Location = p;
                    r[i, j].Size = s;
                    g.DrawImage(textura, r[i, j]);
                    p.X += 50;
                }

                p.X = 0;
                p.Y += 50;
            }

        }

        // **************************************************************************** BOTON SOLUCION
        private void btSolucion_Click(object sender, EventArgs e)
        {
            // --------------------------------------  SOLUCION DE LA COLA

            string aux_coor;
            limpia_variables();

            Arreglo_0 = 0;
            Arreglo_1 = 0;
            Arreglo_01 = Arreglo_0.ToString() + "," + Arreglo_1.ToString();
            estado = estado + Arreglo_01 + "-";
            Coor_cadena = Arreglo_0.ToString() + "," + Arreglo_1.ToString();
            cola.Enqueue(Arreglo_01);
            imprime_Cola();

            while (cola.Count > 0)
            {
                Coordenadas = cola.Dequeue();
                aux_coor = Coordenadas.ToString() + "-";
                corte_coor = aux_coor.Split(',', '-');
                x = int.Parse(corte_coor[0]);
                y = int.Parse(corte_coor[1]);

                for (int Edo = 0; Edo < 4; Edo++)
                {
                    
                    if (Edo==0 && x>0 && Laberinto[x-1,y]==0)
                    {
                        Coor[0] = x-1;
                        Coor[1] = y;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Cola();
 
                    }
                    else if (Edo==1 && x<10 && Laberinto[x+1,y]==0)
                    {
                        Coor[0] = x+1;
                        Coor[1] = y;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Cola();
                    }
                    else if (Edo==2 && y>0 && Laberinto[x,y-1] == 0)
                    {
                        Coor[0] = x;
                        Coor[1] = y-1;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Cola();
                    }
                    else if (Edo==3 && y<10 && Laberinto[x,y+1]==0)
                    {
                        Coor[0] = x;
                        Coor[1] = y+1;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Cola();
                    }
                }

                imprime_Cola();
                if (cola.Count < 1 && (Coor[0]!=10 || Coor[1]!=10))
                {
                    MessageBox.Show("El laberinto no tiene solucion por Cola");
                }
                else if(Coor[0] == 10 && Coor[1] == 10)
                {
                    MessageBox.Show("Solucion Encontrada con lista tipo Cola");
                    //cola.Clear();
                    break;
                }

            }

            // --------------------------------------  SOLUCION DE LA PILA
            estado = "";
            Coor_cadena = "";

            Arreglo_0 = 0;
            Arreglo_1 = 0;
            Arreglo_01 = Arreglo_0.ToString() + "," + Arreglo_1.ToString();
            estado = estado + Arreglo_01 + "-";
            Coor_cadena = Arreglo_0.ToString() + "," + Arreglo_1.ToString();
            pila.Push(Arreglo_01);
            imprime_Pila();

            while (pila.Count > 0)
            {
                Coordenadas = pila.Pop();
                aux_coor = Coordenadas.ToString() + "-";
                corte_coor = aux_coor.Split(',', '-');
                x = int.Parse(corte_coor[0]);
                y = int.Parse(corte_coor[1]);

                for (int Edo = 0; Edo < 4; Edo++)
                {

                    if (Edo == 0 && x > 0 && Laberinto[x - 1, y] == 0)
                    {
                        Coor[0] = x - 1;
                        Coor[1] = y;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Pila();


                    }
                    else if (Edo == 1 && x < 10 && Laberinto[x + 1, y] == 0)
                    {
                        Coor[0] = x + 1;
                        Coor[1] = y;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Pila();
                    }
                    else if (Edo == 2 && y > 0 && Laberinto[x, y - 1] == 0)
                    {
                        Coor[0] = x;
                        Coor[1] = y - 1;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Pila();
                    }
                    else if (Edo == 3 && y < 10 && Laberinto[x, y + 1] == 0)
                    {
                        Coor[0] = x;
                        Coor[1] = y + 1;
                        Coor_cadena = Coor[0].ToString() + "," + Coor[1].ToString();
                        guardado_Pila();
                    }
                }

                imprime_Pila();
                if (pila.Count < 1 && (Coor[0] != 10 || Coor[1] != 10))
                {
                    MessageBox.Show("El laberinto no tiene solucion por Pila");
                }
                else if (Coor[0] == 10 && Coor[1] == 10)
                {
                    MessageBox.Show("Solucion Encontrada con lista tipo Pila");
                    //pila.Clear();
                    break;

                }

            }
        }

        // *********************************************************************************** FUNCIONES
        public void imprime_Cola()
        {
            string suma = "";
            foreach (object ind in cola)
            {
                suma = suma + ind + "-";
            }
            lbCola.Items.Add(suma);
        }
        public void guardado_Cola()
        {
            
            if (Coor[0] <= 10 && Coor[1] <= 10 && estado.Contains(Coor_cadena) == false && cola.Contains(Coor) == false)
            {
                Arreglo_0 = Coor[0];
                Arreglo_1 = Coor[1];
                Arreglo_01 = Arreglo_0 + "," + Arreglo_1;
                estado = estado + Arreglo_01 + "-";
                cola.Enqueue(Arreglo_01);
            }
        }
        public void limpia_variables()
        {
            lbCola.Items.Clear();
            lbPila.Items.Clear();
            cola.Clear();
            pila.Clear();
            estado = "";
            Coor_cadena = "";
        }

        public void imprime_Pila()
        {
            string suma = "";
            foreach (object ind in pila)
            {
                suma = suma + ind + "-";
            }
            lbPila.Items.Add(suma);
        }

        public void guardado_Pila()
        {

            if (Coor[0] <= 10 && Coor[1] <= 10 && estado.Contains(Coor_cadena) == false && pila.Contains(Coor) == false)
            {
                Arreglo_0 = Coor[0];
                Arreglo_1 = Coor[1];
                Arreglo_01 = Arreglo_0 + "," + Arreglo_1;
                estado = estado + Arreglo_01 + "-";
                pila.Push(Arreglo_01);

            }
        }

    }
}