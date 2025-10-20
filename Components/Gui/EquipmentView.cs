using RPGGame.Gameplay.Items;

namespace RPGGame.Components.Gui
{
    internal class EquipmentView
    {
        public void DisplayPotionHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine("Efekt:", ConsoleColor.Red); Console.Write(" | ");
            View.RenderInfoSameLine("Długość efektu", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine("Wartość", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayPotion(int lp, Potion potion)
        {
            View.RenderInfoSameLine($"{lp}", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine(potion.Name, ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.EffectType}", ConsoleColor.Red); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.Duration}", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.Value}", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine($"{potion.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayArmorHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Rodzaj Zbroi", ConsoleColor.DarkBlue); Console.Write(" | ");
            View.RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine("Poziom umiejętności siły", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine("Ochrona", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayArmor(int lp, Armor armor)
        {
            if(armor.Equipped) View.RenderInfoSameLine($"{lp}", ConsoleColor.Green);
            else View.RenderInfoSameLine($"{lp}", ConsoleColor.White);
            Console.Write(" | ");
            View.RenderInfoSameLine(armor.Name, ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.ArmorType}", ConsoleColor.DarkBlue); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.Level}", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.Value}", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine($"{armor.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayWeaponHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Rodzaj broni", ConsoleColor.DarkBlue); Console.Write(" | ");
            View.RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine("Poziom umiejętności", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine("Wymagana umiejętność", ConsoleColor.DarkYellow); Console.Write(" | ");
            View.RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine("Obrażenia", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayWeapon(int lp, Weapon weapon)
        {
            if(weapon.Equipped) View.RenderInfoSameLine($"{lp}", ConsoleColor.Green);
            else View.RenderInfoSameLine($"{lp}", ConsoleColor.White); 
            Console.Write(" | ");
            View.RenderInfoSameLine(weapon.Name, ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.WeaponType}", ConsoleColor.DarkBlue); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.Level}", ConsoleColor.DarkMagenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.RequiredSkillType}", ConsoleColor.DarkYellow); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.Value}", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine($"{weapon.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayFoodHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine("Wartość", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        public void DisplayFood(int lp, Food food)
        {
            View.RenderInfoSameLine($"{lp}", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine(food.Name, ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{food.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine($"{food.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine($"{food.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine($"{food.Value}", ConsoleColor.Blue); Console.Write(" | ");
            View.RenderInfoSameLine($"{food.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
    }
}
