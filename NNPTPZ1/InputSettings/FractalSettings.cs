namespace NNPTPZ1.InputSettings
{
    public class FractalSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public string OutputFile { get; set; }

        public static FractalSettings Parse(string[] args)
        {
            return new FractalSettings
            {
                Width = int.Parse(args[0]),
                Height = int.Parse(args[1]),
                XMin = double.Parse(args[2]),
                XMax = double.Parse(args[3]),
                YMin = double.Parse(args[4]),
                YMax = double.Parse(args[5]),
                OutputFile = args[6]
            };
        }
    }
}
