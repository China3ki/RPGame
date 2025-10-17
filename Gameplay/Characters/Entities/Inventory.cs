using RPGGame.Gameplay.Items;
namespace RPGGame.Gameplay.Characters.Entities
{
    internal class Inventory
    {
        public List<Item> Items { get; private set; } = [];
        public Weapon ?PrimaryWeapon { get; private set; }
        public Weapon ?SecondaryWeapon { get; private set; }
        public Armor ?Helmet { get; private set; }
        public Armor ?Chestplate { get; private set; }
        public Armor ?Leggings { get; private set; }
        public Armor ?Boots { get; private set; }
        public int MaxWeight { get; private set; } = 40;
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
            Item item = itemList[itemIndex];
            if (PrimaryWeapon == item) DeEquip(Slots.PrimaryWeapon);
            if (SecondaryWeapon == item) DeEquip(Slots.SecondaryWeapon);
            if (Helmet == item) DeEquip(Slots.Helmet);
            if (Chestplate == item) DeEquip(Slots.Chestplate);
            if (Leggings == item) DeEquip(Slots.Leggings);
            if (Boots == item) DeEquip(Slots.Boots);
            int findIndex = Items.IndexOf(itemList[itemIndex]);
            Items.RemoveAt(findIndex);
            return true;
        }
        public bool EquipArmor(int itemIndex)
        {
            List<Armor> armorList = GetTypeOfItems<Armor>();
            if (itemIndex >= armorList.Count || itemIndex < 0) return false;
            Armor armor = armorList[itemIndex];
            switch(armor.ArmorType)
            {
                case ArmorType.Helmet:
                    DeEquip(Slots.Helmet);
                    Helmet = armor;
                    break;
                case ArmorType.Chestplate:
                    DeEquip(Slots.Chestplate);
                    Chestplate = armor;
                    break;
                case ArmorType.Leggings:
                    DeEquip(Slots.Leggings);
                    Leggings = armor;
                    break;
                case ArmorType.Boots:
                    DeEquip(Slots.Boots);
                    Boots = armor;
                    break;
            }
            armor.HandleEquip();
            return true;
        }
        public bool EquipWeapon(int itemIndex, WeaponSlot weaponSlot)
        {
            List<Weapon> weaponList = GetTypeOfItems<Weapon>();
            if (itemIndex >= weaponList.Count || itemIndex < 0) return false;
            Weapon weapon = weaponList[itemIndex];
            switch(weaponSlot)
            {
                case WeaponSlot.PrimaryWeapon:
                    DeEquip(Slots.PrimaryWeapon);
                    PrimaryWeapon = weapon;
                    break;
                case WeaponSlot.SecondaryWeapon:
                    DeEquip(Slots.SecondaryWeapon);
                    SecondaryWeapon = weapon;
                    break;
            }
            weapon.HandleEquip();
            return true;
        }
        public void DeEquip(Slots slot)
        {
            switch(slot)
            {
                case Slots.PrimaryWeapon:
                    if (PrimaryWeapon != null) PrimaryWeapon.HandleEquip();
                    PrimaryWeapon = null;
                    break;
                case Slots.SecondaryWeapon:
                    if (SecondaryWeapon != null) SecondaryWeapon.HandleEquip();
                    SecondaryWeapon = null;
                    break;
                case Slots.Helmet:
                    if (Helmet != null) Helmet.HandleEquip();
                    Helmet = null;
                    break;
                case Slots.Chestplate:
                    if (Chestplate != null) Chestplate.HandleEquip();
                    Chestplate = null;
                    break;
                case Slots.Leggings:
                    if (Leggings != null) Leggings.HandleEquip();
                    Leggings = null;
                    break;
                case Slots.Boots:
                    if (Boots != null) Boots.HandleEquip();
                    Boots = null;
                    break;
            }
        }
        public List<Item> GetItems(ItemCategory itemCategogry) => Items.Where(item => item.ItemCategory == itemCategogry).Select(item => item).ToList(); 
        public List<T> GetTypeOfItems<T>() => Items.OfType<T>().ToList();
        public int GetCurrentWeight() => Items.Sum(item => item.Weight);
    }
}
