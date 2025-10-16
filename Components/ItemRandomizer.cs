using Newtonsoft.Json;
using RPGGame.Gameplay.Items;

namespace RPGGame.Components
{
    internal class ItemRandomizer
    {
        private Random _rnd = new();
        private readonly string _item = File.ReadAllText("../../../Gameplay/ItemsList/Item.json");
        private readonly string _food = File.ReadAllText("../../../Gameplay/ItemsList/Food.json");
        private readonly string _armor = File.ReadAllText("../../../Gameplay/ItemsList/Armor.json");
        private readonly string _weapon = File.ReadAllText("../../../Gameplay/ItemsList/Weapon.json");
        private readonly string _potion = File.ReadAllText("../../../Gameplay/ItemsList/Potion.json");
        private readonly Rarity[] _chance = [Rarity.Common, Rarity.Common, Rarity.Common, Rarity.Common, Rarity.Common, Rarity.Uncommon, Rarity.Uncommon, Rarity.Uncommon, Rarity.Uncommon, Rarity.Rare, Rarity.Rare, Rarity.Rare, Rarity.Epic, Rarity.Epic, Rarity.Legendary];
        public List<T>RandomizeItems<T>(ItemCategory itemCategory, int itemAmount) where T : Item
        {       
            int itemsToGenerate = _rnd.Next(1, itemAmount + 1);
            List<T> itemList = GetItems<T>(itemCategory);
            List<T> newItemList = [];
            for(int i = 0; i < itemsToGenerate; i++)
            {
                int dice = _rnd.Next(0, _chance.Length - 1);
                newItemList.Add(Shuffle<T>(itemList, _chance[dice]));
            }
            return newItemList;
        }
        private List<T> GetItems<T>(ItemCategory itemCategory) where T : Item
        {
            Dictionary<ItemCategory, string> fileString = new() { { ItemCategory.Item, _item }, { ItemCategory.Food, _food }, { ItemCategory.Armor, _armor }, { ItemCategory.Weapon, _weapon }, { ItemCategory.Potion, _potion } };
            List<T> ?list = JsonConvert.DeserializeObject<List<T>>(fileString[itemCategory]);
            if (list != null) return list;
            else throw new InvalidOperationException("");
        }
        private T Shuffle<T>(List<T> list, Rarity rarity) where T : Item => list.Where(item => item.Rarity == rarity).OrderBy(_ => _rnd.Next()).ToList()[0];
    }
}
