using System;

namespace MatrixCore
{
    public class Matrix
    {
        public double[,] matrix { get; }             

        public Matrix(double[,] matrix)
        {
            this.matrix = matrix;
        }
        public Matrix(int rows, int columns, bool fillRandom = true)
        {
            matrix = new double[rows, columns];
            if (fillRandom)
                FillRandom();
        }
        public override bool Equals(object m2)
        {
            throw new NotImplementedException();
        }
        private void FillRandom()
        {
            throw new NotImplementedException();
        }
        public static Matrix operator +(Matrix m1, Matrix m2) {
            throw new NotImplementedException();
        } 
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            throw new NotImplementedException();
        }
        public static Matrix operator *(Matrix m1, double number)
        {
            throw new NotImplementedException();
        }
        public static Matrix operator *(double number, Matrix m1)
        {
            throw new NotImplementedException();
        }        

    }
}
