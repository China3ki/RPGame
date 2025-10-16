using RPGGame.Gameplay.Characters;

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
        static void RenderInfoSameLine(string info, ConsoleColor font)
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
            Console.WriteLine($"{lp}. {player.Name} - {player.HP} - {player.Level} - {player.HP}");
        }
    }
}
