using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public class ItemColect : MonoBehaviour
    {
        private Button button;
        public InventoryController inventoryController;
        public ItemType itemType;

        private void Start()
        {
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(() => inventoryController.GiveItem((int)itemType));
        }

        public void GetItem(ItemType itemType)
        {
            inventoryController.GiveItem((int)itemType);
        }
    }
}