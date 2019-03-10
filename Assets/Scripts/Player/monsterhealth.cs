using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterhealth : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            Controller.GetInstance().playerHealth -= 1;//현재 인벤토리 테스트때문에 controller magic뭐시기 주석처리함.
          
         }
    }
}
