using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private static MoveCamera instance;
    public float FollowSpeed = 2f;

    public static MoveCamera GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<MoveCamera>();
        }
        return instance;
    }

    public Transform playertrans; //target

    public bool CameraCanMove = true;

    Transform cameratrans;

    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {               // 인스턴스가 있는데 
            if (instance != this)
            {       // 그게 내 자신이 아니라면
                 Destroy(gameObject);    // 내 자신을 파괴한다.	
            }
        }
        cameratrans = GetComponent<Transform>();
    }
 /*
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EndOfScene")
        {
            Debug.Log("TriggerEnter");
            edge.position = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
        }
    }
    /*
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndOfScene")
        {
            Debug.Log("TriggerExit");
            CameraCanMove = true;
        }
    }
    */
    // Update is called once per frame
    void Update()
    {
        
        //Vector3 targetPosition = playertrans.TransformPoint(new Vector3(0, 2.1f, -15));
        if (CameraCanMove)
        {
            Vector3 newPoint = playertrans.position;
            newPoint.y = playertrans.position.y + 2.1f;
            newPoint.z = cameratrans.position.z;
            cameratrans.position = Vector3.Slerp(cameratrans.position, newPoint, FollowSpeed * Time.deltaTime);
            //cameratrans.position = new Vector3(playertrans.position.x, playertrans.position.y + 2.1f, cameratrans.position.z);
            //cameratrans.position = Vector3.SmoothDamp(playertrans.position, targetPosition,ref velocity,smoothTime);

        }
        else if (!CameraCanMove)
        {
            Vector3 newPoint = playertrans.position;
            newPoint.y = playertrans.position.y + 2.1f;
            newPoint.x = cameratrans.position.x;
            newPoint.z = cameratrans.position.z;
            cameratrans.position = Vector3.Slerp(cameratrans.position, newPoint, FollowSpeed * Time.deltaTime);
            //cameratrans.position = new Vector3(cameratrans.position.x, playertrans.position.y + 2.1f, cameratrans.position.z);
            // cameratrans.position = Vector3.SmoothDamp(playertrans.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
