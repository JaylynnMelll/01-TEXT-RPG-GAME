namespace Tyran.Utilities
{
    public static class UtilityManager
    {
        // • 텍스트 타이핑 효과
        public static void TypeText(string text, int delay = 50)
        {
            foreach (char t in text)
            {
                Console.Write(t);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
        }

        // • 3초 기다리기
        public static void Wait3Seconds()
        {
            UtilityManager.TypeText(".", 1000);
            UtilityManager.TypeText(".", 1000);
            UtilityManager.TypeText(".", 1000);
        }
    }
}
