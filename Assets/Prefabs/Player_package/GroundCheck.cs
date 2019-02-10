using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == 8)
        { // layer 8 : ground
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
        }
        if (col.gameObject.tag == "ClimbingWall")
        {
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
        }
        if (col.gameObject.tag == "GroundCanJumpDown")
        {
            Debug.Log("ground");
            Controller.GetInstance().grounded = true;
            Controller.GetInstance().jumpcount = 2;
        }
    }

}
