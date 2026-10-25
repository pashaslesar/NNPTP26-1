namespace NNPTPZ1.Mathematics
{
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
