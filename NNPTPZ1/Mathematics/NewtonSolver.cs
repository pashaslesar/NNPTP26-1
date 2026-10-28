using System;

namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Finds roots of a polynomial using Newton's method
    /// </summary>
    public class NewtonSolver
    {
        private readonly Polynomial polynomial;
        private readonly Polynomial derivative;

        private const int RequiredIterations = 30;
        private const double LargeStepThreshold = 0.5;

        private const double ZeroReplacement = 0.0001;

        public NewtonSolver(Polynomial polynomial)
        {
            this.polynomial = polynomial;
            derivative = polynomial.Derive();
        }

        public NewtonResult Solve(ComplexNumber start)
        {
            ComplexNumber current = start;
            int iterations = 0;

            if (current.Real == 0)
            {
                current.Real = ZeroReplacement;
            }

            if (current.Imaginary == 0)
            {
                current.Imaginary = (float) ZeroReplacement;
            }

            for (int i = 0; i < RequiredIterations; i++)
            {
                var step = polynomial.Eval(current).Divide(derivative.Eval(current));
                current = current.Subtract(step);

                if (Math.Pow(step.Real, 2) + Math.Pow(step.Imaginary, 2) >= LargeStepThreshold)
                {
                    i--;
                }
                iterations++;
            }

            return new NewtonResult(current, iterations);
        }
    }
}
