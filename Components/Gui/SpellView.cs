using RPGGame.Gameplay.Characters.Abilities;
namespace RPGGame.Components.Gui
{
    internal class SpellView
    {
        public void DisplayActiveSpells(Effect[] effectList)
        {
            View.RenderInfo("===== Zaklęcia =====", ConsoleColor.Cyan);
            DisplaySpellsHeaders();
            for(int i = 0; i < effectList.Length; i++)
            {
                if (effectList[i] == null)
                {
                    View.RenderInfoSameLine($"{i + 1}. ", ConsoleColor.White);
                    View.RenderInfo($"Brak", ConsoleColor.Red);
                }
                else DisplaySpells(i, effectList[i]);
            }
            View.RenderInfo("====================", ConsoleColor.Cyan);
        }
        public void DisplaySpellsHeaders()
        {
            Console.Write("| ");
            View.RenderInfoSameLine("Lp", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine("Efekt", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine("Rodzaj", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine("Długość", ConsoleColor.DarkCyan); Console.Write(" | \n");
        }
        public void DisplaySpells(int lp, Effect effect)
        {
            View.RenderInfoSameLine($"{lp}", ConsoleColor.White); Console.Write(" | ");
            View.RenderInfoSameLine($"{effect.EffectType}", ConsoleColor.Magenta); Console.Write(" | ");
            View.RenderInfoSameLine($"{effect.EffectCategory}", ConsoleColor.DarkGreen); Console.Write(" | ");
            View.RenderInfoSameLine($"{effect.Duration}", ConsoleColor.DarkCyan); Console.Write(" | ");
        }
    }
}
