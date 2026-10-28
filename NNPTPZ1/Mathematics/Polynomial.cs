using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
    /// <summary>
    /// Polynomial
    /// </summary>
    public class Polynomial
    {
        /// <summary>
        /// Coefficients of the polynomial
        /// </summary>
        public List<ComplexNumber> Coefficients { get; set; }

        /// <summary>
        /// Constructor
        /// Creates a polynomial with no coefficients
        /// </summary>
        public Polynomial() => Coefficients = new List<ComplexNumber>();

        /// <summary>
        /// Appends a coefficient for the next higher power of x
        /// </summary>
        /// <param name="coefficient">Coefficient to append.</param>
        public void AddCoefficient(ComplexNumber coefficient) =>
            Coefficients.Add(coefficient);

        /// <summary>
        /// Derives this polynomial and creates new one
        /// </summary>
        /// <returns>Derivated polynomial</returns>
        public Polynomial Derive()
        {
            Polynomial derivative = new Polynomial();
            for (int i = 1; i < Coefficients.Count; i++)
            {
                derivative.Coefficients.Add(Coefficients[i].Multiply(new ComplexNumber() { Real = i }));
            }

            return derivative;
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="pointOfEvaluation">point of evaluation</param>
        /// <returns>Value of the polynomial at the given point</returns>
        public ComplexNumber Eval(double pointOfEvaluation)
        {
            return Eval(new ComplexNumber() { Real = pointOfEvaluation, Imaginary = 0 });
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="pointOfEvaluation">point of evaluation</param>
        /// <returns>Value of the polynomial at the given point</returns>
        public ComplexNumber Eval(ComplexNumber pointOfEvaluation)
        {
            ComplexNumber valueOfPolynomial = ComplexNumber.Zero;
            for (int i = 0; i < Coefficients.Count; i++)
            {
                ComplexNumber term = Coefficients[i];
                ComplexNumber power = pointOfEvaluation;
                int exponent = i;

                if (i > 0)
                {
                    for (int j = 0; j < exponent - 1; j++)
                    {
                        power = power.Multiply(pointOfEvaluation);
                    }

                    term = term.Multiply(power);
                }

                valueOfPolynomial = valueOfPolynomial.Add(term);
            }

            return valueOfPolynomial;
        }

        /// <summary>
        /// Returns a text representation of the polynomial
        /// </summary>
        /// <returns>Text representation of polynomial</returns>
        public override string ToString()
        {
            string equation = "";
            for (int i = 0; i < Coefficients.Count; i++)
            {
                equation += Coefficients[i];
                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                    {
                        equation += "x";
                    }
                }
                if (i + 1 < Coefficients.Count)
                {
                    equation += " + ";
                }
            }
            return equation;
        }
    }
}