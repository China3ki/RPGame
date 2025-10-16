using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters;

namespace RPGGame.States
{
    internal class CharacterMenu(Player player) : IGameState
    {
        private Player _player = player;
        private string[] _menu = ["Przydziel punkty", "Wstecz"];
        public void InitState()
        {
            Console.Clear();
            View.DisplayPlayerInfo(_player);
            View.RenderMenu(_menu);
        }
        public int ChooseOption()
        {
            int number;
            do
            {
                number = InputHandler.SelectOption("Wybierz numer:", 1, 2);
                if (number == 1)
                {
                    if (_player.Skills.FreeSkillPoints > 0)
                    {
                        _player.Skills.DistributeSkillPoints();
                        InitState();
                    }
                    else View.RenderInfo("Nie masz punktów do rozsdysponowania!", ConsoleColor.Red);
                }
            } while (number == 1);
            return number;
        }
        public void Update(StateManager stateManager)
        {
            int number = ChooseOption();
            switch(number)
            {
                case 2: stateManager.PopState(); break;
            }
        }
    }
}
