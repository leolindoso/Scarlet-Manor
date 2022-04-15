using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public enum ItemType
    {
        drawerKey,
        jewelBoxKey,
        crowbar,
        broom,
        fallCube,
        winterCube,
        springCube,
        summerCube,
        exitKey,
        none
    }
    public class Item
    {
        public int id;
        public string title;
        public string description;
        //public Sprite icon;

        public Item(int id, string title, string description)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            //this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
        }

        public Item(Item item)
        {
            this.id = item.id;
            this.title = item.title;
            this.description = item.description;
            //this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.title);
        }

    }
}
