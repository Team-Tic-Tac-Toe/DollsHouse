using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleScript : MonoBehaviour {

    public static ObstacleScript instance;

    private Transform trans;
    bool LeftKnock;

    public Transform respawntransL;
    public Transform respawntransR;

    public Transform respawntrans;

    public Image image4fade;

	// Use this for initialization
	void Start () {
        instance = this;
        trans = GetComponent<Transform>();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && Controller.GetInstance().GetAttacked == false)
        {
            Controller.GetInstance().GetAttacked = true;        // 현재 공격 받은 후 무적판정 행동불능 on
            Controller.GetInstance().attackedTimer = 0.7f;      // 행동불능 시간
            //HeartSystem.instance.TakeDamage(-1); // 피 깎임
            /*
            if (trans.position.x > Controller.myTrans.position.x)
            {
                LeftKnock = true;       //왼쪽에서 맞았나 오른쪽에서 맞았나 판단
            }
            else
            {
                LeftKnock = false;
            }
            Controller.GetInstance().Knockback(5f, LeftKnock); 
            */
            StartCoroutine(WaitAndRespawn());
        }  
    }

    IEnumerator fadeoutandin()
    {
        Color startColor = image4fade.color;
        for(int i =0; i<30; i++)
        {
            startColor.a = startColor.a + 0.033f;
            image4fade.color = startColor;
            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 20; i++)
        {
            startColor.a = startColor.a - 0.05f;
            image4fade.color = startColor;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator WaitAndRespawn()
    {
        StartCoroutine(fadeoutandin());
        yield return new WaitForSeconds(0.5f);
        
        Controller.myTrans.position = respawntrans.position;
    }

}
