using Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Zenject;

public class ClickableObject: MonoBehaviour,IClickable
{
    public UnityEvent m_actionsToExecute;
    public UnityEvent m_actionsToExecuteWhenBlocked;


    [Header("Itens")]
    [SerializeField]
    private ItemType m_itemToCollectType;
    [SerializeField]
    private ItemType m_itemRequiredType;

    [Inject(Id = "INVENTORY_CONTROLLER")]
    private InventoryController m_inventoryController;
    [Inject(Id = "GAME_MANAGER")]
    private GameManager m_gameManager;
    [Inject(Id = "ITEM_DATABASE")]
    private ItemDatabase m_itemDatabase;
    [Inject(Id = "SOUND_CONTROLLER")]
    private SoundController m_soundController;
    [Inject(Id = "UI_MANAGER")]
    private UIManager m_uiManager;

    private void OnEnable()
    {
        Button button = gameObject.GetComponent<Button>();
        if (button == null)
        {
            button = gameObject.AddComponent<Button>();
        }
        button.onClick.AddListener(() => Execute());
    }
    public void Execute()
    {
        Item itemOnHand = m_gameManager.GetItemOnHand();
        Debug.Log($"Executando ações de {this.name}");
        if(itemOnHand.id == (int)m_itemRequiredType || m_itemRequiredType == ItemType.none)
        {
            m_actionsToExecute.Invoke();
        }
        else
        {
            Debug.Log($"Preciso de um {m_itemDatabase.GetItem((int)m_itemRequiredType).title}");
            m_actionsToExecuteWhenBlocked.Invoke();
        }
    }
    public void TryGetItem()
    {
            if (m_itemToCollectType == ItemType.none)
            {
                Debug.Log("Não há o que coletar aqui");
                return;
            }
            m_inventoryController.GiveItem((int)m_itemToCollectType);
    }

    public void PlaySound(AudioClip clip)
    {
        m_soundController.PlaySound(clip);
    }

    public void ShowDialog(string dialogText)
    {
        m_uiManager.CallShowDialog(dialogText);
    }
    
    public void RemoveItemFromInventory()
    {
        m_inventoryController.RemoveItem(m_gameManager.GetItemOnHand().id);
    }

    public void SetPuzzleVariableTrue(string key)
    {
        m_gameManager.SetPuzzleVariableTrue(key);
    }
}
