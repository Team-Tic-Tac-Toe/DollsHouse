using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJump : MonoBehaviour {


	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 5f;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
	}
 


    // Update is called once per frame
    void Update () {
        if (rb2d.velocity.y <0){
            if (Controller.GetInstance().wallsliding)
            {
                rb2d.velocity = new Vector2(0, -1f);
            }
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier-1)*Time.deltaTime;
		}
		else if ( rb2d.velocity.y >0 && !Input.GetKey(KeyCode.Z)){
			rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier-1)*Time.deltaTime;	
		}
	}
}
