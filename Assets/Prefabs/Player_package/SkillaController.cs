using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillaController : MonoBehaviour {

    public ForceMode2D mode;
    Rigidbody2D rb2d;
    public float speed;
    public GameObject THIS;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (Controller.GetInstance().lookRight)
        {
            rb2d.AddForce(Vector2.right.normalized * speed, mode);
        }
        else
            rb2d.AddForce(Vector2.left.normalized * speed, mode);

        Destroy(THIS,2f);
    }
    void FixedUpdate()
    {
            
    }

    // Update is called once per frame
    void Update () {

	}
}
