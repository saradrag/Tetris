using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Fig1 : Figure
    {

        bool state;
        public Fig1()
        {
            fig = new bool[4, 4];
            x = 0;
            y = 0;
            state = false;
            fig[1, 1] = true;
            fig[0, 1] = true;
            fig[2, 1] = true;
            fig[3, 1] = true;
        }
        public Fig1(Figure f) : base(f)
        {
            state = false;
        }
        public override void Right(DataGridView dg)
        {
            if (state == false)
            {
                if (y + 2 != dg.ColumnCount && dg[y + 2, x].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 3].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
            else
            {
                if (y + 4 != dg.ColumnCount && dg[y + 4, x + 1].Style.BackColor.Equals(Color.Beige))
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
                if (x + 4 == dg.RowCount || !dg[y + 1, x + 4].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            else
            {
                if (x + 2 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 3, x + 2].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }

        }

        public override void Left(DataGridView dg)
        {
            if (state == false)
            {
                if (y != -1 && dg[y, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige) && dg[y, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y, x + 3].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
            }
            else
            {
                if (y != 0 && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige))
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
            for (int i = x; i < x + 4; i++)
            {
                for (int j = y; j < y + 4; j++)
                {
                    if (fig[i - x, j - y] && !dg[j, i].Style.BackColor.Equals(Color.Beige))
                    {
                        End();
                    }
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.PaleVioletRed;
                }
            }
        }


        public override void Rotate(DataGridView dg)
        {
            if (state == false)
            {
                if (y != -1 && y + 3 < dg.ColumnCount && dg[y, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 3, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 1] = false;
                    fig[2, 1] = false;
                    fig[3, 1] = false;
                    fig[1, 0] = true;
                    fig[1, 2] = true;
                    fig[1, 3] = true;
                    state = true;
                    this.Show(dg);
                }
                else if (y + 3 == dg.ColumnCount && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 1] = false;
                    fig[2, 1] = false;
                    fig[3, 1] = false;
                    fig[1, 0] = true;
                    fig[1, 2] = true;
                    fig[1, 3] = true;
                    y--;
                    state = true;
                    this.Show(dg);
                }
            }
            else
            {
                if (x + 4 <= dg.RowCount && dg[y + 1, x].Style.BackColor.Equals(Color.Beige) && dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 1] = true;
                    fig[2, 1] = true;
                    fig[3, 1] = true;
                    fig[1, 0] = false;
                    fig[1, 2] = false;
                    fig[1, 3] = false;
                    state = false;
                    this.Show(dg);
                }
                else if (x + 4 <= dg.RowCount && dg[y + 2, x].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 3].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[0, 1] = true;
                    fig[2, 1] = true;
                    fig[3, 1] = true;
                    fig[1, 0] = false;
                    fig[1, 2] = false;
                    fig[1, 3] = false;
                    state = false;
                    y++;
                    this.Show(dg);
                }
            }
        }

        public override void Remove(DataGridView dg)
        {

            for (int i = x; i < x + 4; i++)
            {
                for (int j = y; j < y + 4; j++)
                {
                    if (fig[i - x, j - y])
                        dg[j, i].Style.BackColor = Color.Beige;
                }
            }
        }
    }
}
