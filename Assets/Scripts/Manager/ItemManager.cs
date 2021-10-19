using Item;
using UnityEngine;
using Weapon.Data;

namespace Manager
{
    public class ItemManager : Singleton<ItemManager>
    {
        public GameObject defaultItemPrefab;

        public void DropItem(BaseItemData item)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + Random.Range(-2f, 2f), transform.position.y + Random.Range(-2f, 2f), 0);
            var itemDropped = Instantiate(defaultItemPrefab, spawnPosition, Quaternion.identity);
            var control = itemDropped.GetComponent<ItemPickup>();
            control.data = item;
            control.Render();
        }
        
        public void DropItem(BaseWeaponData weapon)
        {
            // DropItem(item);
        }

        public void EntityDeadDropItems(BaseItemData[] items)
        {
            if (items.Length == 0)
                return;
            
            bool isAlreadySpawnWeapon = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (isAlreadySpawnWeapon)
                    break;
                
                if (Random.value <= items[i].dropRate)
                {
                    DropItem(items[i]);
                    if (items[i] is WeaponItemData)
                        isAlreadySpawnWeapon = true;
                }
            }   
        }
    }
}
