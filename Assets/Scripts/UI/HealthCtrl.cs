using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCtrl : MonoBehaviour {

    public GameObject HP1, HP2, HP3, HP4, HP5, HP6, HP7, HP8 ;
    private int health;


    void Start()
    {
        
        
        HP1.gameObject.SetActive(true);
        HP2.gameObject.SetActive(true);
        HP3.gameObject.SetActive(true);
        HP4.gameObject.SetActive(true);
        HP5.gameObject.SetActive(true);
        HP6.gameObject.SetActive(true);
        HP7.gameObject.SetActive(true);
        HP8.gameObject.SetActive(true);
     //   Gameover.gameObject.SetActive(false);
    }

    void Update()
    {
        health = Controller.GetInstance().playerHealth;
        if (health > 8)
            health = 8;

        switch (health)
        {
            case 8:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(true);
                HP5.gameObject.SetActive(true);
                HP6.gameObject.SetActive(true);
                HP7.gameObject.SetActive(true);
                HP8.gameObject.SetActive(true);
                break;
            case 7:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(true);
                HP5.gameObject.SetActive(true);
                HP6.gameObject.SetActive(true);
                HP7.gameObject.SetActive(true);
                HP8.gameObject.SetActive(false);
                break;
            case 6:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(true);
                HP5.gameObject.SetActive(true);
                HP6.gameObject.SetActive(true);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 5:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(true);
                HP5.gameObject.SetActive(true);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 4:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(true);
                HP5.gameObject.SetActive(false);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 3:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(true);
                HP4.gameObject.SetActive(false);
                HP5.gameObject.SetActive(false);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 2:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(true);
                HP3.gameObject.SetActive(false);
                HP4.gameObject.SetActive(false);
                HP5.gameObject.SetActive(false);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 1:
                HP1.gameObject.SetActive(true);
                HP2.gameObject.SetActive(false);
                HP3.gameObject.SetActive(false);
                HP4.gameObject.SetActive(false);
                HP5.gameObject.SetActive(false);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;
            case 0:
                HP1.gameObject.SetActive(false);
                HP2.gameObject.SetActive(false);
                HP3.gameObject.SetActive(false);
                HP4.gameObject.SetActive(false);
                HP5.gameObject.SetActive(false);
                HP6.gameObject.SetActive(false);
                HP7.gameObject.SetActive(false);
                HP8.gameObject.SetActive(false);
                break;

        }
    }

}
