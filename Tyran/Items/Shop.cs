using Tyran.Character;
using Tyran.GameLogic;
using Tyran.Utilities;

namespace Tyran.Items
{
    class Shop
    {
        public List<Item> ShopItems { get; set; } = new List<Item>
        {
            ItemDataBase.견습양손검,
            ItemDataBase.견습도끼,
            ItemDataBase.견습갑옷,
            ItemDataBase.견습지팡이,
            ItemDataBase.견습마법서,
            ItemDataBase.견습로브,
            ItemDataBase.견습활,
            ItemDataBase.가벼운견습갑옷,
            ItemDataBase.견습단검,
            ItemDataBase.견습쌍단검,
            ItemDataBase.견습가죽갑옷,
            ItemDataBase.견습가죽장갑,
            ItemDataBase.힐링포션,
        };

        public void DisplayItemsShop(bool isInMode)
        {
            Player player = PlayerManager.CurrentPlayer;

            Console.WriteLine($"보유 골드 : {player.Gold} G\n\n");
            Console.WriteLine("========================================\n");
            for (int i = 0; i < ShopItems.Count; i++)
            {
                var item = ShopItems[i];
                string itemCount = isInMode ? $"{i+1:D2}" : "";
                string tagSelector;
                if (item.Type == Item.ItemType.Consumable)
                {
                    tagSelector = $"효  과: {item.HealthPoints}";
                }
                else
                {
                    if (item.AttackPower == 0)
                    {
                        tagSelector = $"방어력: {item.DefensePower}";
                    }
                    else
                    {
                        tagSelector = $"공격력: {item.AttackPower}";
                    }
                }

                Console.WriteLine($"- {i + 1:D2} {item.Name} | {tagSelector} | 가격: {item.Price} | {item.Description}");
            }
            Console.WriteLine("\n========================================");
        }
        public void EnterShop()
        {
            Player player = PlayerManager.CurrentPlayer;

            Console.Clear();

            Console.WriteLine($"[상  점]");
            Console.WriteLine($"하멜의 외곽에 위치해 있는 조그마한 상점입니다.");
            Console.WriteLine($"필요한 아이템을 구입하거나 판매할 수 있습니다.\n\n");
            DisplayItemsShop(false);
            Console.WriteLine("[1] 아이템 구매하기");
            Console.WriteLine("[2] 아이템 판매하기");
            Console.WriteLine("[0] 돌아가기");

            while (true)
            {
                string input = InputHelper.GetInput("");

                if (input == "1")
                {
                    BuyItems();
                    break;
                }
                else if (input == "2")
                {
                    SellItems();
                    break;
                }
                else if (input == "0")
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

        public void BuyItems()
        {
            Console.Clear();

            Console.WriteLine($"[상  점 : 구매하기]");
            Console.WriteLine($"상점에서 필요한 아이템을 구매합니다.\n\n");
            DisplayItemsShop(false);
            Console.WriteLine("[1] 아이템 판매하기");
            Console.WriteLine("[2] 아이템 구경하기");
            Console.WriteLine("[0] 돌아가기");

            while (true)
            {
                string input = InputHelper.GetInput("");

                if (input == "1")
                {
                    SellItems();
                    break;
                }
                else if (input == "2")
                {
                    EnterShop();
                    break;
                }
                else if (input == "0")
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

        public void SellItems()
        {
            Console.Clear();

            Console.WriteLine($"[상  점 : 판매하기]");
            Console.WriteLine($"상점에 필요 없는 아이템을 판매합니다.\n\n");
            DisplayItemsShop(false);
            Console.WriteLine("[1] 아이템 구매하기");
            Console.WriteLine("[2] 아이템 구경하기");
            Console.WriteLine("[0] 돌아가기");

            while (true)
            {
                string input = InputHelper.GetInput("");

                if (input == "1")
                {
                    BuyItems();
                    break;
                }
                else if (input == "2")
                {
                    EnterShop();
                    break;
                }
                else if (input == "0")
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
    }
}
