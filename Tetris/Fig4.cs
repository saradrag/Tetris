using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    class Fig4 : Figure
    {
        bool[] state;
        public Fig4()
        {
            fig = new bool[3, 3];
            state = new bool[2];
            state[0] = false;
            state[1] = false;
            x = 0;
            y = 0;
            fig[0, 1] = true;
            fig[1, 0] = true;
            fig[1, 1] = true;
            fig[1, 2] = true;
        }
        public Fig4(Figure f) : base(f)
        {
            state = new bool[2];
        }
        public override void Right(DataGridView dg)
        {
            if (!state[0] && !state[1])
            {
                if (y + 3 != dg.ColumnCount && dg[y + 3, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
            else if (state[0] && !state[1])
            {
                if (y + 3 != dg.ColumnCount && dg[y + 3, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
            else if (state[0] && state[1])
            {
                if (y + 3 != dg.ColumnCount && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x].Style.BackColor.Equals(Color.Beige) && dg[y + 3, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
            else if (!state[0] && state[1])
            {
                if (y + 2 != dg.ColumnCount && dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x].Style.BackColor.Equals(Color.Beige) && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y++;
                    this.Show(dg);
                }
            }
        }

        public override bool IsTouching(DataGridView dg)
        {
            if (!state[0] && !state[1])
            {
                if (x + 2 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            else if (state[0] && state[1])
            {
                if (x + 3 == dg.RowCount || !dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            else if (!state[0] && state[1])
            {
                if (x + 3 == dg.RowCount || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            else if (state[0] && !state[1])
            {
                if (x + 3 == dg.RowCount || !dg[y + 2, x + 2].Style.BackColor.Equals(Color.Beige) || !dg[y + 1, x + 3].Style.BackColor.Equals(Color.Beige) || !dg[y, x + 2].Style.BackColor.Equals(Color.Beige))
                    return true;
                return false;
            }
            return true;
        }

        public override void Left(DataGridView dg)
        {
            if (!state[0] && !state[1])
            {
                if (y != 0 && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
            }
            else if (state[0] && state[1])
            {
                if (y != -1 && dg[y, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
            }
            else if (!state[0] && state[1])
            {
                if (y != 0 && dg[y, x + 2].Style.BackColor.Equals(Color.Beige) && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    y--;
                    this.Show(dg);
                }
            }
            else if (state[0] && !state[1])
            {
                if (y != 0 && dg[y - 1, x + 1].Style.BackColor.Equals(Color.Beige) && dg[y, x + 2].Style.BackColor.Equals(Color.Beige))
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
                        dg[j, i].Style.BackColor = Color.LightGreen;
                }
            }
        }

        public override void Rotate(DataGridView dg)
        {
            if (!state[0] && !state[1])
            {
                if (x + 2 != dg.RowCount && dg[y + 1, x + 2].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);

                    fig[1, 2] = false;

                    fig[2, 1] = true;
                    state[1] = true;
                    this.Show(dg);
                }
            }
            else if (!state[0] && state[1])
            {
                if (y + 2 != dg.ColumnCount && dg[y + 2, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[1, 2] = true;


                    fig[0, 1] = false;
                    state[0] = true;
                    state[1] = false; ;
                    this.Show(dg);
                }
            }
            else if (state[0] && !state[1])
            {
                if (dg[y + 1, x].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);

                    fig[0, 1] = true;

                    fig[1, 0] = false;
                    state[1] = true;
                    this.Show(dg);
                }
            }
            else if (state[0] && state[1])
            {
                if (y != -1 && dg[y, x + 1].Style.BackColor.Equals(Color.Beige))
                {
                    this.Remove(dg);
                    fig[1, 0] = true;


                    fig[2, 1] = false;
                    state[0] = false;
                    state[1] = false;
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
