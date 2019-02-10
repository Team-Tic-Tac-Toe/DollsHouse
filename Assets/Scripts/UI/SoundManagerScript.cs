using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {

    public static AudioClip Moneysound;
    static AudioSource audioSrc;

	void Start () {
        Moneysound = Resources.Load<AudioClip>("moneysound");
        audioSrc = GetComponent<AudioSource> ();
	}
	
	
    public static void Playsound(string clip)
    {
        switch (clip)
        {
            case "moneysound":
                audioSrc.PlayOneShot(Moneysound);
                break;
        }
    }

}
