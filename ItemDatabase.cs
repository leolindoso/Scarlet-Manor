using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class ItemDatabase : MonoBehaviour
    {
        public List<Item> items;
        private void Awake()
        {
            BuildDatabase();
        }

        public Item GetItem(int id)
        {
            return items.Find(item => item.id == id);
        }

        public Item GetItem(string itemName)
        {
            return items.Find(item => item.title == itemName);
        }

        private void BuildDatabase()
        {
            items = new List<Item>()
        {
            new Item(id: (int) ItemType.drawerKey, title: "drawerKey", description: "Chave para uma gaveta"),
            new Item(id: (int) ItemType.jewelBoxKey, title: "jewelBoxKey", description: "Chave da Caixa de Jóias"),
            new Item(id: (int) ItemType.crowbar, title: "axe", description: "Machado"),
            new Item(id: (int) ItemType.broom, title: "broom", description: "Vassoura"),
            new Item(id: (int) ItemType.fallCube, title: "fallCube", description: "Cubo do Outono"),
            new Item(id: (int) ItemType.winterCube, title: "winterCube", description: "Cubo do Inverno"),
            new Item(id: (int) ItemType.springCube, title: "springCube", description: "Cubo da Primavera"),
            new Item(id: (int) ItemType.summerCube, title: "summerCube", description: "Cubo do Verão"),
            new Item(id: (int) ItemType.exitKey, title: "exitKey", description: "Chave da Saída"),
            new Item(id: (int) ItemType.none, title: "none", description: "none"),
        };
        }


    }
}