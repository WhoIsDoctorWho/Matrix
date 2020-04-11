using NUnit.Framework;
using MatrixCore;
using System;

namespace MatrixTests
{
    public class Tests
    {
        private Matrix matrix;
        [SetUp]
        public void Setup()
        {
            double[,] values = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            matrix = new Matrix(values);
        }
        [Test]
        public void TestOperatorsIncorrectSizes()
        {
            Matrix smaller = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            Matrix bigger = new Matrix(10, 10);
            TestDelegate diffSizesAdd = () => { Matrix m = smaller + bigger; };
            TestDelegate diffSizesSub = () => { Matrix m = smaller - bigger; };
            TestDelegate diffSizesMult = () => { Matrix m = smaller * bigger; };
            Assert.Throws(typeof(ArgumentException), diffSizesAdd);
            Assert.Throws(typeof(ArgumentException), diffSizesSub);
            Assert.Throws(typeof(ArgumentException), diffSizesMult);
        }
        [Test]
        public void TestAdditionCorrect()
        {
            Matrix toAdd = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            Matrix expected = new Matrix(new double[,] { { 2, 3, 4 }, { 5, 6, 7 }, { 8, 9, 10 } });
            Matrix actual = matrix + toAdd;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestSubstractionCorrect()
        {
            Matrix toSubsctract = new Matrix(new double[,] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } });
            Matrix expected = new Matrix(new double[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } });
            Matrix actual = matrix - toSubsctract;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestMultiplyOnNumber()
        {
            Matrix expected = new Matrix(new double[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } });
            Matrix actualLeft = matrix * 2;
            Matrix actualRight = 2 * matrix;
            Assert.AreEqual(expected, actualLeft);
            Assert.AreEqual(expected, actualRight);
        }
        [Test]
        public void TestMultiplyCorrect()
        {
            Matrix toMult = new Matrix(new double[,] { { 2, 2, 2 }, { 3, 3, 3 }, { 4, 4, 4 } });

            Matrix expectedLeft = new Matrix(new double[,] { { 20, 20, 20 }, { 47, 47, 47 }, { 74, 74, 74 } });
            Matrix actualLeft = matrix * toMult;
            Assert.AreEqual(expectedLeft, actualLeft);

            Matrix expectedRight = new Matrix(new double[,] { { 24, 30, 36 }, { 36, 45, 54 }, { 48, 60, 72 } });
            Matrix actualRight = toMult * matrix;
            Assert.AreEqual(expectedRight, actualRight);
        }
        [Test]
        public void TestSerialization()
        {        
            string filePath = @"D:\github\repo\epam\tasks\task1\MatrixCore\MatrixTests\TestFiles\test.json";
            MatrixSerializer.Serialize(matrix, filePath);
            Matrix deserialized = MatrixSerializer.Deserialize(filePath);
            Assert.AreEqual(matrix, deserialized);
        }        
        [Test]
        public void TestICloneable()
        {
            Matrix clone = matrix.Clone() as Matrix;
            Assert.NotNull(clone);
            
            clone[1, 1] = 73;
            Assert.AreNotEqual(clone[1, 1], matrix[1, 1]);
            Assert.AreNotEqual(clone, matrix);
        }
    }
}