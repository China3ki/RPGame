using Newtonsoft.Json.Linq;
using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Components.Managers;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Items;
using System;

namespace RPGGame.States
{
    internal class InventoryMenu(Player player) : IGameState
    {
        private Player _player = player;
        private InventoryView _view = new();
        private EquipmentManager _equipmentManager = new("Nie masz żadnego przedmiotu tej kategorii!");
        public void InitState()
        {
            Inventory();
        }
        public void Inventory()
        {
            int number = 0;
            do
            {
                Weapon? primaryWeapon = _player.Inventory.PrimaryWeapon == -1 ? null : _player.Inventory.GetItem<Weapon>(_player.Inventory.PrimaryWeapon);
                Weapon? secondaryWeapon = _player.Inventory.SecondaryWeapon == -1 ? null : _player.Inventory.GetItem<Weapon>(_player.Inventory.SecondaryWeapon);
                Armor? helmet = _player.Inventory.Helmet == -1 ? null : _player.Inventory.GetItem<Armor>(_player.Inventory.Helmet);
                Armor? chestplate = _player.Inventory.Chestplate == -1 ? null : _player.Inventory.GetItem<Armor>(_player.Inventory.Chestplate);
                Armor? leggings = _player.Inventory.Leggings == -1 ? null : _player.Inventory.GetItem<Armor>(_player.Inventory.Leggings);
                Armor? boots = _player.Inventory.Boots == -1 ? null : _player.Inventory.GetItem<Armor>(_player.Inventory.Boots);
                int defenceValue = GetDefenceValue(helmet, chestplate, leggings, boots);
                Console.Clear();
                _view.DisplayEquipped(primaryWeapon, secondaryWeapon, helmet, chestplate, leggings, boots, defenceValue, _player.Inventory.GetCurrentWeight(), _player.Inventory.MaxWeight, _player.Inventory.Coins);
                View.RenderMenu(["Bronie", "Zbroje", "Żywność", "Mikstury", "Inne", "Wyjdż"]);
                number = InputHandler.SelectOption("Wybierz numer:", 1, 6);
                if (number == 1) DisplayWeapon();
                if (number == 2) DisplayArmor();
                if (number == 3) DisplayFood();
                if (number == 5) DisplayItems();
            } while (number != 6);
        }
        private void DisplayFood()
        {
            do
            {
                List<Food> foodList = _player.Inventory.GetTypeOfItems<Food>();
                Console.Clear();
                View.RenderInfo("===== Jedzenie =====", ConsoleColor.Cyan);
                if (!_equipmentManager.Display(foodList, ItemCategory.Food)) break;
                View.RenderInfo("====================", ConsoleColor.Cyan);
                View.RenderInfo("Wybierz przedmiot lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
                int index = InputHandler.SelectOption("Wybierz przedmiot:", 0, foodList.Count);
                if (index == 0) break; ;
                Food food = foodList[index - 1];
                ActionFood(food.Name, index - 1, ItemCategory.Armor);

            } while (true);
        }
        private void DisplayArmor()
        {
            do
            {
                List<Armor> armorList = _player.Inventory.GetTypeOfItems<Armor>();
                Console.Clear();
                View.RenderInfo("===== Bronie =====", ConsoleColor.Cyan);
                if (!_equipmentManager.Display(armorList, ItemCategory.Weapon)) break;
                View.RenderInfo("==================", ConsoleColor.Cyan);
                View.RenderInfo("Wybierz przedmiot lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
                int index = InputHandler.SelectOption("Wybierz przedmiot:", 0, armorList.Count);
                if (index == 0) break; ;
                Armor armor = armorList[index - 1];
                Action(armor.Name, armor.Equipped, index - 1, ItemCategory.Armor);
            } while (true);
        }
        private void DisplayWeapon()
        {
            do
            {
                List<Weapon> weaponList = _player.Inventory.GetTypeOfItems<Weapon>();
                Console.Clear();
                View.RenderInfo("===== Bronie =====", ConsoleColor.Cyan);
                if (!_equipmentManager.Display(weaponList, ItemCategory.Weapon)) break;
                View.RenderInfo("==================", ConsoleColor.Cyan);
                View.RenderInfo("Wybierz przedmiot lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
                int index = InputHandler.SelectOption("Wybierz przedmiot:", 0, weaponList.Count);
                if (index == 0) break; ;
                Weapon weapon = weaponList[index - 1];
                Action(weapon.Name, weapon.Equipped, index - 1, ItemCategory.Weapon);
            } while (true);
        }
        private void DisplayItems()
        {
            do
            {
                List<Item> itemList = _player.Inventory.GetItems(ItemCategory.Item);
                Console.Clear();
                View.RenderInfo("===== Przedmioty =====", ConsoleColor.Cyan);
                if (!_equipmentManager.Display(itemList, ItemCategory.Item)) break;
                View.RenderInfo("======================", ConsoleColor.Cyan);
                View.RenderInfo("Wybierz przedmiot do usunięcia lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
                int index = InputHandler.SelectOption("Wybierz przedmiot:", 0, itemList.Count);
                if (index == 0) break;
                if (RemoveItem(index - 1, ItemCategory.Item)) break;
            } while (true);
        }
        // Action for weapons and armor.
        private void Action(string itemName, bool equipped, int index, ItemCategory itemCategory)
        {
            do
            {
                Console.Clear();
                View.RenderInfo($"Wybrałeś {itemName}", ConsoleColor.White);
                if(equipped) View.RenderMenu(["Zdejmij przedmiot", "Usuń przedmiot", "Wróć"]);
                else View.RenderMenu(["Załóż przedmiot", "Usuń przedmiot", "Wróć"]);
                int number = InputHandler.SelectOption("Wybierz opcję:", 1, 3);
                if (number != 3 && itemCategory == ItemCategory.Weapon) if (ActionWeapon(itemName, equipped, index, number)) break;
                if (number != 3 && itemCategory == ItemCategory.Armor) if (ActionArmor(itemName, equipped, index, number)) break;
                if (number == 3) break;
            } while (true);
        }
        // Action for food and potion
        private void ActionFood(string itemName, int index, ItemCategory itemCategory)
        {
                Food food = _player.Inventory.GetTypeOfItems<Food>()[index];
                Console.Clear();
                View.RenderInfo($"Wybrałeś {itemName} - +{food.Value}HP", ConsoleColor.White);
                View.RenderInfo($"{_player.HP}/100HP", ConsoleColor.Yellow);
                View.RenderMenu(["Użyj", "Usuń przedmiot", "Wróć"]);
                int number = InputHandler.SelectOption("Wybierz opcję:", 1, 3);
                if (number == 1)
                {
                    _player.AddHP(food.Value);
                    _player.Inventory.RemoveItem(index, ItemCategory.Food);
                    View.WaitForEnter($"Zjadłeś: {itemName}", ConsoleColor.Green);
                }
                else if (number == 2) { RemoveItem(index, ItemCategory.Food); }
        }
        private bool ActionArmor(string itemName, bool equipped, int index, int number)
        {
            Armor armor = _player.Inventory.GetTypeOfItems<Armor>()[index];
            Dictionary<ArmorType, Slots> slotsDictionary = new() { { ArmorType.Helmet, Slots.Helmet }, { ArmorType.Chestplate, Slots.Chestplate }, { ArmorType.Leggings, Slots.Leggings }, { ArmorType.Boots, Slots.Leggings } };
            if (equipped && number == 1)
            {
                _player.Inventory.DeEquip(slotsDictionary[armor.ArmorType]);
                View.WaitForEnter($"Pomyślnie zdjąłeś: {itemName}", ConsoleColor.Green);
                return true;
            }
            else if(!equipped && number == 1)
            {
                _player.Inventory.EquipArmor(index);
                View.WaitForEnter($"Pomyślnie założyłeś: {itemName}", ConsoleColor.Green);
                return true;
            }
            else return RemoveItem(index, ItemCategory.Armor);
        }
        private bool ActionWeapon(string itemName, bool equipped, int index, int number)
        {
            if (equipped && number == 1)
            {
                if (_player.Inventory.PrimaryWeapon == index) _player.Inventory.DeEquip(Slots.PrimaryWeapon);
                else if (_player.Inventory.SecondaryWeapon == index) _player.Inventory.DeEquip(Slots.SecondaryWeapon);
                View.WaitForEnter($"Pomyślnie zdjąłeś: {itemName}", ConsoleColor.Green);
                return true;
            }
            else if(!equipped && number == 1)
            {
                View.RenderInfo("Wybierz slot", ConsoleColor.Yellow);
                View.RenderMenu(["Główny slot", "Drugi slot", "Anuluj"]);
                int decision = InputHandler.SelectOption("Wybierz opcje:", 1, 3);
                if (decision == 3) return false;
                WeaponSlot slot = decision == 1 ? WeaponSlot.PrimaryWeapon : WeaponSlot.SecondaryWeapon;
                _player.Inventory.EquipWeapon(index, slot);
                View.WaitForEnter($"Pomyślnie założyłeś: {itemName}", ConsoleColor.Yellow);
                return true;
            }
            else return RemoveItem(index, ItemCategory.Weapon);
        }
        private bool RemoveItem(int index, ItemCategory itemCategory)
        {
            View.RenderInfo("Czy na pewno chcesz usunąć przedmiot?", ConsoleColor.Yellow);
            View.RenderMenu(["Zatwierdż", "Anuluj"]);
            int decision = InputHandler.SelectOption("Wybierz opcje:", 1, 2);
            if (decision == 1)
            {
                _player.Inventory.RemoveItem(index, itemCategory);
                View.WaitForEnter("Usunąłeś przedmiot!", ConsoleColor.Green);
                return true;
            }
            else return false;
        }
        private int GetDefenceValue(params Armor[]? armorList)
        {
            int defenceValue = 0;
            for(int i = 0; i < armorList?.Length; i++)
            {
                if (armorList[i] == null) defenceValue += 0;
                else defenceValue += armorList[i].Value;
            }
            return defenceValue;
        }
        public void Update(StateManager stateManager)
        {
            stateManager.PopState();
        }
    }
}
