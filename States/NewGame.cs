using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters;
using RPGGame.Gameplay.Characters.Entities;
using RPGGame.Gameplay.Shop;
namespace RPGGame.States
{
    internal class NewGame : IGameState
    {
        public void InitState()
        {
            Console.Clear();
            View.RenderInfo("====== Witaj w kreatorze postaci! ======", ConsoleColor.Cyan);
        }
        public Player InitPlayer()
        {
            string name;
            name = InputHandler.GetString("Wpisz swoje imię:");
            Skills skills = new(3, 3, 3, 3, 3, 3, 3, 3, 3, 3);
            View.RenderCreatePlayerInfo();
            skills.SetFreeSkillPoints(20);
            skills.DistributeSkillPoints();
            Player player = new(name, 100, 1, 0, "", skills, new Inventory(50));
            player.GeneratePlayerId();
            return player;
        }
        public void Update(StateManager stateManager)
        {
            Player player = InitPlayer();
            View.DisplayPlayerInfo(player);
            View.RenderInfo("Chcesz rozpocząć grę?", ConsoleColor.Yellow);
            View.RenderMenu(["Rozpocznij grę", "Wyjdź do menu głównego"]);
            int number = InputHandler.SelectOption("Wybierz numer:", 1, 2);
            switch(number)
            {
                case 1: stateManager.ChangeState(new MainMenu(player)); SaveManager.SaveGame(player); ShopManager.UpdateShop(); break;
                case 2: stateManager.ChangeState(new StartMenu()); break;
            }
        }
    }
}
