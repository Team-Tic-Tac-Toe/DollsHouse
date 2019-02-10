using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHit : MonoBehaviour {

    SpriteRenderer thissprite;
    public Sprite[] doorsprite;
    int doorspriteindex=0;
    Animator anim;

	// Use this for initialization
	void Start () {
        thissprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerMelee"&&doorspriteindex<doorsprite.Length-1)
        {
            anim.SetTrigger("doorhit");
            doorspriteindex += 1;
        }
    }

    // Update is called once per frame
    void Update () {
        thissprite.sprite = doorsprite[doorspriteindex];
	}
}
