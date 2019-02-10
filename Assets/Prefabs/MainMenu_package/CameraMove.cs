using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Transform trans;
    public float length;

    IEnumerator moveCamera()
    {
        for (int i = 0; i < 100; i++)
        {
            trans.position = new Vector3(trans.position.x-length, trans.position.y, trans.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }


    // Use this for initialization
    void Start()
    {
        trans = GetComponent<Transform>();
        //StartCoroutine("moveCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
