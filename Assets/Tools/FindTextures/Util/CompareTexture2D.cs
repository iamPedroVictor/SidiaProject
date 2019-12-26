using System.Collections.Generic;
using UnityEngine;
using SearchTextures.Enum;

namespace SearchTextures
{
    public class CompareTexture2D : IComparer<Texture2D>
    {
        private COMPARE compare;
        public CompareTexture2D(COMPARE _compare)
        {
            this.compare = _compare;
        }
        public int Compare(Texture2D x, Texture2D y)
        {
            if (this.compare == COMPARE.Heigth)
            {
                float xHeigth = x.width;
                float yHeigth = y.width;
                return xHeigth.CompareTo(yHeigth);
            }
            else if (this.compare == COMPARE.Size)
            {
                float xSize = x.width * x.height;
                float ySize = y.width * y.height;
                return xSize.CompareTo(ySize);
            }
            float xWidth = x.width;
            float yWidth = y.width;
            return xWidth.CompareTo(yWidth);
        }
    }
}
