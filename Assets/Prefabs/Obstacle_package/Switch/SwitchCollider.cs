using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCollider : MonoBehaviour {

    public static SwitchCollider instance;

    Animator anim;
    public bool ishit = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        instance = this;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Skill")
        {
            anim.SetTrigger("IsHit");
            ishit = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
