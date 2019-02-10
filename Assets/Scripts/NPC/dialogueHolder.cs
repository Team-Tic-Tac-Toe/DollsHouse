using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {


    public string dialogue;
    private DialogueManager dMAn;

   // public string[] dialogueLines;


	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}

   
   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            dMAn.talkbutton.SetActive(true);
            dMAn.dialogActive = true;
          if(Input.GetKeyDown(KeyCode.F))
            {
                dMAn.talkbutton.SetActive(false);
                //dMAn.ShowBox(dialogue);
                if (!dMAn.dialogActive)
                {
                   // dMAn.dialogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }
          
            }
        }
    }
  

}
