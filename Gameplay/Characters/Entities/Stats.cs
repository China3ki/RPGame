namespace RPGGame.Gameplay.Characters.Entities
{
    internal class Stats(int turnsPlayed, int damageGiven, int DamageTaken, int ItemPurchased, int itemSold,  int moneySpent)
    {
        public int TurnsPlayed { get; set; } = turnsPlayed;
        public int DamageGiven { get; set; } = damageGiven;
        public int DamageTaken { get; set; } = DamageTaken;
        public int ItemPurchased { get; set; } = ItemPurchased;
        public int ItemsSold { get; set; } = itemSold;
        public int MoneySpent { get; set; } = moneySpent;
    }
}
