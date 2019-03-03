using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item  {

    public int itemID; //아이템의 고유 ID값 중복X
    //이미지 파일의 이름을 itemID로 설정해주는 것이 좋다
    public string itemName; //아이템의 이름 중복O
    public string itemDescription; //아이템 설명
    public Sprite itemIcon; //아이템의 아이콘
    public int itemCount=1; //소모품 아이템의 갯수
    public int itemPrice;//아이템 가격 단위는 '편' 단위 입니다
    public ItemType itemType;


    public enum ItemType
    {
        Use, //영혼나무의 수액
        Permanent, //~스톤 
        ETC
    }

    public Item(int _itemID, string _itemName, string _itemDes,int _itemPrice,ItemType _itemType)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemType = _itemType;
        itemPrice = _itemPrice;
        itemIcon = Resources.Load("Sprites/NPC/Goods/" + _itemID.ToString(), typeof(Sprite)) as Sprite;
    }

    public Item(int _itemID, string _itemName, string _itemDes, int _itemPrice, ItemType _itemType,int _itemCount)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemDescription = _itemDes;
        itemPrice = _itemPrice;
        itemCount = _itemCount;
    }
    //소모품을 위한 생성자

    public virtual void Use()
    {
        Debug.Log("Using" + itemName);
    }

}
