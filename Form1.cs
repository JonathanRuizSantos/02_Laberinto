namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        int nfilas = 11;
        int ncol = 11;
        int x = 0;
        int y = 0;
        int[] Arreglo = new int[2];
        int[,] Laberinto = new int[11,11];
        int[] Coordenadas = new int[2];
        Queue<int[]> cola = new Queue<int[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void bt_Graphics_Click(object sender, EventArgs e)
        {
            Random k;
            k = new Random();
            int aleat, valor;
            Graphics g = pB.CreateGraphics();
            Pen lapiz = new Pen(Color.DarkBlue);
            Size s = new System.Drawing.Size(50, 50);
            //SolidBrush brocha = new SolidBrush(Color.AliceBlue);
            Image pasto = Image.FromFile(@"pasto.bmp");
            //             Bitmap image1 = (Bitmap) Image.FromFile(@"pasto.bmp", true);
            //             TextureBrush pasto = new TextureBrush(image1);
            Image pared = Image.FromFile(@"pared.bmp");

            //             Bitmap image2 = (Bitmap)Image.FromFile(@"pared.bmp", true);
            //            TextureBrush pared = new TextureBrush(image2);
            //             Bitmap image3 = Bitmap(Image.FromFile(@"entrada.bmp", true), s);
            Image entrada = Image.FromFile(@"entrada.bmp");

            //             Bitmap image3 = (Bitmap)Image.FromFile(@"entrada.bmp", true);
            //            TextureBrush entrada = new TextureBrush(image3);

            //TextureBrush textura;
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
                    //                    g.DrawRectangle(lapiz, r[i, j]);
                    //                    g.FillRectangle(textura, r[i, j]);
                    g.DrawImage(textura, r[i, j]);
                    p.X += 50;
                }

                p.X = 0;
                p.Y += 50;
            }

        }

        private void btSolucion_Click(object sender, EventArgs e)
        {
            
            Arreglo[0] = 0;
            Arreglo[1] = 0;
            cola.Enqueue(Arreglo);
            while(cola.Count() > 0) 
            {
                Coordenadas = cola.Dequeue();
                x = Coordenadas[0];
                y = Coordenadas[1];

                for(int Edo = 0; Edo < 4; Edo++)
                {
                    if (Edo == 0 && x != 0 && Laberinto[x - 1, y] == 0)
                    {
                        x = Coordenadas[x - 1];
                        y = Coordenadas[y];
                        guardado_Cola();
                    }
                    else if (Edo == 1 && x != 10 && Laberinto[x + 1, y] == 0)
                    {
                        x = Coordenadas[x + 1];
                        y = Coordenadas[y];
                        guardado_Cola();
                    }
                    else if (Edo == 2 && y != 0 && Laberinto[x, y - 1] == 0)
                    {
                        x = Coordenadas[x];
                        y = Coordenadas[y - 1];
                        guardado_Cola();
                    }
                    else if (Edo == 3 && y != 10 && Laberinto[x, y + 1] == 0)
                    {
                        x = Coordenadas[x];
                        y = Coordenadas[y + 1];
                        guardado_Cola();
                    }
                }

                imprime_Cola();
                
            }
            
            
        }

        public void imprime_Cola()
        {
            string suma = "";
            foreach (int[] i in cola)
            {
                suma += i.ToString();
            }
            lbCola.Items.Add(". " + suma);
        }
        public void guardado_Cola()
        {
            if (x == 10 && y == 10)
            {
                MessageBox.Show("El laberinto tiene solucion");
            }
            else
            {
                Arreglo[0] = x;
                Arreglo[1] = y;
                cola.Enqueue(Arreglo);
            }
        }
        
    }
}