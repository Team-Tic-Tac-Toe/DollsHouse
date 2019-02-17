using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLoadFile : MonoBehaviour {

    public int characterslot;

    // 슬롯 클릭하면 로드
    void OnMouseUp()
    {
        switch (characterslot)
        {
            case 1 :
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                gameloadslot.slotnum = 1;
                LoadCharacter(1);
                Debug.Log("slot num : 1 loaded");
                
                break;
            case 2:
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                gameloadslot.slotnum = 2;
                LoadCharacter(2);
                Debug.Log("slot num : 2 loaded");
               
                break;
            case 3:
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
                gameloadslot.slotnum = 3;
                LoadCharacter(3);
                Debug.Log("slot num : 3 loaded");
                
                break;
        }
    }

    public static CharacterData LoadCharacter(int characterSlot)
    {
        Debug.Log("Loaded!");
        CharacterData loadedCharacter = new CharacterData();
        Debug.Log((PlayerPrefs.GetFloat(("characterrespawnx_CharacterSlot" + characterSlot)) + " , " + PlayerPrefs.GetFloat(("characterrespawny_CharacterSlot" + characterSlot)) + " , " + PlayerPrefs.GetFloat(("characterrespawnz_CharacterSlot" + characterSlot))));
        return loadedCharacter;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
