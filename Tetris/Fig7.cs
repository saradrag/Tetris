using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Fig7 : Figure
    {
        bool state;
        public Fig7()
        {
            fig = new bool[3, 3];
            x = 0;
            y = 0;
            state = false;
            fig[0, 1] = true;
            fig[0, 2] = true;
            fig[1, 0] = true;
            fig[1, 1] = true;
        }
        public Fig7(Figure f) : base(f)
        {
            state = false;
        }
        public override void Right(DataGridView dg)
        {
            if (state == false)
            {
                if (y + 3 != dg.ColumnCount && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 3, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
            else
            {
                if (y + 2 != dg.ColumnCount && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 1, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
        }

        public override bool IsTouching(DataGridView dg)
        {
            if (state == false)
            {
                if (x + 2 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            else
            {
                if (x + 3 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }

        }

        public override void Left(DataGridView dg)
        {
            if (state == false)
            {
                if (y != 0 && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
            }
            else
            {
                if (y != 0 && dg[y, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y - 1, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
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
                        dg[j, i].Style.BackColor = Color.Plum;
                }
            }
        }

        public override void Rotate(DataGridView dg)
        {
            if (state == false)
            {
                if (dg[y, x].Style.BackColor.Equals(Color.Beige) && x + 2 != dg.RowCount && dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 2] = false;
                    fig[0, 1] = false;
                    fig[0, 0] = true;
                    fig[2, 1] = true;
                    state = true;
                    this.Show(dg);
                }
            }
            else
            {
                if (dg[y + 1, x].Style.BackColor.Equals(Color.Beige) && y + 2 != dg.ColumnCount && dg[y + 2, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 2] = true;
                    fig[0, 1] = true;
                    fig[0, 0] = false;
                    fig[2, 1] = false;
                    state = false;
                    this.Show(dg);
                }
            }
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
