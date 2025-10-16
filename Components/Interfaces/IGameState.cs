namespace RPGGame.Components.Interfaces
{
    internal interface IGameState
    {
        public void InitState();
        public void Update(StateManager stateManager);
    }
}
