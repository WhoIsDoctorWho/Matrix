using System;

namespace MatrixCore
{
    public class Matrix : ICloneable
    {
        public double[,] matrix { get; set; }
        public int Rows
        {
            get => matrix.GetUpperBound(0) + 1;
        }
        public int Columns
        {
            get => matrix.GetUpperBound(1) + 1;
        }
        public double this[int row, int column] {
            get => matrix[row, column];
            set => matrix[row, column] = value;            
        }
        public delegate double Operation(double a, double b); // for overriding operators
        public Matrix() {}
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
        private void FillRandom()
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    this[i, j] = random.Next(-100, 100) + random.NextDouble();
                }
            }
        }
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            return MatrixSum(m1, m2, Add);
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            return MatrixSum(m1, m2, Substract);
        }
        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.Columns != m2.Rows)
                throw new ArgumentException("Can't mult this matrices");

            Matrix result = new Matrix(m2.Rows, m2.Columns, false);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int k = 0; k < result.Columns; k++)
                {
                    for (int j = 0; j < m1.Columns; j++)
                    {
                        result[i, k] += m1[i, j] * m2[j, k];
                    }
                }
            }
            return result;
        }
        public static Matrix operator *(Matrix m1, double number)
        {
            Matrix result = new Matrix(m1.Rows, m1.Columns, false);

            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = m1[i, j] * number;
                }
            }
            return result;
        }
        public static Matrix operator *(double number, Matrix m1)
        {
            return m1 * number;
        }
        private static Matrix MatrixSum(Matrix m1, Matrix m2, Operation op)
        {
            if (!IsSameSizes(m1, m2) || op == null)
            {
                throw new ArgumentException("Wrong sizes of given matrix");
            }
            Matrix result = new Matrix(m1.Rows, m1.Columns, false);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = op.Invoke(m1[i, j], m2[i, j]);
                }
            }
            return result;
        }
        private static bool IsSameSizes(Matrix m1, Matrix m2)
        {
            return m1?.Columns == m2?.Columns || m1?.Rows == m2?.Rows;
        }
        private static double Add(double a, double b)
        {
            return a + b;
        }
        private static double Substract(double a, double b)
        {
            return a - b;
        }
        public object Clone()
        {
            return new Matrix((double[,])matrix.Clone());
        }
        public override bool Equals(object obj)
        {
            Matrix toCheck = obj as Matrix;
            if (toCheck == null)
                return false;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (this[i, j] != toCheck[i, j])
                        return false;                    
                }
            }
            return true;
        }
    }
}