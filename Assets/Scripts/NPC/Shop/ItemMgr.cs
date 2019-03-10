using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour {
    //아이템들을 관리하는 클래스

    public static ItemMgr instance;

    private List<Item> ItemData = new List<Item>();//데이터상 존재하는 아이템 모두를 가지는 리스트
    public List<Item> itemList = new List<Item>();//데이터상 존재하는 아이템->인 게임에 올라오는 아이템 리스트
    public List<Item> buyItem = new List<Item>();//인게임에 올라온 아이템 리스트 중에서 ->상점에서 구매한 아이템을 저장하는 리스트
    public List<Item> useItem = new List<Item>();//use 타입 아이템만 모아놓은 리스트

    void Awake()
    {
        ItemMgr.instance = this;
    }

    // Use this for initialization
    void Start () {


        ItemData.Add(new Item(01, "영혼 나무의 수액", "현재 최대 가질 수 있는 생명을 모두채운다.", 300, Item.ItemType.Use));
        ItemData.Add(new Item(02, "융합의 스톤", "10% 힘이 증가한다.", 500, Item.ItemType.Permanent));
        ItemData.Add(new Item(03, "혈의 스톤", "3.5%공격,이동속도가 증가한다.", 500, Item.ItemType.Permanent));
        ItemData.Add(new Item(04, "세례의 스톤", "가질 수 있는 생명의 갯수가 하나 추가 된다.", 500, Item.ItemType.Permanent));
        //아이템 데이타를 추가할때는 여기에다 추가하면 됨!

        for (int i = 0; i < ItemData.Count; i++)
            itemList.Add(new Item(ItemData[i].itemID,ItemData[i].itemName,ItemData[i].itemDescription,ItemData[i].itemPrice,ItemData[i].itemType));
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
