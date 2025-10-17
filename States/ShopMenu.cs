using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Items;
using RPGGame.Gameplay.Shop;
using System.Diagnostics;

namespace RPGGame.States
{
    internal class ShopMenu(Player player) : IGameState
    {
        private Player _player = player;
        public void InitState()
        {
            Console.Clear();
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
                if (number == 3) DisplayFood();
            } while (number != 5);
        }
        public void DisplayFood()
        {
            List<Food> foodList = ShopManager.FoodList;
            Console.Clear();
            View.RenderInfo("===== Żywność =====", ConsoleColor.White);
            if (foodList.Count == 0)
            {
                View.RenderInfo("Nie ma żadnej żywności do sprzedania!", ConsoleColor.Red);
                Thread.Sleep(2000);
                return;
            }
            View.DisplayFoodHeaders();
            for (int i = 0; i < foodList.Count; i++)
            {
                View.DisplayFood(i + 1, foodList[i]);
            }
            int index = BuyItem<Food>(foodList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Food, index);
        }
        public void DisplayWeapon()
        {
            List<Weapon> weaponList = ShopManager.WeaponList;
            Console.Clear();
            View.RenderInfo("===== Bronie ======", ConsoleColor.White);
            if (weaponList.Count == 0)
            {
                View.RenderInfo("Nie ma żadnej broni do sprzedania!", ConsoleColor.Red);
                Thread.Sleep(2000);
                return;
            }
            View.DisplayWeaponHeaders();
            for (int i = 0; i < weaponList.Count; i++)
            {
                View.DisplayWeapon(i + 1, weaponList[i]);
            }
            int index = BuyItem<Weapon>(weaponList);
            if (index != -1) ShopManager.RemoveAt(ItemCategory.Weapon, index);
        }
        public int BuyItem<T>(List<T> list) where T : Item
        {
            int coins = _player.Coins;
            int number;
            View.RenderInfo("Wybierz przedmiot który chcesz zakupić lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
            View.RenderInfo($"Pieniądze: {coins} ", ConsoleColor.White);
            View.RenderInfo($"Waga: {_player.Inventory.GetCurrentWeight()}/{_player.Inventory.MaxWeight}", ConsoleColor.White);
            do
            {
                number = InputHandler.SelectOption("Wybierz przedmiot:", 0, list.Count);
                if (number == 0) return -1;
                Item item = list[number - 1];
                if (item.ReturnPrice() > coins)
                {
                    View.RenderInfo("Masz za mało pieniędzy!", ConsoleColor.Red); continue;
                }
                if (_player.Inventory.AddItem(item))
                {
                    _player.RemoveCoins(item.ReturnPrice());
                    View.RenderInfo($"Przedmiot ({item.Name}) został kupiony", ConsoleColor.Green);
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    View.RenderInfo("Nie jesteś wystarczająco silny aby dżwigać tyle przedmiotów!", ConsoleColor.Red);
                    continue;
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
