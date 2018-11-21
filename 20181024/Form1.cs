using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _20181024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //*****************Global Variables********************
        int n;
        int NA=0;
        double[,] a, d = new double[100, 101];
        double ep =0.0000000001;
        //*****************set equation***************************
        void SetEquation()
        {
            int i, j;
            n = 3;
            //n = 4;
            //a = new double[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 2.0, 1.0, -3.0, 5.0, 7.0 }, { 0, 4.0, 2.0, 1.0, -1.0, -1.0 }, { 0, 1.0, 1.0, 1.0, 2.0, 4.5 }, { 0, 1.0, 0.5, -1.5, 2.5, 3.0 } };
            //a = new double[,] { { 0, 0, 0, 0, 0, 0 }, { 0, 1.0, 1.0, -3.0, 5.0, 7.0 }, { 0, 4.0, 2.0, 1.0, -1.0, -1.0 }, { 0, 1.0, 1.0, 1.0, 2.0, 4.5 }, { 0, 1.0, 0.5, -1.5, 2.5, 3.0 } };
            a = new double[,] { { 0, 0, 0, 0, 0 }, { 0, 2.0, 4.0, 2.0, 2.0 }, { 0, 1.0, 2.0, 5.0, -11.0}, { 0, 3.0, -1.0, -1.0, 8.0}};
            //a = new double[,] { { 0, 0, 0, 0, 0 }, { 0, 2.0, 4.0, -8.0, -6.0 }, { 0, 1.0, -1.0, 2.0, 6.0 }, { 0, 3.0, 1.0, 1.0, 12.0 } };
            //*****************************Copy a to d*****************************
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n + 1; j++)
                {
                    d[i, j] = a[i, j];
                }
            }
        }
        //******************dispequation*******************************
        void DispEquation()
        {
            int i, j;
            Trace.WriteLine("n=" + n);
            for (i = 1; i <= n; i++)
            {
                for (j = 1; j <= n + 1; j++)
                {
                    Trace.Write(a[i, j] + " ");
                }
                Trace.WriteLine("");
            }
        }

        //*****************change*****************************
        void change(int q, int r)
        {
            double tmp;
            for (int i = 1; i <= n + 1; i++)
            {
                tmp = a[r, i];
                a[r, i] = a[q, i];
                a[q, i] = tmp;
            }
        }
        //****************i[]divt***************************
        void div(int i, double t)
        {
            for (int j = 1; j <= n + 1; j++)
            {
                a[i, j] = a[i, j] / t;
            }
        }

        //*****************i[]multiplust**********************

        void multi(int i,int j, double t)
        {
            for (int k = 1; k <= n + 1; k++)
            {
                a[j, k] = a[j, k] + a[i, k] * t;
            }
        }

        //*******************KENZAN(´･_･`)*****************************
        void KENZAN()
        {
            int k, l;
            double ans = 0;
            for(k=1;k<= n; k++)
            {
                ans = 0;
                for (l = 1; l <= n; l++)
                {
                    ans = ans + d[k, l]* a[l,n+1];
                }
                if ((ans+ep > d[k, n + 1]) && (ans-ep<d[k,n+1]))
                {
                    Trace.WriteLine("検算結果・・・"+ans+" "+k + "行目検算OK");
                }
                else
                {
                    Trace.WriteLine("検算結果・・・" + ans + " " + k + "行目検算NG");
                }
            }
        }
        //*****************main****************************************
        void main()
        {
            int i, j, k, p = 0;
            double t, u;
            for (i = 1; i <= n; i++)
            {
                p = 0;
                //DispEquation();
                if (a[i, i] == 0)
                {
                    for (k = i; k <= n; k++)
                    {
                        if (a[k, i] != 0)
                        {
                            change(i, k);
                            p = 1;
                        }
                    }
                    if (p == 0)
                    {
                        Trace.WriteLine("解なし(´･_･`)");
                        NA = 1;
                    }
                }
                t = a[i, i];
                div(i, t);
                for (j = 1; j <= n; j++)
                {
                    if (j != i)
                    {
                        u = -a[j, i];
                        multi(i,j, u);
                    }
                }
            }
        }

        //****************************************************
        private void button1_Click(object sender, EventArgs e)
        {
            NA = 0;
            SetEquation();
            DispEquation();
            main();
            if (NA != 1)
            {
                DispEquation();
                KENZAN();
            }
        }
    }
}
