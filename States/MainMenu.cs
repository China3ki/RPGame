using RPGGame.Components;
using RPGGame.Components.Gui;
using RPGGame.Components.InputHandlers;
using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Characters;

namespace RPGGame.States
{
    internal class MainMenu(Player player) : IGameState
    {
        private Player _player = player;
        public void InitState()
        {
            Console.Clear();
            View.RenderInfo("===== RPGame =====", ConsoleColor.Cyan);
            View.RenderMenu(["Kolejna tura", "Ekwipunek", "Zaklęcia", "Sklep", "Statystyki", "Moja postać", "Zapisz grę", "Wczytaj grę", "Wyjdż"]);
        }
        public int ChooseOption()
        {
            int number;
            number = InputHandler.SelectOption("Wybierz numer:", 1, 9);               
            return number;
        }
        public void Update(StateManager stateManager)
        {
            int number = ChooseOption();
            switch(number)
            {
                case 2: stateManager.PushState(new InventoryMenu(_player)); break;
                case 3: stateManager.PushState(new SpellMenu(_player.SpellManager)); break;
                case 4: stateManager.PushState(new ShopMenu(_player.Inventory, _player.Stats)); break;
                case 5: stateManager.PushState(new StatsMenu(_player.Stats)); break;
                case 6: stateManager.PushState(new CharacterMenu(_player)); break;
                case 7: SaveManager.SaveGame(_player); break;
                case 8: stateManager.PushState(new LoadGame()); break;
                case 9:
                    SaveManager.SaveGame(_player);
                    stateManager.ClearStates(); 
                    break;
            }
        }
    }
}
