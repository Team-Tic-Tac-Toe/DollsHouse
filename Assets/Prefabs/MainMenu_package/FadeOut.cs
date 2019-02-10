using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeOut : MonoBehaviour {

    SpriteRenderer fadeSprite;

    IEnumerator fadeout()
    {
        Color startColor = fadeSprite.color;
        for(int i =0; i<75; i++)
        {
            startColor.r = startColor.r - 0.005f;
            startColor.g = startColor.g - 0.005f;
            startColor.b = startColor.b - 0.005f;
            fadeSprite.color = startColor;
            yield return new WaitForSeconds(0.013f);
        }
    }

	// Use this for initialization
	void Start () {
        fadeSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(fadeout());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
