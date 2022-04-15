using Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    private int NONE_ITEM_ID = 9;
    private const string PLACED_FALL_CUBE_STRING = "PLACED_FALL_CUBE";
    private const string PLACED_WINTER_CUBE_STRING = "PLACED_WINTER_CUBE";
    private const string PLACED_SPRING_CUBE_STRING = "PLACED_SPRING_CUBE";
    private const string PLACED_SUMMER_CUBE_STRING = "PLACED_SUMMER_CUBE";

    [SerializeField]
    private ItemType m_itemOnHandType;

    [Inject(Id = "INVENTORY_CONTROLLER")]
    private InventoryController m_inventoryController;
    [Inject(Id = "ITEM_DATABASE")]
    private ItemDatabase m_itemDatabase;

    private Item m_itemOnHand;

    [SerializeField]
    private Dictionary<string, bool> m_puzzleVariables = new Dictionary<string, bool>();

    [Header("PuzzleVariables")]
    [SerializeField]
    private bool m_placedFallCube;
    [SerializeField]
    private bool m_placedWinterCube;
    [SerializeField]
    private bool m_placedSpringCube;
    [SerializeField]
    private bool m_placedSummerCube;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item GetItemOnHand()
    {
        if(m_itemOnHand == null)
        {
            return m_itemDatabase.GetItem(NONE_ITEM_ID);
        }

        return m_itemOnHand;
    }

    public void SetItemOnHand(ItemType itemType)
    {
        NONE_ITEM_ID = (int)itemType;
        m_itemOnHand = m_itemDatabase.GetItem(NONE_ITEM_ID);
        m_itemOnHandType = itemType;
    }

    public bool GetPuzzleVariable(string key)
    {
        switch (key)
        {
            case PLACED_FALL_CUBE_STRING:
                return m_placedFallCube;
            case PLACED_WINTER_CUBE_STRING:
                return m_placedWinterCube;
            case PLACED_SPRING_CUBE_STRING:
                return m_placedSpringCube;
            case PLACED_SUMMER_CUBE_STRING:
                return m_placedSummerCube;
        }
        return false;
    }

    public void SetPuzzleVariableTrue(string key)
    {
        switch (key)
        {
            case PLACED_FALL_CUBE_STRING:
                m_placedFallCube = true;
                break;
            case PLACED_WINTER_CUBE_STRING:
                m_placedWinterCube = true;
                break;
            case PLACED_SPRING_CUBE_STRING:
                m_placedSpringCube = true;
                break;
            case PLACED_SUMMER_CUBE_STRING:
                m_placedSummerCube = true;
                break;
        }
    }

    public void UpdatePuzzleVariablesDict()
    {
        if(m_puzzleVariables.Count == 0)
        {
            m_puzzleVariables.Add(PLACED_FALL_CUBE_STRING,m_placedFallCube);
            m_puzzleVariables.Add(PLACED_WINTER_CUBE_STRING, m_placedWinterCube);
            m_puzzleVariables.Add(PLACED_SPRING_CUBE_STRING, m_placedSpringCube);
            m_puzzleVariables.Add(PLACED_SUMMER_CUBE_STRING, m_placedSummerCube);
        }
        else
        {
            foreach(string key in m_puzzleVariables.Keys)
            {
                switch (key)
                {
                    case PLACED_FALL_CUBE_STRING:
                        m_puzzleVariables[PLACED_FALL_CUBE_STRING] = m_placedFallCube;
                        break;
                    case PLACED_WINTER_CUBE_STRING:
                        m_puzzleVariables[PLACED_WINTER_CUBE_STRING] = m_placedWinterCube;
                        break;
                    case PLACED_SPRING_CUBE_STRING:
                        m_puzzleVariables[PLACED_SPRING_CUBE_STRING] = m_placedSpringCube;
                        break;
                    case PLACED_SUMMER_CUBE_STRING:
                        m_puzzleVariables[PLACED_SUMMER_CUBE_STRING] = m_placedSummerCube;
                        break;
                }
            }
        }
    }

    public void FimDeJogo()
    {
        Debug.Log("Acabou");
        SceneManager.LoadScene("Fim");
    }
}
