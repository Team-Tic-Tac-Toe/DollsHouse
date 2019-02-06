using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InGameOption : MonoBehaviour {
    public UnityEvent[] InGameOptionEvents;
    public Button[] InGameOptionButtons;
    int InGameOptionIndex = 0;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Cursor.visible = false;
            InGameOptionIndex--;

            if (InGameOptionIndex < 0)
                InGameOptionIndex = InGameOptionEvents.Length - 1;

            InGameOptionButtons[InGameOptionIndex].Select();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Cursor.visible = false;
            InGameOptionIndex++;

            if (InGameOptionIndex >= InGameOptionEvents.Length)
                InGameOptionIndex = 0;

            InGameOptionButtons[InGameOptionIndex].Select();
        }
        else if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Cursor.visible = false;
            InGameOptionEvents[InGameOptionIndex].Invoke();
        }

        if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        {
            Cursor.visible = true;
            EventSystem.current.SetSelectedGameObject(null);
        }      
    }

    public void BackToGame()
    {
        GameManager.GetInstance().isPlaying = true;
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }

    public void ToMainMenu()
    {
        Time.timeScale = 1f;
        print("move to main menu");
        Application.Quit();
    }

    public void ToOptionMenu()
    {
        Time.timeScale = 1f;
        print("move to option menu");
    }
}
