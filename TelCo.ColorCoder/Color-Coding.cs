using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    class ColorCoding
    {
        private static Color[] colorMapMajor;
        private static Color[] colorMapMinor;
        internal class ColorPair
        {
            internal Color majorColor;
            internal Color minorColor;
            public override string ToString()
            {
                return string.Format("MajorColor:{0}, MinorColor:{1}", majorColor.Name, minorColor.Name);
            }
        }
        static ColorCoding()
        {
            colorMapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            colorMapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }
        private static ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = colorMapMinor.Length;
            int majorSize = colorMapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }
            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;
            ColorPair pair = new ColorPair() { majorColor = colorMapMajor[majorIndex],
                minorColor = colorMapMinor[minorIndex] };
            return pair;
        }
        private static int GetPairNumberFromColor(ColorPair pair)
        {
            // Find the major color in the array and get the index
            int majorIndex = -1;
            for (int i = 0; i < colorMapMajor.Length; i++)
            {
                if (colorMapMajor[i] == pair.majorColor)
                {
                    majorIndex = i;
                    break;
                }
            }
            int minorIndex = -1;
            for (int i = 0; i < colorMapMinor.Length; i++)
            {
                if (colorMapMinor[i] == pair.minorColor)
                {
                    minorIndex = i;
                    break;
                }
            }
            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }
            return (majorIndex * colorMapMinor.Length) + (minorIndex + 1);
        }
        private static void Main(string[] args)
        {
		int[] pairNumber = {4,5,23};
		int pair1;
		ColorPair testPair1;
		Color[] colormaj=new Color[] { Color.White, Color.White, Color.Violet};
		Color[] colormin=new Color[] { Color.Brown, Color.SlateGray,Color.Green};
		for(int i=0;i<pairNumber.Length;i++){
			testPair1 = ColorCoding.GetColorFromPairNumber(pairNumber[i]);
			Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber[i], testPair1);
			Debug.Assert(testPair1.majorColor == colormaj[i]);
			Debug.Assert(testPair1.minorColor == colormin[i]);}	
	    ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pair1 = ColorCoding.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pair1 == 18);
            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pair1= ColorCoding.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
            Debug.Assert(pair1 == 6);
        }
    }
}
