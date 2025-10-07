namespace RPGGame.Gameplay.Characters
{
    internal class Character(string name, int hp, Skills skills, Inventory inventory)
    {
        public string Name { get; private set; } = name;
        public int Hp { get; private set; } = hp;
        public Skills Skills { get; private set; } = skills;
        public Inventory Inventory { get; private set; } = inventory;
    }
}
