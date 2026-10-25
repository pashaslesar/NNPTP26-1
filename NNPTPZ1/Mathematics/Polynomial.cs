using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
    public class Polynomial
    {
        /// <summary>
        /// Coefficients
        /// </summary>
        public List<ComplexNumber> Coefficients { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Polynomial() => Coefficients = new List<ComplexNumber>();

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
        /// <returns>y</returns>
        public ComplexNumber Eval(double pointOfEvaluation)
        {
            return Eval(new ComplexNumber() { Real = pointOfEvaluation, Imaginary = 0 });
        }

        /// <summary>
        /// Evaluates polynomial at given point
        /// </summary>
        /// <param name="pointOfEvaluation">point of evaluation</param>
        /// <returns>y</returns>
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
        /// ToString
        /// </summary>
        /// <returns>String repr of polynomial</returns>
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