using System;
using System.Diagnostics;
using System.Drawing;
namespace Testing
{
   public class TestCoding
    {
    public int[] pairNumber = {4,5,23};
    int pair1;
    ColorPair testPair1;
    Color[] colormaj=new Color[] { Color.White, Color.White, Color.Violet};
    Color[] colormin=new Color[] { Color.Brown, Color.SlateGray,Color.Green};
    public static void test(){
      for(int i=0;i<pairNumber.Length;i++){
      testPair1 = ColorCoding.GetColorFromPairNumber(pairNumber[i]);
			Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber[i], testPair1);
			Debug.Assert(testPair1.majorColor == colormaj[i]);
			Debug.Assert(testPair1.minorColor == colormin[i]);}	
    public static void test2(){
     ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
     pair1 = ColorCoding.GetPairNumberFromColor(testPair2);
     Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
     Debug.Assert(pair1 == 18);
     testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
     pair1= ColorCoding.GetPairNumberFromColor(testPair2);
     Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}", testPair2, pairNumber);
     Debug.Assert(pair1 == 6);}
   }
 }
