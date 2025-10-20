using RPGGame.Components.Gui;
using RPGGame.Gameplay.Items;

namespace RPGGame.Components.Managers
{
    internal class EquipmentManager(string emptyInfo)
    {
         private string _emptyInfo = emptyInfo;
         private EquipmentView _view = new();
         public bool Display<T>(List<T> list, ItemCategory itemCategory) where T : Item
        {
            if (list.Count == 0)
            {
                View.RenderInfo(_emptyInfo, ConsoleColor.Red);
                Thread.Sleep(1500);
                return false;
            }
            DisplayHeaders(itemCategory);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Food food) _view.DisplayFood(i + 1, food);
                if (list[i] is Weapon weapon) _view.DisplayWeapon(i + 1, weapon);
                if (list[i] is Armor armor) _view.DisplayArmor(i + 1, armor);
                if (list[i] is Potion potion) _view.DisplayPotion(i + 1, potion);
            }
            return true;
        }
         private void DisplayHeaders(ItemCategory itemCategory)
        {
            switch (itemCategory)
            {
                case ItemCategory.Weapon: _view.DisplayWeaponHeaders(); break;
                case ItemCategory.Armor: _view.DisplayArmorHeaders(); break;
                case ItemCategory.Food: _view.DisplayFoodHeaders(); break;
                case ItemCategory.Potion: _view.DisplayPotionHeaders(); break;
            }
        }
    }
}
