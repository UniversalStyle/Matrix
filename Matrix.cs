using System;

namespace Math
{
    public class Matrix
    {
        /// <summary>
        /// Matrix rows 
        /// <summary>
        /// <returns>Returns the number of rows in a matrix</returns>
        private int Row {get; set;}

        /// <summary>
        /// Matrix columns
        /// <summary>
        /// <returns>Returns the number of columns in a matrix</returns>
        private int Column {get; set;}

        /// <summary>
        /// Matrix storage field
        /// <summary>
        /// <returns>Returns a matrix</returns>
        private dynamic[,] matrix {get; set;}

        /// <summary>
        /// Constructor for matrix 
        /// <summary>
        /// <param name="row">Number of matrix rows</param>
        /// <param name="column">Number of matrix columns</param>
        /// <returns></returns>
        public Matrix(int row, int column)
        {
            this.Row = row;
            this.Column = column;
            this.matrix = new dynamic[row, column];
        }

        /// <summary>
        /// Indexing for Matrix Operation
        /// <summary>
        /// <param name="row">Number of matrix rows</param>
        /// <param name="column">Number of matrix columns</param>
        /// <returns>Returns a matrix</returns>
        public dynamic this[int row, int column]
        {
            get
            {
                return this.matrix[row, column];
            }
            set
            {
                this.matrix[row, column] = value;
            }
        }

        /// <summary>
        /// Returns the number of rows in a matrix 
        /// <summary>
        /// <returns>Returns the number of rows in a matrix</returns>
        public int RowsCount()
        {
            return Row;
        }

        /// <summary>
        /// Returns the number of columns in a matrix 
        /// <summary>
        /// <returns>Returns the number of columns in a matrix</returns>
        public int ColumnsCount()
        {
            return Column;
        }

        /// <summary>
        /// Transpose the matrix
        /// <summary>
        /// <param name="matrix">Takes a matrix as input</param>
        /// <returns>Returns a matrix</returns>
        public Matrix Transpose()
        {
            Matrix result = new Matrix(this.ColumnsCount(), this.RowsCount());
            for(int row = 0; row < this.RowsCount(); row++)
            {
                for(int column = 0; column < this.ColumnsCount(); column++)
                {
                    result[column, row] = this[row, column];
                }
            }
            return result;
        }

        /// <summary>
        /// Adds matrix A to matrix B
        /// <summary>
        /// <param name="B">Takes matrix B at the input</param>
        /// <returns>Returns a matrix</returns>
        public Matrix Add(Matrix B)
        {
            if(this.RowsCount() == B.RowsCount() && this.ColumnsCount() == B.ColumnsCount())
            {
                Matrix result = new Matrix(B.RowsCount(), B.ColumnsCount());
                for(int row = 0; row < this.RowsCount(); row++)
                {
                    for(int column = 0; column < B.ColumnsCount(); column++)
                    {
                        result[row, column] = this[row, column] + B[row, column];
                    }
                }
                return result;
            }
            else 
            {
                throw new Exception("Error: the dimensions of the matrices do not match.");
            }
        }

        /// <summary>
        /// Subtracts matrix B from matrix A
        /// <summary>
        /// <param name="B">Takes matrix B at the input</param>
        /// <returns>Returns a matrix</returns>
        public Matrix Subtraction(Matrix B)
        {
            if(this.RowsCount() == B.RowsCount() && this.ColumnsCount() == B.ColumnsCount())
            {
                Matrix result = new Matrix(B.RowsCount(), B.ColumnsCount());
                for(int row = 0; row < this.RowsCount(); row++)
                {
                    for(int column = 0; column < B.ColumnsCount(); column++)
                    {
                        result[row, column] = this[row, column] - B[row, column];
                    }
                }
                return result;
            }
            else 
            {
                throw new Exception("Error: the dimensions of the matrices do not match.");
            }
        }

        /// <summary>
        /// Multiplies matrix A by matrix B
        /// <summary>
        /// <param name="B">Takes matrix B at the input</param>
        /// <returns>Returns a matrix</returns>
        public Matrix Multiply(Matrix B)
        {
            if(this.ColumnsCount() == B.RowsCount())
            {
                Matrix result = new Matrix(this.RowsCount(), B.ColumnsCount());
                for(int row = 0; row < this.RowsCount(); row++)
                {
                    for(int column = 0; column < B.ColumnsCount(); column++)
                    {
                        result[row, column] = 0;
                        for(int k = 0; k < this.ColumnsCount(); k++)
                        {
                            result[row, column] += this[row, k] * B[k, column];
                        }
                    }
                }
                return result;
            }
            else
            {
                throw new Exception("Error: the number of rows of matrix A must coincide with the number of columns of matrix B." + 
                "\nYour matrices:" +
                "\nMatrix A: " + this.RowsCount() + " rows and " + this.ColumnsCount() + " columns" +
                "\nMatrix B: " + B.RowsCount() + " rows and " + B.ColumnsCount() + " columns"
                );
            }
        }

        /// <summary>
        /// Multiplies matrix A by a constant 
        /// <summary>
        /// <param name="constant">Takes constant at the input</param>
        /// <returns>Returns a matrix</returns>
        public Matrix Multiply(dynamic constant)
        {
            Matrix result = new Matrix(this.RowsCount(), this.ColumnsCount());
            for(int row = 0; row < this.RowsCount(); row++)
            {
                for(int column = 0; column < this.ColumnsCount(); column++)
                {
                    result[row, column] = this[row, column] * constant;
                }
            }
            return result;
        }

    }
}