using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopMgr : MonoBehaviour {

    //상점에 진열한 물건개수 만큼 동적 생성
    //버튼을 누르면 그 물건들이 로테이션 됨
    //물건 구매 -> 구매한 물건의 속성에 따라서 다르게 처리한다

    List<Item> itemList_coreMaster = new List<Item>();
    List<Item> itemList_dollMaster = new List<Item>();

    // Use this for initialization
    void Start () {
        shop coreMaster = 
            new shop(3, 4, 4, shop.MerchantType.coreMaster);
        //임시로 사용하는 리스트 
        //나중에는 파일로 저장하고 불러와야함
        itemList_coreMaster.Add(new Item(01, "영혼 나무의 수액", "현재 최대 가질 수 있는 생명을 모두채운다.", 300, Item.ItemType.Use));
        itemList_coreMaster.Add(new Item(02, "융합의 스톤", "10% 힘이 증가한다.", 500, Item.ItemType.Permanent));
        itemList_coreMaster.Add(new Item(03, "혈의 스톤", "3.5%공격,이동속도가 증가한다.", 500, Item.ItemType.Permanent));
        itemList_coreMaster.Add(new Item(04, "세례의 스톤", "가질 수 있는 생명의 갯수가 하나 추가 된다.", 500, Item.ItemType.Permanent));

        shop dollMaster =
            new shop(3, 4, 4, shop.MerchantType.dollMaster);
        itemList_dollMaster.Add(new Item(01, "인형어쩌구", "bbb", 1000, Item.ItemType.ETC));



    }
	
	// Update is called once per frame
	void Update () {
		


	}

    
}
