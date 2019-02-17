using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {
    
    /// 메인메뉴
    public GameObject[] selectionbox;
    public GameObject[] mintOutline;
    private int currentindexb;

    /// 불러오기
    public GameObject Load;
    Transform transld;
    public GameObject[] loadbox;
    //public GameObject[] selectionboxld;
    //private int currentindexld;


    /// 옵션
    public GameObject Option;
    Transform transop;
    public GameObject[] selectionboxop;
    private int currentindexop;
    public GameObject preparing; // 준비중

    public GameObject MainCamera;
    Transform trans;

    public float length; // 카메라 이동 x 100

    

    private int currentscene=100; //100 : 메인화면 , 0 : 게임시작, 1 : 옵션, 2 : 팀소개, 3 : 종료

	// Use this for initialization
	void Start () {
        trans = MainCamera.transform;
        transop = Option.transform;
        transld = Load.transform;

        currentindexb = 0;

        currentindexop = 0;
        preparing.SetActive(false);

        for(int i =0; i<loadbox.Length; i++)
        {
            loadbox[i].SetActive(false);
        }
        for (int i=0; i<selectionbox.Length; i++)
        {
            selectionbox[i].SetActive(false);
            mintOutline[i].SetActive(false);
        }
        for (int i = 0; i < selectionboxop.Length; i++)
        {
            selectionboxop[i].SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (currentscene == 100) // 메인화면
        {
            if (Input.GetKeyUp(KeyCode.DownArrow) && currentindexb < selectionbox.Length - 1)
            {
                currentindexb += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) && currentindexb > 0)
            {
                currentindexb -= 1;
            }

            Selectcurrentindexb();

            for (int i = 0; i < selectionbox.Length; i++)
            {
                if (i == currentindexb)
                {
                    selectionbox[i].SetActive(true);
                    mintOutline[i].SetActive(true);
                }
                else
                {
                    selectionbox[i].SetActive(false);
                    mintOutline[i].SetActive(false);
                }
            }
        }

        else if (currentscene == 0) // 불러오기
        {
            for (int i = 0; i < loadbox.Length; i++)
            {
                loadbox[i].SetActive(true);
            }
            /*
            if (Input.GetKeyUp(KeyCode.DownArrow) && currentindexb < selectionboxop.Length - 1)
            {
                currentindexop += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) && currentindexop > 0)
            {
                currentindexop -= 1;
            }
            */
            Selectcurrentindexld();
            /*
            for (int i = 0; i < selectionboxop.Length; i++)
            {
                if (i == currentindexop)
                {
                    selectionboxop[i].SetActive(true);
                }
                else
                {
                    selectionboxop[i].SetActive(false);
                }
            }
            */
        }

        else if (currentscene == 1) // 옵션
        {
            if (Input.GetKeyUp(KeyCode.DownArrow) && currentindexb < selectionboxop.Length - 1)
            {
                currentindexop += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow) && currentindexop > 0)
            {
                currentindexop -= 1;
            }

            Selectcurrentindexop();

            for (int i = 0; i < selectionboxop.Length; i++)
            {
                if (i == currentindexop)
                {
                    selectionboxop[i].SetActive(true);
                }
                else
                {
                    selectionboxop[i].SetActive(false);
                }
            }
        }

    }
    /*
        if (Input.GetKeyUp(KeyCode.X))
        {
            StartCoroutine("moveCameraRight");
            //StartCoroutine("moveOptionLeft");
            currentscene = 100;
            currentindexop = 0;
        }
    */

    // 키 입력 부분

    void Selectcurrentindexb()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            switch (currentindexb){
                case 0 :
                    StartCoroutine("moveCamera");
                    StartCoroutine("moveLoadRight");
                    currentscene = 0; // 게임 시작
                    //SceneManager.LoadScene("GameStart", LoadSceneMode.Single);
                    break;
                case 1 :
                    StartCoroutine("moveCamera");
                    StartCoroutine("moveOptionRight");
                    currentscene = 1;
                    //SceneManager.LoadScene("Option", LoadSceneMode.Single);
                    break;
                case 2 :
                    SceneManager.LoadScene("IntroduceTeam", LoadSceneMode.Single);
                    break;
                case 3:
                    SceneManager.LoadScene("GameQuit", LoadSceneMode.Single);
                    break;
                }
        }
    }

    //게임 불러오기 창, scene :0
    void Selectcurrentindexld()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            StartCoroutine("moveCameraRight");
            StartCoroutine("moveLoadLeft");
            currentscene = 100;
            //currentindexop = 0;
            for (int i = 0; i < loadbox.Length; i++)
            {
                loadbox[i].SetActive(false);
            }
        }
    }

    //옵션 창 , scene : 1
    void Selectcurrentindexop()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            StartCoroutine("moveCameraRight");
            StartCoroutine("moveOptionLeft");
            currentscene = 100;
            currentindexop = 0;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch (currentindexop)
            {
                case 0:
                    preparing.SetActive(true);
                    break;
                case 1:
                    preparing.SetActive(true);
                    break;
                case 2:
                    preparing.SetActive(true);
                    break;
            }
        }
        if(Input.GetKeyUp(KeyCode.Z)){
            preparing.SetActive(false);
        }
    }

    // Ui Camera 이동부분

    IEnumerator moveCamera()
    {
        for (int i = 0; i < 100; i++)
        {
            trans.position = new Vector3(trans.position.x - length/100, trans.position.y, trans.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moveCameraRight()
    {
        for (int i = 0; i < 100; i++)
        {
            trans.position = new Vector3(trans.position.x + length / 100, trans.position.y, trans.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moveLoadRight()
    {
        for (int i = 0; i < 100; i++)
        {
            transld.position = new Vector3(transld.position.x + length / 100, transld.position.y, transld.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moveLoadLeft()
    {
        for (int i = 0; i < 100; i++)
        {
            transld.position = new Vector3(transld.position.x - length / 100, transld.position.y, transld.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moveOptionRight()
    {
        for (int i = 0; i < 100; i++)
        {
            transop.position = new Vector3(transop.position.x + length / 100, transop.position.y, transop.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moveOptionLeft()
    {
        for (int i = 0; i < 100; i++)
        {
            transop.position = new Vector3(transop.position.x - length / 100, transop.position.y, transop.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }



}
