using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Inventory
{
    public class ItemSlot : MonoBehaviour
    {
        public ItemType itemType;
        public GameManager gameManager;

        private Button m_button;
        private Image m_image;
        private Image m_highLightImage;

        [Inject(Id = "INVENTORY_CONTROLLER")]
        private InventoryController m_inventoryController;

        // Start is called before the first frame update
        void Start()
        {
            m_button = gameObject.GetComponent<Button>();
            m_image = gameObject.GetComponent<Image>();
            m_button.onClick.AddListener(()=> ClickOnSlot());

            // desativa os itens inicialmente
            m_button.enabled = false;
            m_image.enabled = false;
            m_highLightImage = transform.GetChild(0).GetComponent<Image>();
            m_highLightImage.enabled = false;
        }

        void ClickOnSlot()
        {
            var selectedItem = gameManager.GetItemOnHand();
            
            // nenhum selecionado
            if (selectedItem.id == (int) ItemType.none)
            {
                gameManager.SetItemOnHand(itemType);
                m_highLightImage.enabled = true;
            }
            
            // se clicar em outro
            //BUGADO
            else if (selectedItem.id != (int) itemType)
            {
                ChangeSelectedItem(oldSlot: selectedItem.id, newSlot: (int) itemType, itemType);
            }

            // se clicar no mesmo
            else
            {
                gameManager.SetItemOnHand(ItemType.none);
                m_highLightImage.enabled = false;
            }
        }

        // desabilita o contorno do item antigo e habilita o contorno do novo
        public void ChangeSelectedItem(int oldSlot, int newSlot, ItemType newItem)
        {
            var oldBackground = m_inventoryController.ItemSlots[oldSlot].transform.GetChild(0);
            oldBackground.GetComponent<Image>().enabled = false;

            var newBackground = m_inventoryController.ItemSlots[newSlot].transform.GetChild(0);
            newBackground.GetComponent<Image>().enabled = true;

            gameManager.SetItemOnHand(itemType);
        }

        void UseItem()
        {
            //gameObject.GetComponent<Button>().enabled = false;
            m_image.enabled = false;
            m_highLightImage.enabled = false;
        }
        public void SetActiveItem(bool status)
        {
            m_button.enabled = status;
            m_image.enabled = status;
            if (!status)
            {
                m_highLightImage.enabled = status;
            }

        }
        
        public void SetSelectedItem(bool status)
        {
            m_highLightImage.enabled = status;
        }
    }
}