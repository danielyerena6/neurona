using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace neurona
{
    public partial class Form1 : Form
    {
        int no_entradas;
        int rows;
        public Form1()
        {
            InitializeComponent();
            DataGridViewTextBoxColumn pesos = new DataGridViewTextBoxColumn();
            pesos.HeaderText = "Pesos"  ;
            pesos.Width = 50;
            dataGridView2.Columns.Add(pesos);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiar();
            int no_entradas = int.Parse(textBox1.Text);
            string numero;
            

            for (int i = 1; i <= no_entradas; i++)
            {
                DataGridViewTextBoxColumn entradas = new DataGridViewTextBoxColumn();
                entradas.HeaderText="X" + i.ToString();
                entradas.Width = 50;
                dataGridView1.Columns.Add(entradas);



            }

            DataGridViewTextBoxColumn salida = new DataGridViewTextBoxColumn();
            salida.HeaderText = "Y";
            salida.Width = 50;
            dataGridView1.Columns.Add(salida);

            rows = Convert.ToInt32(Math.Pow(2, no_entradas));
            

           for(int i=0;i<rows;i++)
            {
                numero = "";
                numero=deci_bin(i);
                


                while (numero.Length!=no_entradas)
                {
                    numero = "0" + numero;

                }


                
                dataGridView1.Rows.Add();
                for (int j = 0; j < numero.Length; j++)
                {
                    this.dataGridView1.Rows[i].Cells[j].Value = numero[j];

                }







            }

            
            





        }

        public string deci_bin(int deci)
        {
            
            String cadena = "";
            
            while (deci > 0)
                {
                    if (deci % 2 == 0)
                    {
                        cadena = "0" + cadena;
                    }
                    else
                    {
                        cadena = "1" + cadena;
                    }
                    deci = (int)(deci / 2);
                }

                
            
                return cadena;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x=0;
            int w=0;
            int umbral = int.Parse(textBox2.Text);
            int acumulador = 0;
            no_entradas = int.Parse(textBox1.Text);
            
            for (int i = 0; i < rows; i++)
            {
                acumulador = 0;
                



                
                for (int j = 0; j < no_entradas; j++)
                {
                    x = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString());
                    w = Convert.ToInt32(dataGridView2.Rows[j].Cells[0].Value);

                    acumulador += x * w;

                    Console.WriteLine(x);
                    Console.WriteLine(w);
                   



                }
                Console.WriteLine(acumulador+"\n");


                if (acumulador>umbral)
                {

                    dataGridView1.Rows[i].Cells[no_entradas].Value = 1;
                }
                else
                {
                    dataGridView1.Rows[i].Cells[no_entradas].Value = 0;
                }







            }

        }

        public void limpiar()
        {
            for (int i = 0; i < rows; i++)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView2.Rows.Clear();
                textBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiar();

        }
    }
}
