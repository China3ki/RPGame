using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;

namespace RPGGame.States
{
    internal class StartMenu : IGameState
    {
        private readonly string[] _menu = ["Nowa gra", "Wczytaj grę", "Wyjdź"];
        public void InitState()
        {
            Console.Clear();
            View.RenderInfo("====== Witaj w grze RPG ======", ConsoleColor.Cyan);
            View.RenderMenu(_menu);
        }
        public void Update(StateManager stateManager)
        {
            int number = InputHandler.SelectOption("Wybierz numer:", 1, _menu.Length);
            switch(number)
            {
                case 1: stateManager.ChangeState(new NewGame()); break;
                case 2: stateManager.PushState(new LoadGame()); break;
                case 3: stateManager.ClearStates(); break;
            }
        }
    }
}
