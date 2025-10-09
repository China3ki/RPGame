using RPGGame.Components.Interfaces;
using RPGGame.Gameplay.Items;
using System;

namespace RPGGame.Gameplay.Characters
{
    internal class Inventory(int maxWeight)
    {
        public List<Item> Items { get; } = [];
        public Weapon ?PrimaryWeapon { get; private set; }
        public Weapon ?SecondaryWeapon { get; private set; }
        public Armor ?Helmet { get; private set; }
        public Armor ?Chestplate { get; private set; }
        public Armor ?Leggings { get; private set; }
        public Armor ?Boots { get; private set; }
        public int MaxWeight { get; private set; } = maxWeight;
        public int Weight { get; private set; } = 40;
        public bool AddItem(Item item)
        {
            if (Weight + item.Weight > MaxWeight) return false;
            Items.Add(item);
            return true;
        }
        public void UpdateCondition()
        {
            List<Food> foodList = GetItemsOfType<Food>();
            foreach(Food food in foodList)
            {
                food.UpdateCondition();
            }
        }
        public bool RemoveItem<T>(int index) where T : Item
        {
            List<T> list = GetItemsOfType<T>();
            if (index >= list.Count || index < 0) return false;
            if (PrimaryWeapon == list[index]) DeEquip(InventorySlots.PrimaryWeapon);
            if (SecondaryWeapon == list[index]) DeEquip(InventorySlots.SecondaryWeapon);
            if (Helmet == list[index]) DeEquip(InventorySlots.Helmet);
            if (Chestplate == list[index]) DeEquip(InventorySlots.Chestplate);
            if (Leggings == list[index]) DeEquip(InventorySlots.Leggings);
            if (Boots == list[index]) DeEquip(InventorySlots.Boots);
            int itemIndex = Items.IndexOf(list[index]);
            Items.RemoveAt(itemIndex);
            return true;
        }
        public bool EquipWeapon(WeaponSlots weaponSlot, int index)
        {
            List<Weapon> weaponList = GetItemsOfType<Weapon>();
            if (index >= weaponList.Count || index < 0) return false;
            Weapon weapon = weaponList[index];
            switch(weaponSlot)
            {
                case WeaponSlots.Primary:
                    DeEquip(InventorySlots.PrimaryWeapon);
                    PrimaryWeapon = weapon;
                    break;
                case WeaponSlots.Secondary:
                    DeEquip(InventorySlots.SecondaryWeapon);
                    SecondaryWeapon = weapon;
                    break;
            }
            weapon.HandleEquip();
            return true;
        }
        public bool EquipArmor(int index)
        {
            List<Armor> armorList = GetItemsOfType<Armor>();
            if (index >= armorList.Count || index < 0) return false;
            Armor armor = armorList[index];
            switch(armor.ArmorType)
            {
                case ArmorType.Helmet:
                    DeEquip(InventorySlots.Helmet);
                    Helmet = armor;
                    break;
                case ArmorType.Chestplate:
                    DeEquip(InventorySlots.Chestplate);
                    Chestplate = armor;
                    break;
                case ArmorType.Leggings:
                    DeEquip(InventorySlots.Leggings);
                    Leggings = armor;
                    break;
                case ArmorType.Boots:
                    DeEquip(InventorySlots.Boots);
                    Boots = armor;
                    break;
            }
            armor.HandleEquip();
            return true;
        }
        public bool DeEquip(InventorySlots slot)
        {
            Dictionary<InventorySlots, IEquip?> slots = new() { { InventorySlots.PrimaryWeapon, PrimaryWeapon }, { InventorySlots.SecondaryWeapon, SecondaryWeapon }, { InventorySlots.Helmet, Helmet }, { InventorySlots.Chestplate, Chestplate }, { InventorySlots.Leggings, Leggings }, { InventorySlots.Boots, Boots } };
            if (slots[slot] != null) slots[slot]?.HandleEquip();
            slots[slot] = null;
            return true;
        }
        public List<T> GetItemsOfType<T>() where T: Item => Items.OfType<T>().ToList();
    }
}
