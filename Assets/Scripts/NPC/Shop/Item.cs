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


        //일단은 영혼나무 수액을 item5로, 융합의 스톤을 item1, 혈의 스톤을 item2, 세례의 스톤을 item3으로 해서 테스트
        if (itemName == "item5") //아이템 = 영혼나무의 수액일 경우 생명 모두 채움 - ok
        {

            //HealthCtrl Health = GameObject.Find("health").GetComponent<HealthCtrl>();
            //Health.health = 8;
            //HealthCtrl.healthinstance.health = 8;
            Debug.Log("before health = " + Controller.GetInstance().playerHealth);
            Controller.GetInstance().playerHealth = 8;
            Debug.Log("after health = " + Controller.GetInstance().playerHealth);
        }
        else if(itemName == "item1") //아이템 = 융합의 스톤일 경우 힘(attackdmg) 10% 증가
        {
            Debug.Log("before attackdmg = " + Controller.GetInstance().attackdmg);
            Controller.GetInstance().attackdmg += (0.1f * Controller.GetInstance().attackdmg) ; //10%증가 어떻게하지?
            Debug.Log("after attackdmg = " + Controller.GetInstance().attackdmg);

        }
        else if(itemName == "item2") //아이템 = 혈의 스톤일 경우 공격 3.5%, 이동속도(Speed) 3.5% 증가
        {
            Debug.Log("after speed = " + Controller.GetInstance().Speed);
            Controller.GetInstance().Speed += (0.035f * Controller.GetInstance().Speed) ;
            Debug.Log("before speed = " + Controller.GetInstance().Speed);

        }
        else if(itemName == "item3") //아이템 = 세례의 스톤일 경우 생명이 하나 추가됨 - ok
        {
            Debug.Log("before health = " + Controller.GetInstance().playerHealth);
            Controller.GetInstance().playerHealth += 1;
            Debug.Log("after health = " + Controller.GetInstance().playerHealth);
        }

        //현재 생명 느는것까지는 구현됐음. 힘 증가랑 공격, 속도 증가남음.. 디버그 로그 해도 왜안뜨지?

    }

}
