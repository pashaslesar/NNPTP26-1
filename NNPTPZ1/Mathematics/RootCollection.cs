using System;
using System.Collections.Generic;

namespace NNPTPZ1.Mathematics
{
    public class RootCollection
    {
        private readonly List<ComplexNumber> roots = new List<ComplexNumber>();
        private const double SameRootThreshold = 0.01;

        public int GetRootIndex(ComplexNumber root)
        {
            var knownRoot = false;
            var rootId = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(root.Real - roots[i].Real, 2) + Math.Pow(root.Imaginary - roots[i].Imaginary, 2) <= SameRootThreshold)
                {
                    knownRoot = true;
                    rootId = i;
                }
            }
            if (!knownRoot)
            {
                roots.Add(root);
                rootId = roots.Count;
            }

            return rootId;
        }
    }
}
