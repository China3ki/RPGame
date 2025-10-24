using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Components.Managers;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Items;
using RPGGame.Gameplay.Shop;
using System.Diagnostics;

namespace RPGGame.States
{
    internal class ShopMenu(Inventory inventory, Stats stats) : IGameState
    {
        private Inventory _inventory = inventory;
        private Stats _stats = stats;
        private EquipmentManager _equipmentManager = new("W tym dziale nie mamy nic do sprzedania! Odwiedż nas póżniej!");
        public void InitState()
        {
            Shop();
        }
        public void Shop()
        {
            int number;
            do
            {
                Console.Clear();
                View.RenderInfo("===== Sklep ======", ConsoleColor.Cyan);
                View.RenderMenu(["Bronie", "Zbroje", "Owoce", "Mikstury", "Wyjdż"]);
                number = InputHandler.SelectOption("Wybierz numer:", 1, 5);
                if (number == 1) DisplayWeapon();
                if (number == 2) DisplayArmor();
                if (number == 3) DisplayFood();
                if (number == 4) DisplayPotion();
            } while (number != 5);
        }
        public void DisplayWeapon()
        {
            List<Weapon> weaponList = ShopManager.WeaponList;
            Console.Clear();
            View.RenderInfo("===== Bronie ======", ConsoleColor.White);
            if (!_equipmentManager.Display<Weapon>(weaponList, ItemCategory.Weapon)) return;
            int index = BuyItem<Weapon>(weaponList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Weapon, index);
        }
        public void DisplayPotion()
        {
            List<Potion> potionList = ShopManager.PotionList;
            Console.Clear();
            View.RenderInfo("===== Mikstury =====", ConsoleColor.White);
            if (!_equipmentManager.Display<Potion>(potionList, ItemCategory.Potion)) return;
            int index = BuyItem<Potion>(potionList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Potion, index);
        }
        public void DisplayFood()
        {
            List<Food> foodList = ShopManager.FoodList;
            Console.Clear();
            View.RenderInfo("===== Żywność =====", ConsoleColor.White);
            if(!_equipmentManager.Display<Food>(foodList, ItemCategory.Food)) return;
            int index = BuyItem<Food>(foodList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Food, index);
        }
        public void DisplayArmor()
        {
            List<Armor> armorList = ShopManager.ArmorList;
            Console.Clear();
            View.RenderInfo("===== Uzbrojenie =====", ConsoleColor.White);
            if (!_equipmentManager.Display<Armor>(armorList, ItemCategory.Armor)) return;
            int index = BuyItem<Armor>(armorList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Armor, index);
        }
        public int BuyItem<T>(List<T> list) where T : Item
        {
            int coins = _inventory.Coins;
            int number;
            View.RenderInfo("Wybierz przedmiot który chcesz zakupić lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
            View.RenderInfo($"Pieniądze: {coins} ", ConsoleColor.White);
            View.RenderInfo($"Waga: {_inventory.GetCurrentWeight()}/{_inventory.MaxWeight}", ConsoleColor.White);
            do
            {
                number = InputHandler.SelectOption("Wybierz przedmiot:", 0, list.Count);
                if (number == 0) return -1;
                Item item = list[number - 1];
                if (item.ReturnPrice() > coins)
                {
                    View.RenderInfo("Masz za mało pieniędzy!", ConsoleColor.Red); continue;
                }
                if (_inventory.AddItem(item))
                {
                    _inventory.RemoveCoins(item.ReturnPrice());
                    View.WaitForEnter($"Przedmiot ({item.Name}) został kupiony", ConsoleColor.Green);
                    _stats.ItemPurchased++;
                    _stats.MoneySpent += item.ReturnPrice();
                    break;
                }
                else
                {
                    View.RenderInfo("Nie jesteś wystarczająco silny aby dżwigać tyle przedmiotów!", ConsoleColor.Red);
                }
            } while (number != 0);
            return number - 1;
        }
        public void Update(StateManager stateManager)
        {
            stateManager.PopState();
        }
    }
}
