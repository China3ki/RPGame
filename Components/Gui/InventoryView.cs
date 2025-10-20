using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Items;

namespace RPGGame.Components.Gui
{
    internal class InventoryView
    {
        public void DisplayEquipped(Weapon ?primaryWeapon, Weapon ?secondaryWeapon, Armor ?helmet, Armor ?chestplate, Armor ?leggings, Armor ?boots, int defenceValue, int weight, int maxWeight, int coins)
        {
            View.RenderInfo("===== Ekwipunek =====", ConsoleColor.Cyan);
            DisplayEquippedHeaders();
            // Główna broń
            View.RenderInfoSameLine("Główna broń: ", ConsoleColor.White);
            DisplayWeapon(primaryWeapon);
            // Druga broń
            View.RenderInfoSameLine("Druga broń: ", ConsoleColor.White);
            DisplayWeapon(secondaryWeapon);
            // Hełm
            View.RenderInfoSameLine("Hełm: ", ConsoleColor.White);
            DisplayWeapon(helmet);
            // Napierśnik
            View.RenderInfoSameLine("Napierśnik: ", ConsoleColor.White);
            DisplayWeapon(chestplate);
            // Nogawice
            View.RenderInfoSameLine("Nogawice: ", ConsoleColor.White);
            DisplayWeapon(leggings);
            // Buty
            View.RenderInfoSameLine("Buty: ", ConsoleColor.White);
            DisplayWeapon(boots);
            View.RenderInfo($"Całkowita Ochrona: {defenceValue}", ConsoleColor.White);
            View.RenderInfo($"Waga: {weight}/{maxWeight}", ConsoleColor.White);
            View.RenderInfo($"Pieniądze: {coins}", ConsoleColor.White);
            View.RenderInfo("=====================", ConsoleColor.Cyan);
        }
        private void DisplayWeapon(Item ?item)
        {
            if (item == null) View.RenderInfoSameLine("Brak \n", ConsoleColor.Red);
            else
            {
                View.RenderInfoSameLine(item.Name, ConsoleColor.Magenta); Console.Write(" | ");
                if(item is Weapon weapon) View.RenderInfoSameLine($"{weapon.WeaponType}", ConsoleColor.DarkBlue); Console.Write(" | ");
                if(item is Armor armor) View.RenderInfoSameLine($"{armor.ArmorType}", ConsoleColor.DarkBlue); Console.Write(" | ");
                View.RenderInfoSameLine($"{item.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
                View.RenderInfoSameLine($"{item.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
                View.RenderInfoSameLine($"{item.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
                if(item is Weapon weapon1) View.RenderInfoSameLine($"{weapon1.Value}", ConsoleColor.Blue); Console.Write(" | \n");
                if(item is Armor armor1) View.RenderInfoSameLine($"{armor1.Value}", ConsoleColor.Blue); Console.Write(" | \n");
            }
        }
        private void DisplayEquippedHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Rodzaj", ConsoleColor.DarkBlue); Console.Write(" | ");
            View.RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            View.RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            View.RenderInfoSameLine("Obrażenia/Ochrona", ConsoleColor.Blue); Console.Write(" | \n");
        }
    }
}
