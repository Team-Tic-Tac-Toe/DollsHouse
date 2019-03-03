using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }
    #endregion

    public Item[] Items;

    //test용 아이템 먹기
    public void itempickup()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("a");
            Add(Items[0]);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("b");
            Add(Items[1]);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("c");
            Add(Items[2]);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("d");
            Add(Items[3]);
        }
    }

    private void Update()
    {
        itempickup();
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if(items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items.Add(item);

        if(onItemChangedCallback != null)
        onItemChangedCallback.Invoke();

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}
