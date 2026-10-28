using System.Drawing;
using NNPTPZ1.InputSettings;
using NNPTPZ1.Mathematics;

namespace NNPTPZ1.PixelGraphics
{
    /// <summary>
    /// Renders a Newton fractal into a bitmap
    /// </summary>
    public class FractalRenderer
    {
        private readonly FractalSettings settings;
        private readonly NewtonSolver solver;
        private readonly RootCollection rootCollection;
        private readonly ColorManager colorManager;

        public FractalRenderer(FractalSettings settings, NewtonSolver solver, RootCollection rootCollection, ColorManager colorManager)
        {
            this.settings = settings;
            this.solver = solver;
            this.rootCollection = rootCollection;
            this.colorManager = colorManager;
        }

        public Bitmap Render()
        {
            Bitmap bitmap = new Bitmap(settings.Width, settings.Height);

            double xStep = (settings.XMax - settings.XMin) / settings.Width;
            double yStep = (settings.YMax - settings.YMin) / settings.Height;

            for (int row = 0; row < settings.Height; row++)
            {
                for (int column = 0; column < settings.Width; column++)
                {
                    double y = settings.YMin + row * yStep;
                    double x = settings.XMin + column * xStep;

                    ComplexNumber startPoint = new ComplexNumber()
                    {
                        Real = x,
                        Imaginary = (float) y
                    };

                    NewtonResult result = solver.Solve(startPoint);
                    ComplexNumber root = result.Root;
                    int rootId = rootCollection.GetRootIndex(root);

                    bitmap.SetPixel(column, row, colorManager.GetColor(rootId, result.IterationCount));
                }
            }

            return bitmap;
        }
    }
}
