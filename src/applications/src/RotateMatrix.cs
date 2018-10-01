namespace application
{
    /// <summary>
    /// Given an image represented by NxN matrix, write a method to rotate the image by 90 degrees.
    /// </summary>
    public static class RotateMatrix
    {
        public static int[,] Rotate(int[,] matrix, int rowCount)
        {
            var array = new int[rowCount, rowCount];
            int index = 0;
            for (int j = rowCount - 1; j >= 0; j--, index++)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    array[index, i] = matrix[i, j];
                }
            }

            return array;
        }
    }
}
