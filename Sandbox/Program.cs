namespace Sandbox
{

    public static class LeetCode
    {
        public delegate int IntToInt(int i);

        public static int PlusFive(int i)
        {
            return i + 5;
        }

        public static int TimesSix(int i)
        {
            return i * 6;
        }

        public static int Twice(int i, IntToInt i2i)
        {
            return i2i(i2i(i));
        }

        public static void Main()
        {
            var i = 3;
            var iPlusFiveTwice = Twice(i, PlusFive);
            var iTimesSixTwice = Twice(i, TimesSix);
        }
    }
}