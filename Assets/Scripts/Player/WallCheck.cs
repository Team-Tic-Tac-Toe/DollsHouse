using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        { // layer 8 : ground
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
            Controller.GetInstance().wallsliding = true;
        }
        if (col.gameObject.tag == "ClimbingWall")
        {
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
            Controller.GetInstance().wallsliding = true;
        }
        if (col.gameObject.tag == "GroundCanJumpDown")
        {
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
            Controller.GetInstance().wallsliding = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        { // layer 8 : ground
            Controller.GetInstance().wallsliding = false;
        }
        if (col.gameObject.tag == "ClimbingWall")
        {
            Controller.GetInstance().wallsliding = false;
        }
        if (col.gameObject.tag == "GroundCanJumpDown")
        {
            Controller.GetInstance().wallsliding = false;
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
