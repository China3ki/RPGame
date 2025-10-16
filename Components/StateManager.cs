using RPGGame.Components.Interfaces;
using RPGGame.States;

namespace RPGGame.Components
{
    internal class StateManager
    {
        private Stack<IGameState> _states = new();
        public void RunApp()
        {
            PushState(new StartMenu());
            do
            {
                _states.Peek().InitState();
                Update();
            } while (_states.Count > 0);
        }
        public void PushState(IGameState gameState)
        {
            _states.Push(gameState);
        }
        public void ChangeState(IGameState gameState)
        {
            PopState();
            _states.Push(gameState);
        }
        public void PopState()
        {
            if(_states.Count > 0) _states.Pop();
        }
        public void ClearStates() => _states.Clear();
        private void Update()
        {
            if (_states.Count > 0) _states.Peek().Update(this);
        }
    }
}
