using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyscript : MonoBehaviour {



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            ScoreTextScript.moneyAmount += 4;
            SoundManagerScript.Playsound("moneysound");
            Destroy(gameObject);
        }
    }
}
