using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Fig8 : Figure
    {
        public Fig8()
        {
            fig = new bool[3, 3];
            x = 0;
            y = 0;
            for (int i = 0; i < 3; i++)
            {
                fig[i, 1] = true;
                fig[1, i] = true;
            }
        }
        public Fig8(Figure f) : base(f) { }
        public override void Right(DataGridView dg)
        {
            if (y + 3 != dg.ColumnCount && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 3, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x].Style.BackColor.Equals(Color.Beige))
            {
                this.Remove(dg);
                y++;
                this.Show(dg);
            }
        }

        public override bool IsTouching(DataGridView dg)
        {
            if (x + 3 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige) || !dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige))
                return true;
            return false;
        }

        public override void Left(DataGridView dg)
        {
            if (y != 0 && dg[y, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige))
            {
                this.Remove(dg);
                y--;
                this.Show(dg);
            }
        }

        public override bool Fallen(DataGridView dg)
        {
            if (IsTouching(dg)) return false;
            this.Remove(dg);
            x++;
            this.Show(dg);
            return true;
        }

        public override void Show(DataGridView dg)
        {
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    if (fig[i - x, j - y] && !dg[j, i].Style.BackColor.Equals(Color.Beige))
                    {
                        End();
                    }
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.Red;
                }
            }
        }

        public override void Rotate(DataGridView dg)
        {
            return;
        }

        public override void Remove(DataGridView dg)
        {
            for (int i = x; i < x + 3; i++)
            {
                for (int j = y; j < y + 3; j++)
                {
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.Beige;
                }
            }
        }
    }
}
