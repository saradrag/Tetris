using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Fig5 : Figure
    {

        public Fig5()
        {
            fig = new bool[2, 2];
            x = 0;
            y = 0;
            for (int i = 0; i < 2; i++)
            {
                fig[i, 0] = true;
                fig[i, 1] = true;
            }
        }
        public Fig5(Figure f) : base(f) { }
        public override void Right(DataGridView dg)
        {
            if (y + 2 != dg.ColumnCount && dg[y + 2, x].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige))
            {
                this.Remove(dg);
                y++;
                this.Show(dg);
            }
        }

        public override bool IsTouching(DataGridView dg)
        {
            if (x + 2 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige))
                return true;
            return false;
        }

        public override void Left(DataGridView dg)
        {
            if (y != 0 && dg[y - 1, x].Style.BackColor.Equals(Color.Beige) && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige))
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
            for (int i = x; i < x + 2; i++)
            {
                for (int j = y; j < y + 2; j++)
                {
                    if (fig[i - x, j - y] && !dg[j, i].Style.BackColor.Equals(Color.Beige))
                    {
                        End();
                    }
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.Gold;
                }
            }
        }

        public override void Rotate(DataGridView dg)
        {
            return;
        }

        public override void Remove(DataGridView dg)
        {
            for (int i = x; i < x + 2; i++)
            {
                for (int j = y; j < y + 2; j++)
                {
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.Beige;
                }
            }
        }
    }
}
