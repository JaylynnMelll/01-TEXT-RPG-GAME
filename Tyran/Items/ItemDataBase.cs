using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyran.Items
{
    public static class ItemDataBase
    {
        // 공용 아이템
        public static Item 초보자용가죽갑옷 = new Item("가죽 갑옷", "가죽으로 만들어진 초보자용 갑옷이다.", Item.ItemType.Armor, 0, 10, 0, 100, 1);
        public static Item 초보자용가죽장갑 = new Item("가죽 장갑", "가죽으로 만들어진 초보자용 장갑이다.", Item.ItemType.Armor, 0, 5, 0, 50, 1);
        public static Item 초보자용가죽부츠 = new Item("가죽 부츠", "가죽으로 만들어진 초보자용 부츠이다.", Item.ItemType.Armor, 0, 5, 0, 50, 1);
        public static Item 초보자용가죽모자 = new Item("가죽 모자", "가죽으로 만들어진 초보자용 모자이다.", Item.ItemType.Armor, 0, 5, 0, 50, 1);

        // 워리어용 아이템
        public static Item 견습양손검 = new Item("견습양손검", "가장 기본적인 형태의 양손검이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 견습도끼 = new Item("견습 도끼", "가장 기본적인 형태의 도끼이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 견습갑옷 = new Item("견습 갑옷", "가장 기본적인 형태의 갑옷이다.", Item.ItemType.Armor, 0, 50, 0, 500, 1);

        // 위자드용 아이템
        public static Item 견습지팡이 = new Item("견습 지팡이", "가장 기본적인 형태의 지팡이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 견습마법서 = new Item("견습 마법서", "가장 기본적인 형태의 마법서이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 견습로브 = new Item("견습 로브", "가장 기본적인 형태의 로브이다.", Item.ItemType.Armor, 0, 45, 0, 500, 1);

        // 아처용 아이템
        public static Item 견습활 = new Item("견습 활", "가장 기본적인 형태의 활이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 가벼운견습갑옷 = new Item("가벼운 견습 갑옷", "가장 기본적인 형태의 가벼운 갑옷이다.", Item.ItemType.Armor, 0, 47, 0, 500, 1);
        public static Item 견습단검 = new Item("견습 단검", "가장 기본적인 형태의 단검이다.", Item.ItemType.Weapon, 0, 50, 0, 500, 1);

        // 팔라딘용 아이템
        public static Item 견습대포 = new Item("견습 대포", "하멜의 기사들의 휘두르는 가장 기본적인 형태의 대포이다.", Item.ItemType.Weapon, 90, 0, 0, 1300, 1);
        public static Item 견습엘갑옷 = new Item ("견습 엘갑옷", "하멜의 기사들이 프라이터니어를 착용할 수 있기 전, 훈련을 위해 입는 엘의 결정으로 만들어진 기본적인 갑옷이다.", Item.ItemType.Armor, 0, 90, 0, 1300, 1);
        
        // 로그용 아이템
        public static Item 견습쌍단검 = new Item("견습 쌍단검", "가장 기본적인 형태의 쌍단검이다.", Item.ItemType.Weapon, 50, 0, 0, 1000, 1);
        public static Item 견습가죽갑옷 = new Item("견습 가죽 갑옷", "가장 기본적인 형태의 가죽 갑옷이다.", Item.ItemType.Armor, 0, 45, 0, 500, 1);
        public static Item 견습가죽장갑 = new Item("견습 가죽 장갑", "가장 기본적인 형태의 가죽 장갑이다.", Item.ItemType.Armor, 0, 30, 0, 500, 1);

        // Consumeable 아이템
        public static Item 힐링포션 = new Item("힐링 포션", "체력을 20 회복하는 작은 용량의 포션이다.", Item.ItemType.Consumable, 0, 0, 20, 100, 1);

    }
}
