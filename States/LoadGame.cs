using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters;

namespace RPGGame.States
{
    internal class LoadGame : IGameState
    {
        public void InitState()
        {
            Console.Clear();           
        }
        public void Update(StateManager stateManager)
        {
            (bool exist, int length) saveGameExist = DisplaySaveGames();
            if (saveGameExist.exist)
            {
                View.RenderInfo("Wybierz plik zapisu lub wpisz 0 aby wrócić do menu startowego", ConsoleColor.Yellow);
                int number = InputHandler.SelectOption("Wybierz numer:", 0, saveGameExist.length);
                switch (number)
                {
                    case 0: stateManager.PopState(); break;
                    default:
                        Player player = SaveManager.LoadGame(number - 1);
                        stateManager.ChangeState(new MainMenu(player)); 
                        break;
                }
            }
            else
            {
                View.RenderInfo("1. Wróc do głównego menu", ConsoleColor.White);
                int number = InputHandler.SelectOption("Wybierz numer:", 1, 1);
                stateManager.ChangeState(new StartMenu());
            }
        }
        private (bool, int) DisplaySaveGames()
        {
            List<Player> playerList = SaveManager.GetSavedGames();
            if(playerList.Count == 0)
            {
                View.RenderInfo("Nie ma żadnych zapisanych gier", ConsoleColor.Red);
                return (false, 0);
            }
            View.RenderInfo("===== Wczytaj grę ======", ConsoleColor.White);
            View.RenderInfo("| Lp | Nazwa | HP | Poziom | XP |", ConsoleColor.Cyan);
            for (int i = 0; i < playerList.Count; i++)
            {
                View.DisplaySaveGames(i + 1, playerList[i]);
            }
            View.RenderInfo("========================", ConsoleColor.White);
            return (true, playerList.Count);
        }
    }
}
