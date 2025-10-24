using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters.Managers;

namespace RPGGame.States
{
    internal class SpellMenu(SpellsManager spellManager) : IGameState
    {
        private SpellsManager _spellManager = spellManager;
        private SpellView _spellView = new();
        
        public void InitState()
        {
            Spells();
        }
        public void Spells()
        {
            int number;
            do
            {
                Console.Clear();
                _spellView.DisplayActiveSpells(_spellManager.ActiveSpells);
                View.RenderInfo("5. Wyświetl wszystkie poznane zaklęcia", ConsoleColor.White);
                View.RenderInfo("6. Wróć", ConsoleColor.White);
                number = InputHandler.SelectOption("Wybierz numer:", 1, 6);
                if (number >= 1 && number <= 4) ChangeSpell(number - 1);
            } while (number != 6);
        }
        public void ChangeSpell(int index)
        {
            if (!DisplayLearnedSpells()) return;
            View.RenderInfo("Wybierz zaklęcie lub wybierz 0 aby wrócić", ConsoleColor.Yellow);
            int number = InputHandler.SelectOption("Wybierz zaklęcie:", 0, _spellManager.LearnedSpellList.Count);
            if (number == 0) return;
            _spellManager.ActivateSpell(index, number);
        }
        public bool DisplayLearnedSpells()
        {
            Console.Clear();
            View.RenderInfo("===== Poznane Zaklęcia =====", ConsoleColor.Cyan);
            if (_spellManager.LearnedSpellList.Count == 0)
            {
                View.WaitForEnter("Nie poznałeś jeszcze żadnych zaklęć!", ConsoleColor.Red);
                return false;
            }
            _spellView.DisplaySpellsHeaders();
            for (int i = 0; i < _spellManager.LearnedSpellList.Count; i++)
            {
                _spellView.DisplaySpells(i + 1, _spellManager.LearnedSpellList[i]);
            }
            View.RenderInfo("============================", ConsoleColor.Cyan);
            return true;
        }
        public void Update(StateManager stateManager)
        {
            stateManager.PopState();
        }
    }
}
