using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private InventorySlot[] slots; //인벤토리 슬롯들 (slot(0...8))

    public GameObject strmgr;

    private List<Item> inventoryItemList; //플레이어가 소지한 아이템리스트
    private List<Item> inventoryTabList; //선택한 탭에 따라 다르게 보여질 아이템 리스트

   // public Text Description_Text; //아이템 설명
    public string[] tabDescription; //탭 부연 설명 //소비인지 소지인지

    public Transform tf; //slot 부모객체 (InventorySlot_use 이거)

    public GameObject go; //인벤토리 활성화 비활성화
    public GameObject[] selectTabImages; //이걸로 소비아이템-소지아이템 탭 변경하자. 키는 위아랰키보드로!!

    private int selectedItem; //선택된 아이템 
    private int selectedTab; //선택된 탭 ---키 위아래키보드

    private bool inventoryactivated; //인텐토리 활성화시 true;
    private bool tabActivated; //탭 활성화시 true;
    private bool itemActivated; //아이템 활성화시 true;
    private bool stopKeyinput; //키입력 제한 (소비할때 질의가 나올텐데, 그때키입력방지)
    private bool preventExec; //중복실행 제한.

    public Image[] slotImage;
    public Sprite[] itemImage;

    
    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    void Awake()
    {
       
        gameObject.SetActive(false);
    }

    void Start()
    {
        inventoryItemList = new List<Item>();
        inventoryTabList = new List<Item>();
        //slots = tf.GetComponentsInChildren<InventorySlot>();
    }

    /*public void RemoveSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveItem();
            slots[i].gameObject.SetActive(false);
        }
    } //인벤토리 슬롯 초기화
    */
    public void ShowTab()
    {
       // RemoveSlot();
        SelectedTab();
    } //탭 활성화
    public void SelectedTab()
    {
        StopAllCoroutines();
        Color color = selectTabImages[selectedTab].GetComponent<Image>().color;
        color.a = 0f;
        for (int j = 0; j < selectTabImages.Length; j++)
        {
            selectTabImages[j].GetComponent<Image>().color = color;
        }
       // Description_Text.text = tabDescription[selectedTab];
        StartCoroutine(SelectedTabEffectCoroutine());

    } //선택된 탭을 제외하고 다른 모든 탭의 컬러 알파값 0으로 조정
    IEnumerator SelectedTabEffectCoroutine()
    {
        while (tabActivated)
        {
            Color color = selectTabImages[0].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                selectTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                selectTabImages[selectedTab].GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } //선택된 탭 반짝임 효과

    /* public void ShowItem()
    {
        inventoryTabList.Clear();
        RemoveSlot();
        selectedItem = 0;

        switch (selectedTab) //탭에 따른 아이템 분류. 그것을 인벤토리 탭 리스트에 추가
        {
            case 0: //소비아이템의 경우
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Use == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;
            case 1: //소지아이템의 경우
                for (int i = 0; i < inventoryItemList.Count; i++)
                {
                    if (Item.ItemType.Permanent == inventoryItemList[i].itemType)
                        inventoryTabList.Add(inventoryItemList[i]);
                }
                break;

        }

        for (int i = 0; i < inventoryTabList.Count; i++) //인벤토리 탭 리스트의 내용을 인벤 슬롯에 추가
        {
            slots[i].gameObject.SetActive(true);
            slots[i].Additem(inventoryTabList[i]);
        }



    } //아이템 활성화(inventoryTabList에 조건에 맞는 아이템들만 넣어주고 인벤토리슬롯에출력)
    public void SelectedItem()
    {
        StopAllCoroutines();
        if (inventoryTabList.Count > 0)
        {
            Color color = slots[0].selected_Item.GetComponent<Image>().color;
            color.a = 0f;
            for (int i = 0; i < inventoryTabList.Count; i++)
                slots[i].selected_Item.GetComponent<Image>().color = color;
            Description_Text.text = inventoryTabList[selectedItem].itemDescription;
            StartCoroutine(SelectedItemEffectCoroutine());
        }
        else
            Description_Text.text = "해당 아이템 없습니다.";
    } //선택된 아이템을 제외하고 다른 모든 탭의 컬러 알파값 0으로 조정
    IEnumerator SelectedItemEffectCoroutine()
    {
        while (itemActivated)
        {
            Color color = slots[0].GetComponent<Image>().color;
            while (color.a < 0.5f)
            {
                color.a += 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }
            while (color.a > 0f)
            {
                color.a -= 0.03f;
                slots[selectedItem].selected_Item.GetComponent<Image>().color = color;
                yield return waitTime;
            }

            yield return new WaitForSeconds(0.3f);
        }
    } //선택된 아이템 반짝임 효과
    */

    void Update()
    {
        if (true)
        {

             if (Controller.GetInstance().isInvenOn)
                {
                    go.SetActive(true);
                    selectedTab = 0;
                    tabActivated = true;
                    itemActivated = false;
                    ShowTab();
                }
             else
                {
                    StopAllCoroutines();
                    go.SetActive(false);
                    tabActivated = false;
                    itemActivated = false;

                }

            if (Controller.GetInstance().isInvenOn) //inventoryactivated)
            {
                if (tabActivated) //탭전환은 위아래 방향키로
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        if (selectedTab < selectTabImages.Length - 1)
                            selectedTab++;
                        else
                            selectedTab = 0;
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        if (selectedTab > 0)
                            selectedTab--;
                        else
                            selectedTab = selectTabImages.Length - 1;
                        SelectedTab();
                    }
                    else if (Input.GetKeyDown(KeyCode.W)) // tab이동에서 item이동으로 변경시
                    {
                        Color color = selectTabImages[selectedTab].GetComponent<Image>().color;
                        color.a = 0.25f;
                        selectTabImages[selectedTab].GetComponent<Image>().color = color;
                        itemActivated = true;
                        tabActivated = false;
                        preventExec = true;
                        
                    }
                
                }

                if (strmgr.activeInHierarchy)
                {
                    slotImage[StoreMgr.GetInstance().slotcount - 2].transform.GetChild(0).GetComponent<Image>().sprite = itemImage[StoreMgr.GetInstance().buy_item];
                }

                Debug.Log(slotImage[StoreMgr.GetInstance().slotcount - 2]);
                Debug.Log(itemImage[StoreMgr.GetInstance().buy_item]);
                
               // slotImage[StoreMgr.GetInstance().slotcount - 2].sprite = itemImage[StoreMgr.GetInstance().buy_item]; //이 코드가 상점 구입시 인벤 들어가도록
            }

          

                else if (Input.GetKeyDown(KeyCode.W)) //다시 tab키이동으로
                {
                    StopAllCoroutines();
                    itemActivated = false;
                    tabActivated = true;
                    ShowTab();
                }
         }

            if (Input.GetKeyUp(KeyCode.LeftControl))
                preventExec = false;
        }

    }



	

