using System.Threading.Tasks.Dataflow;
using Tyran.Character;
using Tyran.Items;
using Tyran.Utilities;

namespace Tyran.GameLogic
{
    public class GameManager
    {
        public static bool firstTimeInHamel = true;
        public static bool nthTimeInHamel = false;

        // • 게임 인트로
        public static void Intro()
        {
            // 00) 콘솔 화면 초기화
            Console.Clear();


            // 01) 환영 메세지 출력
            UtilityManager.TypeText("타이란에 오신 것을 환영합니다.");
            Console.ReadKey();
            UtilityManager.TypeText("이곳 타이란은 빛과 어둠만이 존재할 뿐, 선과 악은 존재하지 않습니다.");
            Console.ReadKey();
            UtilityManager.TypeText("당신은 이곳에서 어떤 이야기를 만들어 나가시겠습니까?\n");
            Console.ReadKey();
            UtilityManager.TypeText("모험의 여정을 시작하시려면 [Enter]를,\n지금이라도 돌아가시겠다면 [Escape]을 눌러주세요.\n");
           

            // 02) 플레이어 플레이 여부 확인
            bool isRunning = true;
            while (isRunning)
            {
                isRunning = InputHelper.IntroPlayOrExit();
            }
        }

        // • 게임 시작 & 플레이어 생성
        public static Player CreatePlayer()
        {
            // 00) 콘솔 화면 초기화
            Console.Clear();


            // 01) 플레이어 캐릭터 생성
            Player player = new Player();
            PlayerManager.Initialize(player);


            // 02) 플레이어 이름 입력
            string tempName;
            while (true)
            {
                tempName = InputHelper.GetInput("당신의 이름을 알려주세요.");

                // 01 - 01) 플레이어 이름 유효성 검사
                if (string.IsNullOrEmpty(tempName))
                {
                    UtilityManager.TypeText("\n이름을 모르고서야, 길을 인도해드릴 수 없습니다.");
                }
                else
                {
                    break;
                }
            }
            player.Name = tempName;

            // 03) 플레이어 직업 선택
            player.Job = player.SelectAJob(player.Name);
            player.Inventory.GiveBasicItems();


            // 04) 플레이어의 스탯 설정 (직업에 따라 랜덤)
            player.SetRandomStats();

            return player;
        }

        // • 하멜 게임 메인 화면
        public static void HamelMain()
        {
            // 00) 콘솔 화면 초기화
            Console.Clear();
            Player player = PlayerManager.CurrentPlayer;


            // 01) 게임 메인 화면
            if (firstTimeInHamel == true && player.Job == Player.JobTypes.팔라딘)
            {
                UtilityManager.TypeText($"(...하멜인이라... 하지만 나는 태어나서 단 한 번도 이 곳에 와 본적이 없는걸.)");
                Console.ReadKey();
                UtilityManager.TypeText("당신의 어린 시절은 하멜의 웅장함과는 꽤나 거리가 멀었습니다.");
                Console.ReadKey();
                UtilityManager.TypeText("하지만 점점 더 하멜에 가까워질수록 당신의 가슴 중앙에 박힌 엘의 결정이 하멜로부터 흘러오는 빛의 에너지와 공명하기 시작합니다...");
                UtilityManager.Wait3Seconds();
                UtilityManager.TypeText("얼마나 지났을까... 주변을 둘러보자 끝도 없이 푸르른 바다가 거대한 섬을 에워싸고 있는 것이 보입니다.");
                Console.ReadKey();
                UtilityManager.TypeText("바로 저 섬에 세워진, 굳건한 그들의 성벽만큼이나 시련에도 흔들림 없는 기사의 나라가 당신의 고향, 하멜입니다.");
                Console.ReadKey();
                UtilityManager.TypeText("...돌아오신 것을, 환영합니다.");
                firstTimeInHamel = false;
                nthTimeInHamel = true;
                Console.ReadKey();
                Console.WriteLine();
            }
            else if (firstTimeInHamel == true)
            {
                UtilityManager.TypeText($"{player.Name}, 당신의 여정은 하멜이라 불리우는 기사의 나라에서 시작됩니다.");
                Console.ReadKey();
                UtilityManager.TypeText("하멜은 타이란의 빛의 영역인 엘리시움의 중심에 위치해 사방이 바다로 둘러 쌓인 거대한 섬에 자리잡고 있습니다.");
                Console.ReadKey();
                UtilityManager.TypeText("아주 오래 전부터 엘리시움을 지키는 것이 하멜이 존재하는 이유이기도 하지요.");
                firstTimeInHamel = false;
                nthTimeInHamel = true;
                Console.ReadKey();
                Console.WriteLine();
            }
            else if (nthTimeInHamel = true)
            {
                UtilityManager.TypeText("당신은 현재 하멜의 외곽에 있습니다.\n");
            }

            UtilityManager.TypeText("[1] 캐릭터 정보");
            UtilityManager.TypeText("[2] 인벤토리");
            UtilityManager.TypeText("[3] 상점");
            Console.WriteLine();
            string input = InputHelper.GetInput("원하시는 활동을 선택해 주세요.");


            // 02) 입력값 유효성 검사
            bool isValid = false;
            InputHelper.InputValidationResult validatedInput;
            do
            {
                validatedInput = InputHelper.IsValidInput(input);

                switch (validatedInput)
                {
                    case InputHelper.InputValidationResult.EmptyOrNullOrZero:
                        Console.WriteLine("아무것도 하지 않는 것은 사명을 품은 자의 정신에 어긋나는 일입니다");
                        input = InputHelper.GetInput("무엇이라도 해봅시다.");
                        break;

                    case InputHelper.InputValidationResult.ValidInRange:
                        isValid = true;
                        break;

                    case InputHelper.InputValidationResult.NumberOutOfRange:
                        Console.WriteLine("아직 배우지 않은 활동입니다. 마음이 앞서시는군요.");
                        input = InputHelper.GetInput("배운 활동 중 선택해 주세요 (1~3)");
                        break;

                    case InputHelper.InputValidationResult.NotANumber:
                        Console.WriteLine("잘 못알아 들었습니다.");
                        input = InputHelper.GetInput("이해할 수 있는 언어로 이야기 해주세요.");
                        break;
                }
            } while (!isValid);


            // 03) 활동 선택            
            switch (input)
            {
                case "1":
                    player.DisplayStats();
                    break;

                case "2":
                    player.Inventory.OpenInventory();
                    break;

                case "3":
                    Shop shop = new Shop();
                    shop.EnterShop();
                    break;

                default:
                    Console.WriteLine("잘 못알아 들었습니다.");
                    input = InputHelper.GetInput("하멜어로 이야기 해주세요.");
                    break;
            }
        }

    }
}

