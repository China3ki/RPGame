using Newtonsoft.Json;
using RPGGame.Gameplay.Items;
using System.Diagnostics;
using System.Text.Json.Serialization;
namespace RPGGame.Gameplay.Characters.Entities
{
    internal class Inventory(int coins)
    {
        [JsonProperty("Items")]
        public List<Item> Items { get; private set; } = [];
        [JsonProperty("PrimaryWeapon")]
        public int PrimaryWeapon { get; private set; } = -1;
        [JsonProperty("SecondaryWeapon")]
        public int SecondaryWeapon { get; private set; } = -1;
        public int Helmet { get; private set; } = -1;
        public int Chestplate { get; private set; } = -1;
        public int Leggings { get; private set; } = -1;
        public int Boots { get; private set; } = -1;
        public int Coins { get; private set; } = coins;
        public int MaxWeight { get; private set; } = 40;
        public void RemoveCoins(int points) => Coins -= points;
        public bool AddItem(Item item)
        {
            int weight = GetCurrentWeight();
            if (MaxWeight < weight + item.Weight) return false;
            Items.Add(item);
            return true;
        }
        public bool RemoveItem(int itemIndex, ItemCategory itemCategory)
        {
            List<Item> itemList = GetItems(itemCategory);
            if (itemIndex >= itemList.Count || itemIndex < 0) return false;
            if (PrimaryWeapon == itemIndex && itemCategory == ItemCategory.Weapon) DeEquip(Slots.PrimaryWeapon);
            if (SecondaryWeapon == itemIndex && itemCategory == ItemCategory.Weapon) DeEquip(Slots.SecondaryWeapon);
            if (Helmet == itemIndex && itemCategory == ItemCategory.Armor) DeEquip(Slots.Helmet);
            if (Chestplate == itemIndex && itemCategory == ItemCategory.Armor) DeEquip(Slots.Chestplate);
            if (Leggings == itemIndex && itemCategory == ItemCategory.Armor) DeEquip(Slots.Leggings);
            if (Boots == itemIndex && itemCategory == ItemCategory.Armor) DeEquip(Slots.Boots);
            int findIndex = Items.IndexOf(itemList[itemIndex]);
            Items.RemoveAt(findIndex);
            return true;
        }
        public bool EquipArmor(int itemIndex)
        {
            List<Armor> armorList = GetTypeOfItems<Armor>();
            if (itemIndex >= armorList.Count || itemIndex < 0) return false;
            switch (armorList[itemIndex].ArmorType)
            {
                case ArmorType.Helmet:
                    DeEquip(Slots.Helmet);
                    Helmet = itemIndex;
                    break;
                case ArmorType.Chestplate:
                    DeEquip(Slots.Chestplate);
                    Chestplate = itemIndex;
                    break;
                case ArmorType.Leggings:
                    DeEquip(Slots.Leggings);
                    Leggings = itemIndex;
                    break;
                case ArmorType.Boots:
                    DeEquip(Slots.Boots);
                    Boots = itemIndex;
                    break;
            }
            armorList[itemIndex].HandleEquip();
            return true;
        }
        public bool EquipWeapon(int itemIndex, WeaponSlot weaponSlot)
        {
            List<Weapon> weaponList = GetTypeOfItems<Weapon>();
            if (itemIndex >= weaponList.Count || itemIndex < 0) return false;
            switch(weaponSlot)
            {
                case WeaponSlot.PrimaryWeapon:
                    DeEquip(Slots.PrimaryWeapon);
                    PrimaryWeapon = itemIndex;
                    break;
                case WeaponSlot.SecondaryWeapon:
                    DeEquip(Slots.SecondaryWeapon);
                    SecondaryWeapon = itemIndex;
                    break;
            }
            weaponList[itemIndex].HandleEquip();
            return true;
        }
        public void DeEquip(Slots slot)
        {
            List<Weapon> weaponList = GetTypeOfItems<Weapon>();
            List<Armor> armorList = GetTypeOfItems<Armor>();
            switch (slot)
            {
                case Slots.PrimaryWeapon:
                    if (PrimaryWeapon != -1) weaponList[PrimaryWeapon].HandleEquip();
                    PrimaryWeapon = -1;
                    break;
                case Slots.SecondaryWeapon:
                    if (SecondaryWeapon != -1) weaponList[SecondaryWeapon].HandleEquip();
                    SecondaryWeapon = -1;
                    break;
                case Slots.Helmet:
                    if (Helmet != -1) armorList[Helmet].HandleEquip();
                    Helmet = -1;
                    break;
                case Slots.Chestplate:
                    if (Chestplate != -1) armorList[Chestplate].HandleEquip();
                    Chestplate = -1;
                    break;
                case Slots.Leggings:
                    if (Leggings != -1) armorList[Leggings].HandleEquip();
                    Leggings = -1;
                    break;
                case Slots.Boots:
                    if (Boots != -1) armorList[Boots].HandleEquip();
                    Boots = -1;
                    break;
            }
        }
        public T GetItem<T>(int index) => Items.OfType<T>().ToList()[index]; 
        public List<Item> GetItems(ItemCategory itemCategogry) => Items.Where(item => item.ItemCategory == itemCategogry).Select(item => item).ToList(); 
        public List<T> GetTypeOfItems<T>() => Items.OfType<T>().ToList();
        public int GetCurrentWeight() => Items.Sum(item => item.Weight);
    }
}
