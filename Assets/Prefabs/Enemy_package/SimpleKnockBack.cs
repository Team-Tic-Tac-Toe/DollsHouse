using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleKnockBack : MonoBehaviour
{

    Vector3 KnockbackDir;
    bool LeftKnock;
    float enemyhealth = 100f;

    private bool getAttacked = false;
    private Transform myTrans;
    private Transform targetpos;

    // Use this for initialization
    void Start()
    {
        myTrans = GetComponent<Transform>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Controller.GetInstance().GetAttacked == false)
        {
            Controller.GetInstance().GetAttacked = true;        // 현재 공격 받은 후 무적판정 행동불능 on
            Controller.GetInstance().attackedTimer = 0.7f;      // 행동불능 시간
            //HeartSystem.instance.TakeDamage(-1);                // 체력 소모
                                                                //Debug.Log(myTrans.position.x + "  :  " + Controller.GetInstance().transform.position.x);

            if (myTrans.position.x > Controller.GetInstance().transform.position.x)
            {
                LeftKnock = true;       //왼쪽에서 맞았나 오른쪽에서 맞았나 판단
            }
            else
            {
                LeftKnock = false;
            }
            Controller.GetInstance().Knockback(5f, LeftKnock);
        }

        if (col.gameObject.tag == "PlayerMelee" && !getAttacked)
        {   // 플레이어 근접공격에 피격시
            getAttacked = true;
            enemyhealth -= 12;
            Debug.Log(enemyhealth);
            if (myTrans.position.x > Controller.GetInstance().transform.position.x)
            {
                LeftKnock = true;       //왼쪽에서 맞았나 오른쪽에서 맞았나 판단
            }
            else
            {
                LeftKnock = false;
            }

            /*
			Vector2 enemyvelo = GetComponent<Rigidbody2D>().velocity;
			if(LeftKnock){
				enemyvelo.x =5f;
				enemyvelo.y = 1.5f;
			}
			else {
				enemyvelo.x = -5f;
				enemyvelo.y = 1.5f;
			}
			
			GetComponent<Rigidbody2D>().velocity = enemyvelo;
			*/
            if (LeftKnock)
            {
                myTrans.position = new Vector2(myTrans.position.x + 0.1f, myTrans.position.y);
            }
            else
            {
                myTrans.position = new Vector2(myTrans.position.x - 0.1f, myTrans.position.y);
            }


        }
    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.tag == "PlayerMelee")
        {
            getAttacked = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && Controller.GetInstance().GetAttacked == false)
        {
            Controller.GetInstance().GetAttacked = true;
            Controller.GetInstance().attackedTimer = 0.7f;
            //HeartSystem.instance.TakeDamage(-1);
            Controller.GetInstance().Knockback(5f, LeftKnock);
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}
