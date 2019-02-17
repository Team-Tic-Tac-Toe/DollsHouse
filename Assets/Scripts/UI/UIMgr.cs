using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class UIMgr : MonoBehaviour
{
    public static UIMgr instance;
    // public GameObject reinUi;
    public GameObject storeUi;
    public GameObject player;
    //public GameObject npc1;
    public GameObject SuspiciousDollMaster;
    public GameObject mainCam;
    public GameObject UIcam;
    public GameObject moneyUi;
    public GameObject healthUi;

    private Rigidbody2D rigidbody;
    private bool swMove = true;

    public Text moneyUI;
    public bool UiOn = false; // 이게 true 일때 캐릭터는 움직이지 않도록합니다.
    public bool storeUiOn=false;
    public bool reinUiOn = false;
 

   
    int tmpMoney = 3000;
    //public bool[] openNpc = new bool[3];


    public static UIMgr GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<UIMgr>();
        }
        return instance;
    }
    // Use this for initialization
    void Start()
    {
      
        //reinUi.SetActive(false);
        storeUi.SetActive(false);
        UIcam.SetActive(false);
        moneyUI.GetComponent<Text>().text = tmpMoney.ToString();

        rigidbody = UIcam.GetComponent<Rigidbody2D>();

    }
    void Awake()
    {
        instance = this;
    }
    void Update()
    {

        Vector2 playerPos = player.transform.position;
        //Vector2 colPos1 = npc1.transform.position;
        Vector2 colPos2 = SuspiciousDollMaster.transform.position;


        /*if (playerPos.x - colPos1.x < 5 && playerPos.x - colPos1.x > -5
                && playerPos.y - colPos1.y < 5 && playerPos.y - colPos1.y > -5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                reinUi.SetActive(true);
                reinUiOn = true;
               // openNpc[0] =true ;
            }

        }
        else 
        {
            reinUi.SetActive(false);
            
           // openNpc[0] = false;
        }
*/
        if (playerPos.x - colPos2.x < 5 && playerPos.x - colPos2.x > -5 &&
                playerPos.y - colPos2.y < 5 && playerPos.y - colPos2.y > -5)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {   

                storeUiOn = true;
                mainCam.SetActive(false);
               
                UIcam.SetActive(true);

                if (!storeUi.activeInHierarchy&&swMove==true)
                {
                    
                    UIcam.transform.position = mainCam.transform.position;
                    StartCoroutine(leftMove());
                    swMove = false;
                    

                }
      
                storeUi.SetActive(true);
                moneyUi.SetActive(false);
                healthUi.SetActive(false);
               
                //openNpc[1] = true;
            }
            if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.X))
            {
                
               
                if (storeUi.activeInHierarchy&&swMove == false)
                {
                    
                    StartCoroutine(rightMove());
                    swMove = true;
                    
                }

                Invoke("closeShop", 4);

                
                
                //openNpc[1] = false;

            }
            //문제가 무엇일까
            //내가 원하는 루틴
            //창이 닫히기 전에 카메라가 반대로 이동하는 것
        }
        else
        {
            storeUi.SetActive(false);
        }
       
       
    }
   

    IEnumerator leftMove()
    {
         
        Vector3 destination = new Vector3(UIcam.transform.position.x - 6, UIcam.transform.position.y, UIcam.transform.position.z);
        //ui캠이 도착할 위치를 말함 
        Vector3 moveVector = destination - UIcam.transform.position;

        while (moveVector.sqrMagnitude > 0.1)
        {
            
            moveVector = destination - UIcam.transform.position;
            rigidbody.MovePosition(UIcam.transform.position + moveVector * Time.deltaTime);
            yield return null;
        }
        

    }
    IEnumerator rightMove()
    {
        Vector3 destination = new Vector3(UIcam.transform.position.x + 6, UIcam.transform.position.y, UIcam.transform.position.z);
        Vector3 moveVector = destination - UIcam.transform.position;

        while (moveVector.sqrMagnitude > 0.1)
        {

            moveVector = destination - UIcam.transform.position;
            rigidbody.MovePosition(UIcam.transform.position + moveVector * Time.deltaTime);
            yield return null;
        }

       
    }
    //NpcUi동작설정
   

    void closeShop() {
        mainCam.transform.position = UIcam.transform.position;
        UIcam.SetActive(false);
        mainCam.SetActive(true);
        storeUi.SetActive(false);
        moneyUi.SetActive(true);
        healthUi.SetActive(true);

    }
}

    


