
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayGoods : MonoBehaviour
{

    public static displayGoods instance;
    public Sprite[] coreMasterDisplayImage;
    public GameObject selectedObject;
    public GameObject[] displaySlot;//여기에는 오브젝트가 삽입 
    public List<int> coreMasterIdx = new List<int>();
    public int tmpIdx;//변경되는 인덱스 저장
    string resourcePath = "Sprite/UI/";
    int centerIdx = 1;//중간인덱스 저장
    int slotCnt = 3;
    int buyIdx;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i <= coreMasterDisplayImage.Length; i++)
        {
            coreMasterIdx.Add(i);

        }
        coreMasterDisplayImage = Resources.LoadAll<Sprite>(resourcePath + "goods");
        displayObject();



    }

    // Update is called once per frame
    void Awake()
    {
        displayGoods.instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {

            rightMove();
            displayObject();


        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            leftMove();
            displayObject();
        }


    }
    //인스턴스화 다른 스크립트에서도 접근가능 

    void displayObject()
    {
        for (int i = 0; i < numberToCreate; i++)
        {
            Debug.Log(i);
            displaySlot[i].GetComponent<Image>().sprite = coreMasterDisplayImage[coreMasterIdx[i]];

        }

    }
    public void rightMove()
    {

        //1 2 3 4 , 4 1 2 3
        Debug.Log("오른쪽 이동");

        tmpIdx = coreMasterIdx[numberToCreate];
        coreMasterIdx.RemoveAt(numberToCreate);
        coreMasterIdx.Insert(0, tmpIdx);
        tmpIdx = coreMasterIdx[numberToCreate];

    }

    public void leftMove()
    {
        // 1 2 3 4 , 2 3 4 1
        tmpIdx = coreMasterIdx[0];
        coreMasterIdx.RemoveAt(0);
        coreMasterIdx.Insert(numberToCreate, tmpIdx);
        tmpIdx = coreMasterIdx[0];

    }

    public void InvisibleObject()
    {

        if (ItemMgr.instance.itemList[coreMasterIdx[1]].itemType == Item.ItemType.Permanent)
        {
            if (coreMasterIdx.Count > 2)
            {
                buyIdx = 1;
                ItemMgr.instance.buyItem.Add(ItemMgr.instance.itemList[coreMasterIdx[buyIdx]]);
                coreMasterIdx.RemoveAt(buyIdx);

            }
            else
            {
                buyIdx = 0;
                ItemMgr.instance.buyItem.Add(ItemMgr.instance.itemList[coreMasterIdx[buyIdx]]);
                coreMasterIdx.RemoveAt(buyIdx);
                displaySlot[slotCnt - 1].SetActive(false);
            }
        }
        else if (ItemMgr.instance.itemList[coreMasterIdx[1]].itemType == Item.ItemType.Use)
        {
            int idx = isContain(ItemMgr.instance.itemList[coreMasterIdx[buyIdx]].itemID);
            if (idx != -1)
            {

                ItemMgr.instance.useItem[idx].itemCount = ItemMgr.instance.useItem[idx].itemCount + 1;
                Debug.Log(ItemMgr.instance.useItem[idx].itemCount);
            }
            else
            {
                ItemMgr.instance.useItem.Add(new Item(ItemMgr.instance.itemList[buyIdx].itemID, ItemMgr.instance.itemList[buyIdx].itemName,
                     ItemMgr.instance.itemList[buyIdx].itemDescription, ItemMgr.instance.itemList[buyIdx].itemPrice,
                    ItemMgr.instance.itemList[buyIdx].itemType, ItemMgr.instance.itemList[buyIdx].itemCount));

            }

        }


    }
    //엔터를 입력하면 가운데에 있는 물건이 사라진다 
    //구매한 물건이 소비(계속 구매가능) 영구적인것(한번만 구매가능) 한지 구분한다.
    //
    //
    public int isContain(int id)
    {
        for (int i = 0; i < ItemMgr.instance.useItem.Count; i++)
        {
            if (ItemMgr.instance.itemList[coreMasterIdx[buyIdx]].itemID == ItemMgr.instance.useItem[i].itemID)
            {

                return i;
            }


        }
        return -1;
    }
}
