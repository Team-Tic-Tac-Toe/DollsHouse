using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFunction : MonoBehaviour {

    public CharacterData characterdata;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            SaveCharacter(characterdata, gameloadslot.slotnum); 
        }
        /*
        else if (Input.GetKeyUp(KeyCode.L))
        {
            LoadCharacter(1);
        }
        */
    }

    static public void SaveCharacter(CharacterData data, int characterSlot)
    {
        PlayerPrefs.SetFloat("characterrespawnx_CharacterSlot" + characterSlot, data.respawntrans.position.x);
        PlayerPrefs.SetFloat("characterrespawny_CharacterSlot" + characterSlot, data.respawntrans.position.y);
        PlayerPrefs.SetFloat("characterrespawnz_CharacterSlot" + characterSlot, data.respawntrans.position.z);
        Debug.Log((PlayerPrefs.GetFloat(("characterrespawnx_CharacterSlot" + characterSlot)) +" , "+ PlayerPrefs.GetFloat(("characterrespawny_CharacterSlot" + characterSlot)) + " , " + PlayerPrefs.GetFloat(("characterrespawnz_CharacterSlot" + characterSlot))));
        PlayerPrefs.Save();    
    }
    /*
    static public CharacterData LoadCharacter(int characterSlot)
    {
        Debug.Log("Loaded!");
        CharacterData loadedCharacter = new CharacterData();
        Debug.Log((PlayerPrefs.GetFloat(("characterrespawnx_CharacterSlot" + characterSlot)) + " , " + PlayerPrefs.GetFloat(("characterrespawny_CharacterSlot" + characterSlot)) + " , " + PlayerPrefs.GetFloat(("characterrespawnz_CharacterSlot" + characterSlot))));
        return loadedCharacter;
    }
    */

}
