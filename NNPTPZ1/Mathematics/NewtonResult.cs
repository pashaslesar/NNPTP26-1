namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Result of Newton's method for one starting point
    /// </summary>
    public class NewtonResult
    {
        public ComplexNumber Root { get; set; }
        public int IterationCount { get; set; }

        public NewtonResult(ComplexNumber root, int iterationCount)
        {
            Root = root;
            IterationCount = iterationCount;
        }
    }
}
