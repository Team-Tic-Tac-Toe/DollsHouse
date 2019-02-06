using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject Cursor;

	// Use this for initialization
	void Start () {
        //Cursor.transform.localPosition = Controller.myTrans.position;
	}

    private void Update()
    {
        Cursor.transform.localPosition = Controller.myTrans.position * 50;
    }

}
