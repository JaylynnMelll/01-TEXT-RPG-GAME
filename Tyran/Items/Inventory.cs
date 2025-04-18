using System.Data;
using System.Reflection.Emit;
using System.Xml.Linq;
using fNbt;
using MiNET.Items;
using Tyran.Character;
using Tyran.GameLogic;
using Tyran.Utilities;

namespace Tyran.Items 
{
    public class Inventory
    {
        public List<Item> inventory { get; set; } = new List<Item>();

        Player player = PlayerManager.CurrentPlayer;

        // [Methods]
        public void DisplayItemsInven(bool isInEquipMode)
        {
            Console.WriteLine("[소지품 목록]");
            Console.WriteLine("===================================================================");
            if (inventory.Count == 0)
            {
                Console.WriteLine("\n\n현재 아무 소지품도 지니고 있지 않습니다.\n\n");
            }
            else if (inventory.Count > 0)
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    var item = inventory[i];
                    string equipStatus = item.IsEquipped &&
                                         (item.Type == Item.ItemType.Armor ||
                                         item.Type == Item.ItemType.Weapon) ? "[E]" : "";
                    string itemCount = isInEquipMode ? $"{i+1:D2}" : "";

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

                    Console.WriteLine($"- {itemCount} {equipStatus}{item.Name.PadRight(15)} | {item.Counts:D2} |  {tagSelector:D2} | {item.Description}");
                }
            }
            Console.WriteLine("===================================================================");
        }

        public void OpenInventory()
        {
            Console.Clear();

            Console.WriteLine($"[인벤토리 : 정보]");
            Console.WriteLine($"보유중인 소지품을 관리할 수 있습니다.\n");
            DisplayItemsInven(false);
            Console.WriteLine("[1] 장착관리");
            Console.WriteLine("[0] 돌아가기");
            
            while(true)
            {
                string input = InputHelper.GetInput("");

                if (input == "1")
                {
                    ManageEquipment();
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

        public void ManageEquipment()
        {
            string input;
            while (true)
            {
                Console.Clear();

                Console.WriteLine($"[인벤토리 : 장착관리]");
                Console.WriteLine($"보유중인 소지품을 장착 및 장착해지할 수 있습니다.");
                Console.WriteLine($"장착된 아이템은 [E]로 표시됩니다.\n");
                DisplayItemsInven(true);
                Console.WriteLine("장착 혹은 해지할 아이템 번호를 입력하세요.");
                Console.WriteLine("[0] 장착관리 모드 해제");
                Console.WriteLine("[-] 인벤토리 닫기");

                while(true)
                {
                    input = InputHelper.GetInput("");

                    if (int.TryParse(input, out int choice) && choice >= 1 && choice <= inventory.Count)
                    {
                        Item selectedItem = inventory[choice - 1];
                        selectedItem.IsEquipped = !selectedItem.IsEquipped;

                        string action = selectedItem.IsEquipped ? "장착했습니다." : "장착을 해제했습니다.";
                        Console.WriteLine($"{selectedItem.Name}을 {action}");
                        break;
                    }
                    else if (input == "0")
                    {
                        OpenInventory();
                        return;
                    }
                    else if (input == "-")
                    {
                        GameManager.HamelMain();
                        return;
                    }
                    else
                    {
                        UtilityManager.TypeText("잘못된 입력입니다.\n다시 시도해 주세요.");
                    }
                }
            } 
        }

        public void AddItem(Item item)
        {
            // 인벤토리에 아이템이 이미 없다
            if (!inventory.Contains(item))
            {
                // >> 새 아이템 추가
                inventory.Add(item);
            }
            // 인벤토리에 아이템이 이미 있다
            else if (inventory.Contains(item))
            {
                // >> 아이템 개수 증가
                item.Counts++;
            }
        }

        public void DiscardItem(Item item)
        {
            // 아이템의 개수가 1개 이상일 때
            if (item.Counts > 1)
            {
                // >> 아이템 개수 감소
                item.Counts--;
            }
            // 아이템의 개수가 1개일 때
            else if (item.Counts == 1)
            {
                // >> 아이템 인벤토리에서 삭제
                inventory.Remove(item);
            }
        }

        // 처음 게임을 시작하고 새로운 캐릭터를 만들었을 때 직업에 따른 기본 아이템 지급
        public void GiveBasicItems()
        {
            Player player = PlayerManager.CurrentPlayer;

            player.Inventory.inventory.Clear();
            if (player.Job == Player.JobTypes.워리어)
            {
                player.Inventory.AddItem(ItemDataBase.견습양손검);
                player.Inventory.AddItem(ItemDataBase.견습도끼);
                player.Inventory.AddItem(ItemDataBase.견습갑옷);
                Give3HealingPotions();

            }
            else if (player.Job == Player.JobTypes.위자드)
            {
                player.Inventory.AddItem(ItemDataBase.견습지팡이);
                player.Inventory.AddItem(ItemDataBase.견습마법서);
                player.Inventory.AddItem(ItemDataBase.견습로브);
                Give3HealingPotions();

            }
            else if (player.Job == Player.JobTypes.아처)
            {
                player.Inventory.AddItem(ItemDataBase.견습활);
                player.Inventory.AddItem(ItemDataBase.견습단검);
                player.Inventory.AddItem(ItemDataBase.가벼운견습갑옷);
                Give3HealingPotions();

            }
            else if (player.Job == Player.JobTypes.팔라딘)
            {
                player.Inventory.AddItem(ItemDataBase.견습대포);
                player.Inventory.AddItem(ItemDataBase.견습엘갑옷);
                Give3HealingPotions();
            }
            else if (player.Job == Player.JobTypes.로그)
            {
                player.Inventory.AddItem(ItemDataBase.견습쌍단검);
                player.Inventory.AddItem(ItemDataBase.견습가죽갑옷);
                player.Inventory.AddItem(ItemDataBase.견습가죽장갑);

            }



        }

        public void Give3HealingPotions()
        {
            Player player = PlayerManager.CurrentPlayer;
            player.Inventory.AddItem(ItemDataBase.힐링포션);
            player.Inventory.AddItem(ItemDataBase.힐링포션);
            player.Inventory.AddItem(ItemDataBase.힐링포션);
        }
    }
}
