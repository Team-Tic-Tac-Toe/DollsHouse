using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGoDown : MonoBehaviour {

    bool once = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SwitchCollider.instance.ishit && once)
        {
            StartCoroutine(delayforobs());
            once = false;
        }

	}

    IEnumerator delayforobs()
    {
        yield return new WaitForSeconds(3f);    // 3초 대기 후..
        for(int i =0; i<100; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f,transform.position.z);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
