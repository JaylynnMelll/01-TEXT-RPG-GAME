using Tyran.Character;

namespace Tyran.Items
{
    public class Item
    {
        // [Enum]
        public enum ItemType
        {
            Weapon,
            Armor,
            Accessory,
            Consumable,
            QuestItem,
            Miscellaneous
        }

        // [Fields]  
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEquipped { get; set; } = false;
        public bool IsInEquipMode { get; set; } = false;
        public ItemType Type { get; set; }
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
        public int HealthPoints { get; set; }
        public int Price { get; set; }
        public int Counts { get; set; }

        //[Constructor]
        public Item() { }

        public Item(string name, string description, ItemType type, int attackPower, int defensePower, int healthPoints, int price, int counts)
        {
            Name = name;
            Description = description;
            Type = type;
            AttackPower = attackPower;
            DefensePower = defensePower;
            HealthPoints = healthPoints;
            Counts = counts;
        }
    }
}
