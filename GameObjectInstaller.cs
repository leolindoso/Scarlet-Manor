using Inventory;
using UnityEngine;
using Zenject;

public class GameObjectInstaller : MonoInstaller
{
    [SerializeField]
    private InventoryController m_inventoryController;
    [SerializeField]
    private GameManager m_gameManager;
    [SerializeField]
    private ItemDatabase m_itemDatabase;
    [SerializeField]
    private SoundController m_soundController;
    [SerializeField]
    private UIManager m_uiManager;

    public override void InstallBindings()
    {
        Container.BindInstance(m_inventoryController).WithId("INVENTORY_CONTROLLER");
        Container.BindInstance(m_gameManager).WithId("GAME_MANAGER");
        Container.BindInstance(m_itemDatabase).WithId("ITEM_DATABASE");
        Container.BindInstance(m_soundController).WithId("SOUND_CONTROLLER");
        Container.BindInstance(m_uiManager).WithId("UI_MANAGER");
    }
}