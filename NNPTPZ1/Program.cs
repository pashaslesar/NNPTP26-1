using System;
using System.Drawing;
using NNPTPZ1.Mathematics;
using NNPTPZ1.InputSettings;
using NNPTPZ1.PixelGraphics;

namespace NNPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        /// <summary>
        /// Generates a Newton fractal image and saves it to a file
        /// </summary>
        /// <param name="args">Width, height, XMin, XMax, YMin, YMax and output file path</param>
        static void Main(string[] args)
        {
            FractalSettings settings = FractalSettings.Parse(args);

            Polynomial polynomial = CreatePolynomial();
            Polynomial derivative = polynomial.Derive();

            Console.WriteLine(polynomial);
            Console.WriteLine(derivative);

            NewtonSolver solver = new NewtonSolver(polynomial);
            RootCollection rootCollection = new RootCollection();
            ColorManager colorManager = new ColorManager();

            FractalRenderer renderer = new FractalRenderer(settings, solver, rootCollection, colorManager);
            Bitmap bitmap = renderer.Render();

            bitmap.Save(settings.OutputFile ?? "../../../out.png");
        }

        private static Polynomial CreatePolynomial()
        {
            Polynomial polynomial = new Polynomial();
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1 });
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(ComplexNumber.Zero);
            polynomial.Coefficients.Add(new ComplexNumber() { Real = 1 });

            return polynomial;
        }
    }
}
