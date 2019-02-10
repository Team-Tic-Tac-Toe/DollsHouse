using UnityEngine;

public class monsterhealth : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") { 
        Controller.GetInstance().playerHealth -= 1; }
    }
}
