using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {

    Text text;
    public static int moneyAmount ;

    void Start()
    {
        moneyAmount = 3000;
        text = GetComponent<Text> ();
    }

    void Update()
    {
        text.text = moneyAmount.ToString();
    }
}
