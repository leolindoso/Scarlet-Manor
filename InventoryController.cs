using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory 
{ 
    public class InventoryController : MonoBehaviour
    {
        public List<Item> playerItems = new List<Item>();
        public ItemDatabase itemDatabase;
        private List<GameObject> itemStots = new List<GameObject>();
        public List<GameObject> ItemSlots => itemStots;

        [Inject(Id = "GAME_MANAGER")]
        private GameManager m_gameManager;

        [SerializeField]
        private Animator m_animator;

        // Start is called before the first frame update
        void Start()
        {
            //GiveItem(0);
            foreach (Transform child in transform)
            {
                itemStots.Add(child.gameObject);
            }
        }

        public void GiveItem(int id)
        {
            Item itemToAdd = itemDatabase.GetItem(id);
            if (!playerItems.Contains(itemToAdd))
            {
                playerItems.Add(itemToAdd);
            }

            UpdateBar();

            Debug.Log("Item adicionado: " + itemToAdd.title);
        }

        public Item CheckForItem(int id)
        {
            return playerItems.Find(item => item.id == id);
        }

        public Item RemoveItem(int id)
        {
            Item itemToRemove = CheckForItem(id);

            if (itemToRemove != null)
            {
                DeactivateItemOnBar(id);
                m_gameManager.SetItemOnHand(ItemType.none);
                playerItems.Remove(itemToRemove);
            }

            Debug.Log("Item removido: " + itemToRemove.title);
            return itemToRemove;
        }

        // adiciona e remove itens na barra
        // TODO: implementar remoção de itens na barra
        public void UpdateBar()
        {
            foreach (Item item in playerItems)
            {
                itemStots[item.id].GetComponent<ItemSlot>().SetActiveItem(true);
            }
        }

        private void DeactivateItemOnBar(int id)
        {
            itemStots[id].GetComponent<ItemSlot>().SetActiveItem(false);
        }

        

        public void SwitchInventory()
        {
            m_animator.SetTrigger("Switch");
        }
    }
}