using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Components.Managers;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Items;

namespace RPGGame.States
{
    internal class InventoryMenu(Inventory inventory) : IGameState
    {
        private Inventory _inventory = inventory;
        private InventoryView _view = new();
        private EquipmentManager _equipmentManager = new("Nie masz żadnego przedmiotu tej kategorii!");
        public void InitState()
        {
            Inventory();
        }
        public void Inventory()
        {
            Weapon ?primaryWeapon = _inventory.PrimaryWeapon;
            Weapon ?secondaryWeapon = _inventory.SecondaryWeapon;
            Armor ?helmet = _inventory.Helmet;
            Armor ?chestplate = _inventory.Chestplate;
            Armor ?leggings = _inventory.Leggings;
            Armor ?boots = _inventory.Boots;
            int defenceValue = GetDefenceValue(helmet, chestplate, leggings, boots);
            int number = 0;
            do
            {
                Console.Clear();
                _view.DisplayEquipped(primaryWeapon, secondaryWeapon, helmet, chestplate, leggings, boots, defenceValue, _inventory.GetCurrentWeight(), _inventory.MaxWeight, _inventory.Coins);
                View.RenderMenu(["Bronie", "Zbroje", "Żywność", "Mikstury", "Inne", "Wyjdż"]);
                number = InputHandler.SelectOption("Wybierz numer:", 1, 6);
                if (number == 1) DisplayWeapon();
            } while (number != 6);
        }
        private void DisplayWeapon()
        {
            do
            {
                List<Weapon> weaponList = _inventory.GetTypeOfItems<Weapon>();
                Console.Clear();
                View.RenderInfo("===== Bronie =====", ConsoleColor.Cyan);
                if (!_equipmentManager.Display(weaponList, ItemCategory.Weapon)) break;
                int index = InputHandler.SelectOption("Wybierz przedmiot", 0, weaponList.Count);
                if (index == 0) return;
                Action(weaponList[index - 1].Name, index - 1, ItemCategory.Weapon);
            } while (true);
        }
        private void Action(string itemName, int index, ItemCategory itemCategory)
        {
            do
            {
                Console.Clear();
                View.RenderInfo($"Wybrałeś {itemName}", ConsoleColor.White);
                View.RenderMenu(["Załóż przedmiot", "Usuń przedmiot", "Wyjdź"]);
                int number = InputHandler.SelectOption("Wybierz opcję:", 1, 3);
                if (number == 1)
                {
                    View.RenderInfo("Wybierz slot", ConsoleColor.Yellow);
                    View.RenderMenu(["Główny slot", "Drugi slot", "Anuluj"]);
                    int decision = InputHandler.SelectOption("Wybierz opcje:", 1, 3);
                    if (decision == 3) continue;
                    WeaponSlot slot = decision == 1 ? WeaponSlot.PrimaryWeapon : WeaponSlot.SecondaryWeapon;
                    _inventory.EquipWeapon(index, slot);
                }
                else if (number == 2)
                {
                    View.RenderInfo("Czy na pewno chcesz usunąć przedmiot?", ConsoleColor.Yellow);
                    View.RenderMenu(["Zatwierdż", "Anuluj"]);
                    int decision = InputHandler.SelectOption("Wybierz opcje:", 1, 2);
                    if (decision == 1) _inventory.RemoveItem(index, ItemCategory.Weapon);
                    break;
                }
                else if (number == 3) break;
            } while (true);
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

        }
    }
}
