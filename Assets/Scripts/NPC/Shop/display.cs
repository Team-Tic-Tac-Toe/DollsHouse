using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class display : MonoBehaviour
{

    List<int> idxList = new List<int>();
    //인덱스만 담는 리스트
    Sprite[] coreMasterSprite; //코어마스터의 물건을 담은 이미지 배열
    public GameObject[] storeSlot;// 상점의 슬롯 게임 오브젝트를 담은 배열
    string resourcePath = "Sprite/UI/";
    int temp;



    // Use this for initialization
    void Start()
    {
        coreMasterSprite = Resources.LoadAll<Sprite>(resourcePath + "goods");
        for (int i = 0; i < coreMasterSprite.Length; i++) //인덱스 리스트
            idxList.Add(i);
        displayGoods();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            right();
            displayGoods();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left();
            displayGoods();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            int center = storeSlot.Length / 2;
            purchasedGoods(idxList[center]);


        }
    }

    void right()
    {
        //0 1 2 3 / 3 0 1 2
        
        temp = idxList[coreMasterSprite.Length-1];
        idxList.RemoveAt(coreMasterSprite.Length-1);
        idxList.Insert(0, temp);
        temp = idxList[coreMasterSprite.Length-1];

        for (int i = 0; i < coreMasterSprite.Length; i++)
        {
            Debug.Log(idxList[i]);

        }
        Debug.Log("=======");

    }
    void left()
    {
        //0 1 2 3 / 1 2 3 4
        temp = idxList[0];
        idxList.RemoveAt(0);
        idxList.Insert(coreMasterSprite.Length-1, temp);
        temp = idxList[0];

        for (int i = 0; i < coreMasterSprite.Length; i++)
        {
            Debug.Log(idxList[i]);

        }
        Debug.Log("=======");
    }
    void displayGoods()
    {
        for (int i = 0; i < storeSlot.Length; i++)
        {
            storeSlot[i].GetComponent<Image>().sprite = coreMasterSprite[idxList[i]];
        }
    }
    void purchasedGoods(int purchase)
    {
        //구매한 물건의 인덱스 받아오기 
        if (ItemMgr.instance.itemList[purchase].itemType == Item.ItemType.Use)
        {
            if (IsContain(purchase) != (-1))
            {
                int idx = IsContain(purchase);
                ItemMgr.instance.useItem[idx].itemCount += 1;
            }
            else
            {
                ItemMgr.instance.useItem.Add(new Item(ItemMgr.instance.itemList[purchase].itemID, ItemMgr.instance.itemList[purchase].itemName,
                                 ItemMgr.instance.itemList[purchase].itemDescription, ItemMgr.instance.itemList[purchase].itemPrice,
                                ItemMgr.instance.itemList[purchase].itemType,ItemMgr.instance.itemList[purchase].itemCount));
            }
        }
        else if (ItemMgr.instance.itemList[purchase].itemType == Item.ItemType.Permanent)
        {

            ItemMgr.instance.buyItem.Add(new Item(ItemMgr.instance.itemList[purchase].itemID, ItemMgr.instance.itemList[purchase].itemName,
                                 ItemMgr.instance.itemList[purchase].itemDescription, ItemMgr.instance.itemList[purchase].itemPrice,
                                ItemMgr.instance.itemList[purchase].itemType));
            //구매한 아이템을 구매한 아이템 리스트에 추가합니다


        }

        Debug.Log("purchase=" + purchase);
       

    }


    public int IsContain(int id)
    {
        for (int i = 0; i < ItemMgr.instance.useItem.Count; i++)
        {
            if (ItemMgr.instance.itemList[id].itemID == ItemMgr.instance.useItem[i].itemID)
            {

                return i;
            }
            //구매된 물건들을 처리하는 코드
        }
        return -1;

    }
}