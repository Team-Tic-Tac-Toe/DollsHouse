using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public GameObject talkbutton;
    public Text dText;


    public bool dialogActive;

    public string[] dialogLines;
    public int currentLine = 0;

    void Awake()
    {
        talkbutton.SetActive(false);
        dBox.SetActive(false);
        dialogActive = false;
    }
	
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.F))
        {

            //   dBox.SetActive(true);
            dBox.SetActive(true);
            talkbutton.SetActive(false);

            if (currentLine >= dialogLines.Length)
            {
                dBox.SetActive(false);
                currentLine = 0;
                //dialogActive = false;
                talkbutton.SetActive(true);
            }else
                dText.text = dialogLines[currentLine++];
        }

       
	}


    public void ShowBox(string dialogue)
    {
     
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
              dBox.SetActive(false);
            talkbutton.SetActive(false);
        }
    }

}
