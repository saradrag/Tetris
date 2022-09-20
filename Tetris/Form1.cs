using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataGridView dg1, dg2;
        public bool b = false;
        Figure f1, f2;

        Random r;
        int rand;

        private void b1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            f1 = Figure.MakeNew(r.Next(1, 9));
            timer1.Enabled = true;
            f1.Show(dg1);
            rand = r.Next(1, 9);
            f2 = Figure.MakeNew(rand);
            f2.Show(dg2);


        }
        public void EndGame()
        {
            timer1.Stop();
        }



        public void NextFigure(DataGridView dg)
        {
            rand = r.Next(1, 9);
            f2 = Figure.MakeNew(rand);
            f2.Show(dg);
        }
        public void Clear(DataGridView dg)
        {
            bool any = false;
            bool all = true;
            for (int i = dg.RowCount - 1; i >= 0; i--)
            {
                for (int j = dg.ColumnCount - 1; j >= 0; j--)
                {
                    if (!dg[j, i].Style.BackColor.Equals(Color.Beige))
                    {
                        any = true;
                    }
                    else
                    {
                        all = false;
                    }
                }
                if (all)
                {
                    for (int j = i; j > 0; j--)
                    {
                        for (int k = 0; k < dg.ColumnCount; k++)
                        {
                            dg[k, j].Style.BackColor = dg[k, j - 1].Style.BackColor;
                        }
                    }
                    for (int k = 0; k < dg.ColumnCount; k++)
                    {
                        dg[k, 0].Style.BackColor = Color.Beige;
                    }
                    i++;
                }
                if (!any) break;
                all = true;
                any = false;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Down))
            {
                timer1.Stop();
                while (f1.Fallen(dg1))
                {
                }
                f1 = Figure.MakeNew(rand);
                Clear(dg1);
                f1.Show(dg1);
                f2.Remove(dg2);
                NextFigure(dg2);
                timer1.Start();
            }
            if (e.KeyCode.Equals(Keys.Up))
            {
                f1.Rotate(dg1);
            }
            if (e.KeyCode.Equals(Keys.Left))
            {
                f1.Left(dg1);
            }
            if (e.KeyCode.Equals(Keys.Right))
            {
                f1.Right(dg1);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Figure.EndEvent += EndGame;
            if (!f1.Fallen(dg1))
            {
                f1 = Figure.MakeNew(rand);
                Clear(dg1);
                f1.Show(dg1);
                f2.Remove(dg2);
                NextFigure(dg2);
            }
        }

        private void dg1_SelectionChanged(Object sender, EventArgs e) => dg1.ClearSelection();
        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Random();
            this.Size = new Size(500, 600);
            this.Text = "The Game of Tetris";
            dg1 = new DataGridView();
            dg1.GridColor = Color.Black;
            dg1.ColumnCount = 10;
            dg1.RowCount = 20;

            dg1.RowHeadersVisible = false;
            dg1.ColumnHeadersVisible = false;
            for (int i = 0; i < dg1.RowCount; i++)
            {
                dg1.Rows[i].Height = 20;
            }
            for (int i = 0; i < dg1.ColumnCount; i++)
            {
                dg1.Columns[i].Width = 20;
            }
            for (int i = 0; i < dg1.ColumnCount; i++)
            {
                for (int j = 0; j < dg1.RowCount; j++)
                {
                    dg1[i, j].Style.BackColor = Color.Beige;
                }
            }
            dg1.Width = dg1.ColumnCount * 20 + 3;
            dg1.Height = dg1.RowCount * 20 + 3;
            dg1.Top = 50;
            dg1.Left = 50;
            Controls.Add(dg1);

            dg2 = new DataGridView();
            dg2.GridColor = Color.Black;
            dg2.ColumnCount = 4;
            dg2.RowCount = 4;
            dg2.RowHeadersVisible = false;
            dg2.ColumnHeadersVisible = false;
            for (int i = 0; i < dg2.RowCount; i++)
            {
                dg2.Rows[i].Height = 20;
            }
            for (int i = 0; i < dg2.ColumnCount; i++)
            {
                dg2.Columns[i].Width = 20;
            }
            for (int i = 0; i < dg2.ColumnCount; i++)
            {
                for (int j = 0; j < dg2.RowCount; j++)
                {
                    dg2[i, j].Style.BackColor = Color.Beige;
                }
            }
            dg2.Width = dg2.ColumnCount * 20 + 3;
            dg2.Height = dg2.RowCount * 20 + 3;
            dg2.Top = 370;
            dg2.Left = 300;
            Controls.Add(dg2);
            b1.Top = 70;
            b1.Left = 300;
            b1.Text = "Start";
            dg1.KeyDown += new KeyEventHandler(Form1_KeyDown);
            dg2.KeyDown += new KeyEventHandler(Form1_KeyDown);
            dg1.AllowUserToResizeRows = false;
            dg1.AllowUserToResizeColumns = false;
            dg1.Enabled = false;
            dg1.ReadOnly = true;
            DataGridViewCellStyle st = new DataGridViewCellStyle();
            st.SelectionBackColor = Color.Transparent;
            dg2.DefaultCellStyle = st;


        }
    }
}
