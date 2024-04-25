namespace ConsoleApp1
{
    internal class Program
    {
        class Player
        {
            public int Level { get; set; } = 1;
            public string Name { get; set; } = "Chad";
            public string Job { get; set; } = "전사";
            public int Attack { get; set; } = 10;
            public int Defense { get; set; } = 5;
            public int HP { get; set; } = 100;
            public int Gold { get; set; } = 1500;

            public void DisplayStatus()
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");

                Console.WriteLine($"Lv. {Level}");
                Console.WriteLine($"{Name} ( {Job} )");
                Console.WriteLine($"공격력 : {Attack}");
                Console.WriteLine($"방어력 : {Defense}");
                Console.WriteLine($"체 력 : {HP}");
                Console.WriteLine($"Gold : {Gold} G\n");

                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
            }
        }

        class Inventory
        {
            public static void DisplayInventory()
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

                Console.WriteLine("[아이템 목록]");
                Console.WriteLine("- 아이템이 없습니다.\n");

                Console.WriteLine("0. 나가기\n");
                Console.WriteLine("원하시는 행동을 입력해주세요.");
            }
        }


        class Item
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Price { get; set; }
            public string State { get; set; }

            public Item(string name, string description, int price, string state)
            {
                Name = name;
                Description = description;
                Price = price;
                State = state;
            }
        }

        class Shop
        {
            private List<Item> items;
            private int gold;

            public Shop(int playerGold)
            {
                items = new List<Item>
                {
                    new Item("수련자 갑옷", "방어력 +5 | 수련에 도움을 주는 갑옷입니다.", 1000, ""),
                    new Item("무쇠갑옷", "방어력 +9 | 무쇠로 만들어져 튼튼한 갑옷입니다.", 2000, ""),
                    new Item("스파르타의 갑옷", "방어력 +15 | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, ""),
                    new Item("낡은 검", "공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.", 600, ""),
                    new Item("청동 도끼", "공격력 +5 | 어디선가 사용됐던거 같은 도끼입니다.", 1500, ""),
                    new Item("스파르타의 창", "공격력 +7 | 스파르타의 전사들이 사용했다는 전설의 창입니다.", 2000, "")
                };

                gold = playerGold;

            }

            public void DisplayShop()
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{gold} G\n");

                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"- {items[i].Name} | {items[i].Description} | {items[i].Price} G");
                }
                Console.WriteLine("\n1. 아이템 구매");
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");


                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                if (choice == 1)
                {
                    Console.Clear();
                    DisplayBuyShop();
                }
                else if (choice == 0)
                {

                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

            }


            public void DisplayBuyShop()
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{gold} G\n");

                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.Write($"-{i + 1}.{items[i].Name} | {items[i].Description} | {items[i].Price} G ");
                    Console.WriteLine($"{items[i].State}");
                }

                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                string input = Console.ReadLine();
                int choice;
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                BuyItem(choice);
                DisplayBuyShop();
            }


            public void BuyItem(int choice)
            {
                if (choice < 1 || choice > items.Count)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    return;
                }

                Item selectedItem = items[choice - 1];
                if (selectedItem.Price == 0)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    return;
                }

                if (gold >= selectedItem.Price)
                {
                    gold -= selectedItem.Price;
                    selectedItem.Price = 0;
                    selectedItem.State = "구매완료";
                    Console.WriteLine("구매를 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
            }

        }



        static void Main(string[] args)
        {

            Player player = new Player();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점\n");

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            string input = Console.ReadLine();
            int choice;
            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("잘못된 입력입니다.");
                return;
            }

            switch (choice)
            {
                case 1:
                    player.DisplayStatus();
                    break;
                case 2:
                    Inventory.DisplayInventory();
                    break;
                case 3:
                    Shop shop = new Shop(player.Gold);
                    shop.DisplayShop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }







        }
    }
}
