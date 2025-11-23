namespace CloudCalculator.Services
{
	public class MatrixService
	{
		public double[,] Multiply(double[,] A, double[,] B)
		{
			int aRows = A.GetLength(0);
			int aCols = A.GetLength(1);
			int bRows = B.GetLength(0);
			int bCols = B.GetLength(1);

			if (aCols != bRows)
				throw new Exception("Matrix dimensions do not match.");

			double[,] result = new double[aRows, bCols];
			Parallel.For(0, aRows, i =>
			{
				for (int j = 0; j < bCols; j++)
				{
					double sum = 0;
					for (int k = 0; k < aCols; k++)
						sum += A[i, k] * B[k, j];

					result[i, j] = sum;
				}
			});

			return result;
		}
	}
}
