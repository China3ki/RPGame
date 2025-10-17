using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Items;

namespace RPGGame.Components.Gui
{
    static class View
    {
        static public void RenderMenu(string[] menu)
        {
            for (int i = 0; i < menu.Length; i++) Console.WriteLine($"{i + 1}.{menu[i]}");
        }
        static public void RenderInfo(string info, ConsoleColor font)
        {
            Console.ForegroundColor = font;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        static public void RenderInfoSameLine(string info, ConsoleColor font)
        {
            Console.ForegroundColor = font;
            Console.Write(info);
            Console.ResetColor();
        }
        static public void RenderCreatePlayerInfo()
        {
            RenderInfo("Przejdżmy teraz do rozdysponowania punktów!", ConsoleColor.White);
            Thread.Sleep(300);
            RenderInfo("Siła - wpływa na siłe twoich ataków", ConsoleColor.Yellow);
            Thread.Sleep(300);
            RenderInfo("Szczęście - każdy potrzebuje trochę szczęścia w życiu", ConsoleColor.Yellow);
            Thread.Sleep(300);
            RenderInfo("Refleks - Wpływa na atak z broni dystansowej oraz na szansę uniknięcia ataku", ConsoleColor.Yellow);
            Thread.Sleep(300);
            RenderInfo("Magia - umiejętność władania magią", ConsoleColor.Yellow);
            Thread.Sleep(300);
            RenderInfo("Umiejętności władania żywiołami - Zwiększa szanse na zadanie obrażeń pasywnych oraz obrone przed nimi", ConsoleColor.Yellow);
            Thread.Sleep(300);
            RenderInfo("Umiejętności władania bronią - zwiększa obrażenia", ConsoleColor.Yellow);         
        }
        static public void DisplayPlayerInfo(Player player)
        {
            RenderInfo("===== Informacje o graczu ======", ConsoleColor.Cyan);
            RenderInfoSameLine("Imię:", ConsoleColor.Yellow); Console.Write($"{player.Name}\n");
            RenderInfoSameLine("Siła:", ConsoleColor.Yellow); Console.Write($"{player.Skills.Strength}\n");
            RenderInfoSameLine("Szczęście:", ConsoleColor.Yellow); Console.Write($"{player.Skills.Luck}\n");
            RenderInfoSameLine("Refleks:", ConsoleColor.Yellow); Console.Write($"{player.Skills.Reflex}\n");
            RenderInfoSameLine("Magia:", ConsoleColor.Yellow); Console.Write($"{player.Skills.FireSkill}\n");
            RenderInfoSameLine("Umiejętność władania ogniem:", ConsoleColor.Yellow); Console.Write($"{player.Skills.FireSkill}\n");
            RenderInfoSameLine("Umiejętność władania zimnem:", ConsoleColor.Yellow); Console.Write($"{player.Skills.ColdSkill}\n");
            RenderInfoSameLine("Umiejętność władania ciemnością:", ConsoleColor.Yellow); Console.Write($"{player.Skills.DarkSkill}\n");
            RenderInfoSameLine("Umiejętność władania Mieczem:", ConsoleColor.Yellow); Console.Write($"{player.Skills.SwordSkill}\n");
            RenderInfoSameLine("Umiejętność władania Różdzką:", ConsoleColor.Yellow); Console.Write($"{player.Skills.WandSkill}\n");
            RenderInfoSameLine("Umiejętność władania Łukiem:", ConsoleColor.Yellow); Console.Write($"{player.Skills.BowSkill}\n");
            RenderInfoSameLine("Dostępne punkty:", ConsoleColor.Green); Console.Write($"{player.Skills.FreeSkillPoints}\n");
            RenderInfo("================================", ConsoleColor.Cyan);
        }
        static public void DisplaySaveGames(int lp, Player player)
        {
            Console.WriteLine($"{lp}. {player.Name} - {player.HP} - {player.Level} - {player.XP}");
        }
        static public void DisplayArmor(Armor armor)
        {
                RenderInfo($"{armor.Name} - {armor.ArmorType} - {armor.Weight} - {armor.MinStrengthLevel} - {armor.Value} - {armor.Rarity} - {armor.ReturnPrice()}", ConsoleColor.White);
        }
        static public void DisplayWeaponHeaders()
        {
            Console.Write("| ");
            RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            RenderInfoSameLine("Rodzaj broni", ConsoleColor.DarkBlue); Console.Write(" | ");
            RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            RenderInfoSameLine("Poziom umiejętności", ConsoleColor.DarkMagenta); Console.Write(" | ");
            RenderInfoSameLine("Wymagana umiejętność", ConsoleColor.DarkYellow); Console.Write(" | ");
            RenderInfoSameLine("Poziom", ConsoleColor.Blue); Console.Write(" | ");
            RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        static public void DisplayWeapon(int lp, Weapon weapon)
        {
            RenderInfoSameLine($"{lp}", ConsoleColor.White); Console.Write(" | ");
            RenderInfoSameLine(weapon.Name, ConsoleColor.Magenta); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.WeaponType}", ConsoleColor.DarkBlue); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.MinWeaponLevel}", ConsoleColor.DarkMagenta); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.RequiredSkillType}", ConsoleColor.DarkYellow); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.Value}", ConsoleColor.Blue); Console.Write(" | ");
            RenderInfoSameLine($"{weapon.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        static public void DisplayFoodHeaders()
        {
            Console.Write("| ");
            RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            RenderInfoSameLine("Nazwa", ConsoleColor.Magenta); Console.Write(" | ");
            RenderInfoSameLine("Trwałość", ConsoleColor.DarkGreen); Console.Write(" | ");
            RenderInfoSameLine("Waga", ConsoleColor.DarkCyan); Console.Write(" | ");
            RenderInfoSameLine("Rzadkość", ConsoleColor.Yellow); Console.Write(" | ");
            RenderInfoSameLine("Wartość", ConsoleColor.Blue); Console.Write(" | ");
            RenderInfoSameLine("Cena", ConsoleColor.DarkGray); Console.Write(" |\n");
        }
        static public void DisplayFood(int lp, Food food)
        {
            RenderInfoSameLine($"{lp}", ConsoleColor.White); Console.Write(" | ");
            RenderInfoSameLine(food.Name, ConsoleColor.Magenta); Console.Write(" | ");
            RenderInfoSameLine($"{food.Durability}", ConsoleColor.DarkGreen); Console.Write(" | ");
            RenderInfoSameLine($"{food.Weight}", ConsoleColor.DarkCyan); Console.Write(" | ");
            RenderInfoSameLine($"{food.Rarity}", ConsoleColor.Yellow); Console.Write(" | ");
            RenderInfoSameLine($"{food.Value}", ConsoleColor.Blue); Console.Write(" | ");
            RenderInfoSameLine($"{food.ReturnPrice()}", ConsoleColor.DarkGray); Console.Write(" |\n");
        } 
    }
}
