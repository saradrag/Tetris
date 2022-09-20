using System;
using System.Windows.Forms;

namespace Tetris
{
    abstract class Figure
    {
        public delegate void MyDelegate();
        public static event MyDelegate EndEvent;
        
        protected bool[,] fig;
        protected int x;
        protected int y;
        public Figure(Figure f)
        {
            fig = f.fig;
            x = 0;
            y = 0;
        }
        public Figure()
        { }
        public static Figure MakeNew(int r)
        {
            
            switch (r)
            {
                case 1: return new Fig1();
                case 2: return new Fig2(); 
                case 3: return new Fig3(); 
                case 4: return new Fig4();
                case 5: return new Fig5(); 
                case 6: return new Fig6();
                case 7: return new Fig7(); 
                case 8: return new Fig8();
                default: throw new InvalidOperationException("Figure doesn't exist");
            }
        }
        public abstract void Rotate(DataGridView dg);
        public abstract bool Fallen(DataGridView dg);
        public abstract void Show(DataGridView dg);
        public abstract void Left(DataGridView dg);
        public abstract void Right(DataGridView dg);
        public abstract void Remove(DataGridView dg);
        
        public void End()
        {
            EndEvent.Invoke();
            MessageBox.Show("Game Over");
            Application.Exit();
        }
        public abstract bool IsTouching(DataGridView dg);
    }
}
