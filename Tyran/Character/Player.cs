using Tyran.GameLogic;
using Tyran.Items;
using Tyran.Utilities;

namespace Tyran.Character
{
    public class PlayerManager
    {
        public static Player CurrentPlayer { get; private set; }

        public static void Initialize(Player player)
        {
            CurrentPlayer = player;
        }
    }
    public class Player 
    {
        // [Fields]
        public int Level { get; set; } = 1;
        public string Name { get; set; }
        public JobTypes Job { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int Health { get; set; }
        public int Speed { get; set; } 
        public int Gold { get; set; } = 1500;

        public Inventory Inventory { get; set; } = new Inventory();
        

        // [Methods]
        // • 캐릭터 정보 출력
        public void DisplayStats()
        {
            Console.Clear();
            Player player = PlayerManager.CurrentPlayer;
            Item items = new Item();

            string addAttackPower;
            string addDefensePower;
            int aPoint = 0;
            int dPoint = 0;
            bool isEquippedWeapon = false;
            bool isEquippedArmor = false;
            for (int i = 0; i < player.Inventory.inventory.Count(); i++)
            {
                var item = player.Inventory.inventory[i];
                if (item.IsEquipped && item.Type == Item.ItemType.Weapon)
                {
                    aPoint += item.AttackPower;
                    isEquippedWeapon = true;

                }
                else if (item.IsEquipped && item.Type == Item.ItemType.Armor)
                {
                    dPoint += item.DefensePower;
                    isEquippedArmor = true;
                }
            }

            addAttackPower = isEquippedWeapon ? $"(+{aPoint})" : "";
            addDefensePower = isEquippedArmor ? $"(+{dPoint})" : "";

            Console.WriteLine($"[{this.Name} : 정보]");
            Console.WriteLine($"당신과 관련된 정보가 표시됩니다.\n");
            Console.WriteLine("========================================");
            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name} ( {Job} )\n");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"\n공격력 : {AttackPower} {addAttackPower}"); 
            Console.WriteLine($"방어력 : {DefensePower} {addDefensePower}");
            Console.WriteLine($"체력   : {Health}");
            Console.WriteLine($"스피드 : {Speed}");
            Console.WriteLine($"골드   : {Gold} G");
            Console.WriteLine("========================================");
            UtilityManager.TypeText("[0] 돌아가기");
            
            while(true)
            {
                string input = InputHelper.GetInput("");

                if (input == "0")
                {
                    GameManager.HamelMain();
                    break;
                }
                else
                {
                    UtilityManager.TypeText("잘못된 입력입니다.\n다시 시도해 주세요.");
                }
            }
        }

        // • 캐릭터 직업 선택
        public JobTypes SelectAJob(string name)
        {
            // 00) 콘솔 화면 초기화
            Console.Clear();

            UtilityManager.TypeText($"{name}...알겠습니다.\n");
            UtilityManager.TypeText("당신의 사명을 알려주세요.\n");
            Console.WriteLine($"[1] {JobTypes.워리어}");
            Console.WriteLine($"[2] {JobTypes.위자드}");
            Console.WriteLine($"[3] {JobTypes.아처}");
            Console.WriteLine($"[4] {JobTypes.팔라딘}");
            Console.WriteLine($"[5] {JobTypes.로그}");

            bool isRunnig = true;
            while (isRunnig)
            {
                string input = InputHelper.GetInput("");
                switch (input)
                {
                    case "1":
                        Job = JobTypes.워리어;
                        isRunnig = false;
                        break;

                    case "2":
                        Job = JobTypes.위자드;
                        isRunnig = false;
                        break;

                    case "3":
                        Job = JobTypes.아처;
                        isRunnig = false;
                        break;

                    case "4":
                        Job = JobTypes.팔라딘;
                        isRunnig = false;
                        break;

                    case "5":
                        Job = JobTypes.로그;
                        isRunnig = false;
                        break;

                    default:
                        UtilityManager.TypeText("해당 사명의 의지는 당신에게 보이지 않습니다.\n다른 길을 선택하셔야 합니다.");
                        break;
                }
            }
            return Job;
        }

        // • 캐릭터생성시 랜덤 스탯
        public void RandomStatsBasis(int attack, int defense, int hp, int speed)
        {
            Random random = new Random();
            AttackPower = random.Next(11 + attack, 16 + attack);
            DefensePower = random.Next(8 + defense, 13 + defense);
            Health = random.Next(80 + hp, 101 + hp);
            Speed = random.Next(2 + speed, 6 + speed);
        }

        public void SetRandomStats()
        {
            Console.Clear();

            Random random = new Random();
            if (Job == JobTypes.팔라딘)
            {
                Thread.Sleep(2000);
                UtilityManager.TypeText("팔...라딘...?", 130);
                Console.ReadKey(true);
                UtilityManager.TypeText("그렇다면 당신은 필히 하멜인일터.", 100);
                Console.ReadKey(true);
                UtilityManager.TypeText("오직 하멜인만이 팔라딘의 사명을 품을 수 있습니다.", 100);
                Console.ReadKey(true);
                UtilityManager.TypeText("하지만 어째서인지 당신에게서만큼은 하멜의 빛을 느낄 수가 없군요...", 100);
                UtilityManager.Wait3Seconds();
                UtilityManager.TypeText("실례했습니다.");
                Console.ReadKey();
                UtilityManager.TypeText("당신의 사명에 따른 주사위를 굴려보겠습니다.");
                Console.ReadKey();
                UtilityManager.TypeText("다른 결과를 원하신다면 2번을 더 시도해보실 수 있습니다.");
                UtilityManager.Wait3Seconds();
            }
            else
            {
                UtilityManager.TypeText($"당신이 선택한 사명은...{Job}이군요.");
                Console.ReadKey(true);
                UtilityManager.TypeText("선택하신 사명에 따라 주사위를 굴려보겠습니다.");
                Console.ReadKey(true);
                UtilityManager.TypeText("다른 결과를 원하신다면 2번을 더 시도해보실 수 있습니다.");
                UtilityManager.Wait3Seconds();
            }
                

            bool Accepted = false;
            int attempts = 3; 
            while (!Accepted)
            {
                // 생성시 전 직군 평균 스탯 : 공격력 15, 방어력 12, 체력 100, 스피드 5
                if (Job == JobTypes.워리어)
                {
                    RandomStatsBasis(2, 2, -10, 0);      // 워리어)   공격력, 방어력(평균 이상) | 체력(평균 이하) | 스피드(평균)
                }
                else if (Job == JobTypes.위자드)
                {
                    RandomStatsBasis(5, -5, -10, 0);     // 위자드)   공격력(평균 이상) | 체력, 방어력(평균 이하) | 스피드(평균)
                }
                else if (Job == JobTypes.아처)
                {
                    RandomStatsBasis(3, -3, 0, 2);       // 아처 )    공격력, 스피드(평균 이상) | 방어력(평균 이하) | 체력(평균)
                }
                else if (Job == JobTypes.팔라딘)
                {
                    RandomStatsBasis(0, 3, 15, -2);      // 팔라딘)    방어력, 체력(평균 이상) | 스피드(평균 이하) | 공격력(평균)
                }
                else if (Job == JobTypes.로그)
                {
                    RandomStatsBasis(-2, 0, 10, 3);      // 로그)      체력, 스피드(평균 이상) | 공격력(평균 이하) | 방어력(평균)
                }

                UtilityManager.TypeText("주사위의 결과를 보여드리겠습니다.\n");
                Console.ReadKey(true);
                Console.WriteLine("========================================");
                UtilityManager.TypeText($"\n공격력: {AttackPower}");
                UtilityManager.TypeText($"방어력: {DefensePower}");
                UtilityManager.TypeText($"체력: {Health}");
                UtilityManager.TypeText($"스피드: {Speed}\n");
                Console.WriteLine("========================================");

                while (true)
                {
                    string input = InputHelper.GetInput("\n결과를 받아들이시겠습니까? (Y/N)");

                    if (input.ToUpper() == "Y")
                    {
                        UtilityManager.TypeText("\n결과를 수용하셨습니다.");
                        Console.ReadKey();
                        UtilityManager.TypeText("신께서는 당신의 여정에 필요한 모든 것들을 제공해 주셨습니다.");
                        Console.ReadKey();
                        UtilityManager.TypeText("이제부터 본인의 운명은 스스로가 개척해 나아가는 것입니다.");
                        Console.ReadKey();
                        UtilityManager.TypeText("행운을 빕니다.");
                        UtilityManager.Wait3Seconds();
                        Accepted = true;
                        break;
                    }
                    else if (input.ToUpper() == "N")
                    {
                        if (attempts > 0)
                        {
                            switch (attempts)
                            {
                                case 3:
                                    UtilityManager.TypeText("\n...호기로우시네요. 결과를 수용하지 않으셨습니다.");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("주사위를 다시 굴리도록 하겠습니다.");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("당신에게 남은 기회는 두 번 입니다.");
                                    attempts--;
                                    UtilityManager.Wait3Seconds();
                                    Console.Clear();
                                    break;
                                case 2:
                                    UtilityManager.TypeText("\n이 또한 신께서 당신에게 내린 운명일지언데...");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("이런 걸 두고 대범하다고 하는 걸까요.");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("남겨진 기회는 단 한 번 입니다.");
                                    attempts--;
                                    UtilityManager.Wait3Seconds();
                                    Console.Clear();
                                    break;
                                case 1:
                                    UtilityManager.TypeText("\n...마지막 기회입니다.");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("때로는 우리가 운명을 선택하는 것이 아닌, 운명이 우리를 선택하기도 합니다.");
                                    Console.ReadKey();
                                    UtilityManager.TypeText("당신은... 괜찮을 겁니다. 무엇이든지요.");
                                    attempts--;
                                    UtilityManager.Wait3Seconds();
                                    Console.Clear();
                                    break;
                            }
                            break;
                        }
                        else if (attempts == 0)
                        {
                            UtilityManager.TypeText("\n신께서 당신에게 허용해주신 기회는 여기까지 입니다.");
                            Console.ReadKey();
                            UtilityManager.TypeText("때로는 운명을 받아들이고 나아가는 자세도 필요한 법입니다.");
                            Console.ReadKey();
                            UtilityManager.TypeText("...신의 가호가 깃들기를 바랍니다.");
                            UtilityManager.Wait3Seconds();
                            Accepted = true;
                            break;
                        }

                    }
                    else
                    {
                        UtilityManager.TypeText("\n본인의 의사를 분명히 밝히는 것 또한 신의 사명을 품은 자의 기본입니다. 다시 말씀해주세요.");
                    }
                } 
            }
        }


        // [Enums]
        public enum JobTypes
        {
            워리어 = 1,
            위자드 = 2,
            아처 = 3,
            팔라딘 = 4,
            로그 = 5,
        }
    }
}
