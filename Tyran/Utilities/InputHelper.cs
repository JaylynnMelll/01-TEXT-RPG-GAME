using Tyran.GameLogic;

namespace Tyran.Utilities
{
    public static class InputHelper
    {
        // [Methods]
        // • 프롬프트 출력 및 유저 입력 받기
        public static string GetInput(string prompt)
        {
            UtilityManager.TypeText(prompt);
            Console.Write(">> ");
            return Console.ReadLine();
        }

        // • Intro()에서 플레이어의 입력값 유효성 검사
        public static bool IntroPlayOrExit()
        {
            Console.Write(">> ");
            var input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Enter)
            {
                UtilityManager.TypeText("\n\n...역시, 신탁이 틀리지는 않았나 봅니다.");
                Console.ReadKey(true);
                UtilityManager.TypeText("당신에게 신의 가호가 있기를...");
                UtilityManager.Wait3Seconds();
                return false;
            }
            else if (input.Key == ConsoleKey.Escape)
            {
                UtilityManager.TypeText("\n\n...");
                Console.WriteLine();
                UtilityManager.TypeText("곧 다시 만나게 될 것입니다.");
                Console.ReadKey(true);
                UtilityManager.TypeText("그럼, 그때까지 안녕히...");
                UtilityManager.Wait3Seconds();
                Environment.Exit(0);
                return false;
            }
            else
            {
                UtilityManager.TypeText("\n\n잘못된 입력입니다. [Enter]를 눌러서 모험을 시작하거나, [Escape]를 눌러서 돌아가세요.");
                return true;
            }
        }

        // • HarmelMain()에서 플레이어의 입력값 유효성 검사
        public static InputValidationResult IsValidInput(string input)
        {
            // 01) 입력이 null 또는 빈 문자열 혹은 0인 경우 : 1
            if (string.IsNullOrEmpty(input) || input == "0")
            {
                return InputValidationResult.EmptyOrNullOrZero;
            }
            else if (int.TryParse(input, out int intValue))
            {
                // 02) 입력이 숫자인 경우 && 1 ~ 3 사이의 숫자인 경우 : 2
                if (intValue > 0 && intValue <= 3)
                {
                    return InputValidationResult.ValidInRange;
                }
                // 03) 입력이 숫자인 경우 but 1 ~ 3 사이의 숫자가 아닌 경우 : 3
                else
                {
                    return InputValidationResult.NumberOutOfRange;
                }
            }
            // 04) 입력이 숫자가 아닌 경우 : 4
            else
            {
                return InputValidationResult.NotANumber;
            }
        }

        // [Enums]
        public enum InputValidationResult
        {
            EmptyOrNullOrZero = 1,
            ValidInRange = 2,
            NumberOutOfRange = 3,
            NotANumber = 4
        }
    }
}
