using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StoreMgr : MonoBehaviour
{

    public static StoreMgr instance;
    //버튼을 클릭하면 작동해야하는 함수를 작성합니다
    //공격범위 체력 공격력 공격속도를 강화합니다
    //해당 버튼을 누르면 관련된 능력치를 현재상태에서 한레벨 업그레이드 시킨 임시값을 가져옵니다
    //if문을 사용하여 업그레이드 버튼을 눌럿을때 해당 조건의 돈을 가지고 있지 않으면 
    //아무일도 일어나지 않고 가지고 있으면 임시값을 캐릭터의 능력치에 적용합니다

    /*int AttackRangeLv = 1;
int HpLv = 1;
int PowerLv = 1;
int SpeedLv = 1;
*/

    /// 아이템 관련 변수

    public GameObject[] Pos; //아이템의 위치를 담는 오브젝트 배열
    public Vector2[] goodsPos; //아이템의 위치를 담는 벡터 배열
    public GameObject[] goodsIcon; //아이템의 Icon을 담는 배열 

    int currentPoint;
    int r_count = 0;
    int l_count = 0;
    int goods = 3;
    int temp;
    public int buy_item;
    int idx = 1;
    int currMoney = 3000;
    int useTypeIdx ;

    public int slotcount = 1;
    public bool buy=false;
    public Text ItemName;
    public Text ItemDesc;
    public Text moneyTxt;

    public List<Item> itemList = new List<Item>();
    public List<int> buyItemID = new List<int>();

    private List<Item> typeUse = new List<Item>();
    private List<int> num = new List<int>();

    public static StoreMgr GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<StoreMgr>();
        }
        return instance;
    }
    void Awake()
    {
        buy = false;
        instance = this;
    }
    private void Start()
    {
        

        currentPoint = 0;


        //아이템의 이름 설명 저장합니다//
        itemList.Add(new Item(01, "영혼 나무의 수액", "현재 최대 가질 수 있는 생명을 모두채운다.",300, Item.ItemType.Use));
        itemList.Add(new Item(02, "융합의 스톤", "10% 힘이 증가한다.", 500,Item.ItemType.Permanent));
        itemList.Add(new Item(03, "혈의 스톤", "3.5%공격,이동속도가 증가한다.", 500, Item.ItemType.Permanent));
        itemList.Add(new Item(04, "세례의 스톤", "가질 수 있는 생명의 갯수가 하나 추가 된다.", 500, Item.ItemType.Permanent));

        /////물건의 위치 저장////고정입니다////
        //소모품의 갯수 
        //살때 소모품 몇개를 살껀지
        //소모품은 품절되지 않습니다
        ItemName.GetComponent<Text>().text = itemList[1].itemName;
        ItemDesc.GetComponent<Text>().text = itemList[1].itemDescription;
        

        for (int i = 0; i <= goods; i++)
        {
            num.Add(i);
        }


    }


    void Update()
    {
        for (int i = 0; i < goods; i++)
        {

            goodsPos[i] = Pos[i].transform.position;

        }

        if (Input.GetKeyDown(KeyCode.Return) && UIMgr.instance.UiOn == true)
        {
            BuyItem();
            
            buy = false;
            moneyTxt.GetComponent<Text>().text = currMoney.ToString();
            Debug.Log(currMoney);
        }
        for (int i = 0; i < goods; i++)
        {
            goodsPos[i] = Pos[i].transform.position;
            //물건의 개수가 줄은 상태에서 위치를 재 설정한다
            goodsIcon[num[i]].transform.position = goodsPos[i];
        }

        if (UIMgr.instance.storeUiOn == true)
        {
            itemMove();
            UIMgr.instance.UiOn = true;



        }
        else
            UIMgr.instance.UiOn = false;




    }
    /*
    public void onClickAttackRange()
    {
        

      if (AttackRangeLv >= 1 && AttackRangeLv <= 2)
        {
            AttackRangeLv =AttackRangeLv+1;
        }

        Debug.Log("공격범위 : " + AttackRangeLv);

        switch (AttackRangeLv)

        {

            case 2:
                break;
            case 3:
                break;

        }
        
            }
    public void onClickHp()
    {

        
        if (HpLv >= 1  || HpLv <= 4)
        {
            HpLv++;
        }

        Debug.Log("체력:" + HpLv);
        switch (HpLv)

        {

            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;

        }
        
    }
    public void onClickPower()
    {

       
        if (PowerLv == 1 || PowerLv <= 4)
        {
           PowerLv++;
        }

        Debug.Log("공격력:" + PowerLv);
        switch (PowerLv)

        {

            case 2:
                Controller.instance.AttackLv = 2;
                break;
            case 3:
                Controller.instance.AttackLv = 3;
                break;
            case 4:
                Controller.instance.AttackLv = 4;
                break;
            case 5:
                Controller.instance.AttackLv = 5;
                break;

        }
       
    }
    public void  onClickSpeed()
    {

        
        if (SpeedLv == 1 || SpeedLv <= 4)
        {
            SpeedLv++;
        }

        Debug.Log("공격속도:" + SpeedLv);
        switch (SpeedLv)

        {   //2.5 5.0 7.0 10.0

            case 2:
                Controller.instance.SetAttackCd(2.5f); 
                break;
            case 3:
                Controller.instance.SetAttackCd(5.0f);
                break;
            case 4:
                Controller.instance.SetAttackCd(7.5f);
                break;
            case 5:
                Controller.instance.SetAttackCd(10.0f);
                break;

        }
        
    }
    */
    public void itemMove()
    {

        if ((Input.GetKeyDown(KeyCode.RightArrow)) && (UIMgr.instance.UiOn == true))
        {
            reArr(0);


            if (r_count > r_count - 1)
            {
                goodsIcon[num[0]].SetActive(true);


            }
            goodsIcon[num[goods]].SetActive(false);



            for (int i = 0; i < goods; i++)
            {
                goodsIcon[num[i]].transform.position = goodsPos[i];

            }
            r_count++;


            // 0 1 2 3  , 3 0 1 2  , 2 3 0 1 , 1 2 3 0 , 0 1 2 3
            ItemName.GetComponent<Text>().text = itemList[num[idx]].itemName;
            ItemDesc.GetComponent<Text>().text = itemList[num[idx]].itemDescription;



        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow)) && UIMgr.instance.UiOn == true)
        {



            // 0 1 2 3 , 1 2 3 0 , 2 3 0 1, 3 0 1 2, 0 1 2 3

            if (l_count > l_count - 1)
            {
                goodsIcon[num[goods]].SetActive(true);

            }
            goodsIcon[num[0]].SetActive(false);

            reArr(1);

            for (int i = 0; i < goods; i++)
            {
                goodsIcon[num[i]].transform.position = goodsPos[i];
            }


            ItemName.GetComponent<Text>().text = itemList[num[idx]].itemName;
            ItemDesc.GetComponent<Text>().text = itemList[num[idx]].itemDescription;

            l_count++;

        }



    }
    private void reArr(int dir)
    {
      
        if (dir == 0)
        {
            //프로토 타입 아이템 4개 
            temp = num[goods];
            // 0 1 2 3
            num.RemoveAt(goods);
            num.Insert(0, temp);
            temp = num[goods];




        }//오른쪽 
        if (dir == 1)
        {
            temp = num[0];
            num.RemoveAt(0);
            num.Add(temp);
            temp = num[0];




        }//왼쪽

    }
    public void BuyItem()
    {   
        //구매하는 아이템이 소모품인 경우에는 소모품 개수를 표시함
        //소모품은 구매해도 아이콘이 사라지지 않습니다.
        buy = true;

        if (goods >= 3)
        {
            buy_item = num[1]; //아이템이 4개 이상일 경우에 삭제할 아이템은 1번 인덱스
            idx = 1;
            
        }
        else
        {
            buy_item = num[0]; //4개 미만인 경우에는 0번 인덱스의 아이템이 삭제될것
            idx = 0;
            
        }

        buyItemID.Add(itemList[buy_item].itemID);
        currMoney = currMoney - itemList[buy_item].itemPrice;
        if (itemList[buy_item].itemType == Item.ItemType.Permanent)
        {
           
           
            goodsIcon[buy_item].SetActive(false);
            Pos[goods - 1].SetActive(false);
            num.RemoveAt(idx);
            goods = goods - 1;
        }
        else if (itemList[buy_item].itemType == Item.ItemType.Use)
        {
            int idx = isContain(itemList[buy_item].itemID);
            if (idx!=-1)
            {
               
                typeUse[idx].itemCount = typeUse[idx].itemCount + 1;
                Debug.Log(typeUse[idx].itemCount);
            }
            else
            {
                typeUse.Add(new Item(itemList[buy_item].itemID, itemList[buy_item].itemName,
                     itemList[buy_item].itemDescription, itemList[buy_item].itemPrice,
                    itemList[buy_item].itemType, itemList[buy_item].itemCount));

            }
            

          


            



        }


       
        //위치 재설정
        //일단 물건의 개수를 하나 줄인다

        slotcount++;

       
    }
    public int isContain(int id)
    {
        for (int i = 0; i < typeUse.Count; i++)
        {
            if (itemList[buy_item].itemID == typeUse[i].itemID)
            {

                return i;
            }


        }
        return -1;
    }

} 

