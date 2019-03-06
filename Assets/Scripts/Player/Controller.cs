using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

    // public 이지만 코드 상에서 건들이면 안되는 것. 대문자 시작
    // 코드 내에서만 쓰이는 것. 소문자 시작.
    // Tag 는 대문자
    bool once = true;
    public Animator anim;

	public static Controller GetInstance(){
		if(instance == null){
			instance = FindObjectOfType<Controller>();
		}
		return instance;
	}
    

    /////////////////////////////////////////
    ////            Status                ///
    /////////////////////////////////////////
    public int player_Money;
    public static Transform myTrans;
    private Rigidbody2D rb2d;

    //////////////////////////////////////////
    ////			Magic 				//////
    //////////////////////////////////////////
    public GameObject MagicCircle;
	public GameObject Magic_A;

    public GameObject skillaRight;
    public GameObject skillaLeft;
    GameObject skillainstance;

	private bool AisOn = false;
	public GameObject Magic_S;
	private bool SisOn = false;
	public GameObject Magic_D;
	private bool DisOn = false;
	//public Transform MagicPosition;
    //public Transform MagicPositionA;
    //public Transform MagicPositionS;
    //public Transform MagicPositionD;
    //private GameObject instantiatedCircle; // 생성 및 삭제용
    //private GameObject instantiatedA;
    //private GameObject instantiatedS;
    //private GameObject instantiatedD;

    private static Controller instance;  //Controller 클래스 인스턴스를 static 변수로 선언해 어디서든 가져다 쓸 수 있음. 후에 Controller 변수를 쓰고 싶다면 Controller.instance 에서 가져다 쓰면 됨.

    //////////////////////////////////////////
    ////			Movement        	//////
    //////////////////////////////////////////
    public GameObject Idle;
	public GameObject Crouch;
	public float Speed = 5;
    private bool crouch = false;
    public bool lookRight = true;


    //////////////////////////////////////////
    ////			Attack          	//////
    //////////////////////////////////////////
    private bool attack = false;
	private float attackCd = 0.3f;
	private float attackTimer = 0;
    public float attackdmg = 10f;

	public bool GetAttacked = false;	// 피격 후 무적 판정 true 이면 무적 판정 & 행동 불능
	public bool GetAttackedMoment = false;
	public float attackedTimer = 0f;
	



	// 현재 공격 범위 변수들
	public int AttackLv = 1;
	private Collider2D hitbox;
	private Collider2D hitboxDown;
	private Collider2D hitboxUp;
	private GameObject attackanim;
	private GameObject attackDownanim;
	private GameObject attackUpanim;
	
	// 각 레벨에 따른 공격 범수들 (변수가 너무 많으면 성능 저하..?)
	public Collider2D hitboxlv1;
	public Collider2D hitboxlv2;
	public Collider2D hitboxlv3;
	public Collider2D hitboxDownlv1;
	public Collider2D hitboxDownlv2;
	public Collider2D hitboxDownlv3;
	public Collider2D hitboxUplv1;
	public Collider2D hitboxUplv2;
	public Collider2D hitboxUplv3;

    public GameObject attackanimlv1;
    public GameObject attackanimlv2;
	public GameObject attackanimlv3;
	public GameObject attackDownanimlv1;
	public GameObject attackDownanimlv2;
	public GameObject attackDownanimlv3;
	public GameObject attackUpanimlv1;
	public GameObject attackUpanimlv2;
	public GameObject attackUpanimlv3;

    ///////////////////////////////////////
    ///            Die                  ///
    ///////////////////////////////////////
    // 주인공 체력
    public int playerHealth = 6;
    public bool PlayerIsDead;
    public Transform respawnTrans;
    public Image image4fade;

    ///////////////////////////////////////
    // 				Dash                ///
    ///////////////////////////////////////
    private bool dash = false;
	private int dashnum =0; // 대쉬 가능 횟수
	public float dashSpeed=25.0f;
	public float dashCd=1;
	private float dashTimer = 0;
    public float dashdistance=0.3f;
    private bool candash = true; // 대쉬 도중 컬라이더랑 부딪히면 false 됨

    /////////////////////////////////////
    ///             Jump              /// 
    /////////////////////////////////////
    private bool jump = false;
    public bool grounded = false;
	private bool canjumpdown = false;
    public int jumpcount;
    private bool jumpdown = false;
	
    public float jumpForce= 9;
    private bool hanginwall = false;

    /////////////////////////////////
    //         Wall Sliding        //
    /// /////////////////////////////
    public bool wallsliding;


	// Use this for initialization
	void Start () {
		if(instance!=null){				// 인스턴스가 있는데 
			if(instance !=this){		// 그게 내 자신이 아니라면
				Destroy(gameObject);	// 내 자신을 파괴한다.	
			}
		}
	}
	
	void Awake(){

        jumpcount = 2;
        wallsliding = false;

        //public 변수들 find로 다 넣어주기
        anim = GameObject.Find("Player/PlayerAnimator").GetComponent<Animator>();
        MagicCircle = GameObject.Find("Player/MagicCircle");
        Magic_A = GameObject.Find("Player/MagicCircle/Magic_A");
        Magic_S = GameObject.Find("Player/MagicCircle/Magic_S");
        Magic_D = GameObject.Find("Player/MagicCircle/Magic_D");
        Idle = GameObject.Find("Player/PlayerColliderIdle");
        Crouch = GameObject.Find("Player/PlayerColliderCrouch");
        hitboxlv1 = GameObject.Find("Player/Attack/hitboxLv.1").GetComponent<Collider2D>();
        hitboxlv2 = GameObject.Find("Player/Attack/hitboxLv.2").GetComponent<Collider2D>();
        hitboxlv3 = GameObject.Find("Player/Attack/hitboxLv.3").GetComponent<Collider2D>();
        hitboxDownlv1 = GameObject.Find("Player/Attack/hitboxDownLv.1").GetComponent<Collider2D>();
        hitboxDownlv2 = GameObject.Find("Player/Attack/hitboxDownLv.2").GetComponent<Collider2D>();
        hitboxDownlv3 = GameObject.Find("Player/Attack/hitboxDownLv.3").GetComponent<Collider2D>();
        hitboxUplv1 = GameObject.Find("Player/Attack/hitboxUpLv.1").GetComponent<Collider2D>();
        hitboxUplv2 = GameObject.Find("Player/Attack/hitboxUpLv.2").GetComponent<Collider2D>();
        hitboxUplv3 = GameObject.Find("Player/Attack/hitboxUpLv.3").GetComponent<Collider2D>();
        attackanimlv1 = GameObject.Find("Player/Attack/hitboxLv.1/slashlv1");
        attackanimlv2 = GameObject.Find("Player/Attack/hitboxLv.2/slashlv2");
        attackanimlv3 = GameObject.Find("Player/Attack/hitboxLv.3/slashlv3");
        attackDownanimlv1 = GameObject.Find("Player/Attack/hitboxDownLv.1/slashDownlv1");
        attackDownanimlv2 = GameObject.Find("Player/Attack/hitboxDownLv.2/slashDownlv2");
        attackDownanimlv3 = GameObject.Find("Player/Attack/hitboxDownLv.3/slashDownlv3");
        attackUpanimlv1 = GameObject.Find("Player/Attack/hitboxUpLv.1/slashUplv1");
        attackUpanimlv2 = GameObject.Find("Player/Attack/hitboxUpLv.2/slashUplv2");
        attackUpanimlv3 = GameObject.Find("Player/Attack/hitboxUpLv.3/slashUplv3");
   

        //anim = GetComponent<Animator>();
        PlayerIsDead = false;
		MagicCircle.SetActive(false);
		Magic_A.SetActive(false);
		Magic_S.SetActive(false);
		Magic_D.SetActive(false);

		rb2d = GetComponent<Rigidbody2D>();
		myTrans = this.transform;
        //myTrans.position = new Vector3((PlayerPrefs.GetFloat("characterrespawnx_CharacterSlot" + gameloadslot.slotnum)), (PlayerPrefs.GetFloat("characterrespawny_CharacterSlot" + gameloadslot.slotnum)), (PlayerPrefs.GetFloat("characterrespawnz_CharacterSlot" + gameloadslot.slotnum)));

        hitbox = hitboxlv1;
		hitboxDown = hitboxDownlv1;
		hitboxUp = hitboxUplv1;
		attackanim = attackanimlv1;
		attackDownanim = attackDownanimlv1;
		attackUpanim = attackUpanimlv1;
		
		hitboxlv1.enabled = false;
		hitboxDownlv1.enabled = false;
		hitboxUplv1.enabled = false; 
		attackanimlv1.SetActive(false);
       
		attackDownanimlv1.SetActive(false);
		attackUpanimlv1.SetActive(false);

		hitboxlv2.enabled = false;
		hitboxDownlv2.enabled = false;
		hitboxUplv2.enabled = false; 
		attackanimlv2.SetActive(false);
		attackDownanimlv2.SetActive(false);
		attackUpanimlv2.SetActive(false);
		
		hitboxlv3.enabled = false;
		hitboxDownlv3.enabled = false;
		hitboxUplv3.enabled = false; 
		attackanimlv3.SetActive(false);
		attackDownanimlv3.SetActive(false);
		attackUpanimlv3.SetActive(false);

		Crouch.SetActive(false);
	}
	void CheckAttackLv(){
		if(AttackLv==1){
			hitbox = hitboxlv1;
			hitboxDown = hitboxDownlv1;
			hitboxUp = hitboxUplv1;
            attackanim = attackanimlv1;
            attackDownanim = attackDownanimlv1;
			attackUpanim = attackUpanimlv1;
		}
		else if(AttackLv==2){
			hitbox = hitboxlv2;
			hitboxDown = hitboxDownlv2;
			hitboxUp = hitboxUplv2;
			attackanim = attackanimlv2;
			attackDownanim = attackDownanimlv2;
			attackUpanim = attackUpanimlv2;
		}
		else if(AttackLv==3){
			hitbox = hitboxlv3;
			hitboxDown = hitboxDownlv3;
			hitboxUp = hitboxUplv3;
			attackanim = attackanimlv3;
			attackDownanim = attackDownanimlv3;
			attackUpanim = attackUpanimlv3;
		}
	}
    
    void CheckifDie()
    {
        if (playerHealth < 1)
        {
            PlayerIsDead = true;
            // 죽으면 어떻게 되는가
        }
    }

    

	void AtkSpeedControl(){
		if(Input.GetKeyDown(KeyCode.F6)){
			attackCd += 0.1f;
			Debug.Log("공속 감소");	
		}
		else if (Input.GetKeyDown(KeyCode.F7)){
			attackCd -= 0.1f;
			Debug.Log("공속 증가");
		}
	}

    IEnumerator fadeoutandin()
    {
        Color startColor = image4fade.color;
        for (int i = 0; i < 30; i++)
        {
            startColor.a = startColor.a + 0.033f;
            image4fade.color = startColor;
            yield return new WaitForSeconds(0.02f);
        }
        for (int i = 0; i < 20; i++)
        {
            startColor.a = startColor.a - 0.05f;
            image4fade.color = startColor;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator WaitAndRespawn()
    {
        StartCoroutine(fadeoutandin());
        yield return new WaitForSeconds(1f);

        myTrans.position = respawnTrans.position;
       
    }

    // Update is called once per frame
    void Update () {
        Debug.DrawRay(transform.position, new Vector3(1,0), Color.green);
        AnimatorController();
        CheckAttackLv();
        CheckifDie();
        AtkSpeedControl();

        if (playerHealth < 1)
        {
            StartCoroutine(WaitAndRespawn());
            playerHealth = 6;
        }

		if(Input.GetKeyDown(KeyCode.A)){
            MagicCircle.SetActive(true);
            Magic_A.SetActive(true);
            AisOn = true;
		}
		if(Input.GetKeyDown(KeyCode.S)){
			MagicCircle.SetActive(true);
			Magic_S.SetActive(true);
			SisOn = true;
		}
		if(Input.GetKeyDown(KeyCode.D)){
			MagicCircle.SetActive(true);
			Magic_D.SetActive(true);
			DisOn = true;
		}

		if(Input.GetKeyDown(KeyCode.Space)){
            MagicCircle.SetActive(false);	
            Magic_A.SetActive(false);
            Magic_S.SetActive(false);
			Magic_D.SetActive(false);

            if (AisOn && !SisOn && !DisOn){
                //anim.SetTrigger("skillA");
                if (lookRight)
                {
                    Debug.Log("A Activate");
                    skillainstance = Instantiate(skillaRight, myTrans.position, myTrans.rotation);
                }
                else
                    skillainstance = Instantiate(skillaLeft, myTrans.position, myTrans.rotation);
            }
			else if(!AisOn && SisOn && !DisOn){
				Debug.Log("S Activate");
			}
			else if(!AisOn && !SisOn && DisOn){
				Debug.Log("D Activate");
			}
            else if (AisOn && SisOn && !DisOn){
                Debug.Log("A & S Activate");
            }
            else if(AisOn && DisOn && !SisOn)
            {
                Debug.Log("A & D Activate");
            }
            else if(SisOn && DisOn && !AisOn)
            {
                Debug.Log("S & D Activate");
            }
            else if(AisOn && SisOn && DisOn)
            {
                Debug.Log("A & S & D Activate");
            }
            AisOn = false;
            SisOn = false;
            DisOn = false;
		}


		if(Input.GetKeyDown(KeyCode.F1)){
			AttackLv =1;
			Debug.Log(AttackLv);
			CheckAttackLv();
		}
		else if(Input.GetKeyDown(KeyCode.F2)){
			AttackLv =2;
			Debug.Log(AttackLv);
			CheckAttackLv();
		}
		else if(Input.GetKeyDown(KeyCode.F3)){
			AttackLv =3;
			Debug.Log(AttackLv);
			CheckAttackLv();
		}
		
		if(Input.GetKey(KeyCode.DownArrow)&&grounded&&!GetAttacked){
			crouch = true;
		}
		else{
			crouch = false;
		}

		if(Input.GetKey(KeyCode.DownArrow)&&canjumpdown&&Input.GetKey(KeyCode.Z)){
			jumpdown = true;
		}

		if (Input.GetKeyDown(KeyCode.Z)&&!crouch&&jumpcount>0)
        {
            jump = true;
            jumpcount--;
            Debug.Log(jumpcount);
            grounded = false;
           
        }
		
		if(Input.GetKeyDown(KeyCode.X) && !attack && !GetAttacked){
			attack = true;
			attackTimer = attackCd;
			
			if(!grounded&&Input.GetKey(KeyCode.DownArrow)){
				hitboxDown.enabled = true;
				attackDownanim.SetActive(true);
			}
			else if(!grounded&&Input.GetKey(KeyCode.UpArrow)){
				hitboxUp.enabled = true;
				attackUpanim.SetActive(true);
			}
			else if(grounded&&Input.GetKey(KeyCode.UpArrow)){
				hitboxUp.enabled = true;
				attackUpanim.SetActive(true);
			}
			else{
				hitbox.enabled = true;
                anim.SetTrigger("attack1");
                //attackanim.SetActive(true);
			}
		}

		if(Input.GetKeyDown(KeyCode.C) && !dash&&!crouch){
			dash = true;
			dashnum ++;
			dashTimer = dashCd;
		}


		if(crouch){
			Idle.SetActive(false);
			Crouch.SetActive(true);
		}
		else{
			Idle.SetActive(true);
			Crouch.SetActive(false);
		}



		if(GetAttacked){
			GetAttackedMoment = true;
			if(attackedTimer >0){
				attackedTimer -= Time.deltaTime;
			}
			else{
				GetAttacked = false;
			}
		}


		if(dash){
            if (once)
            {
                anim.SetTrigger("isdash");
                once = false;
            }
            
            if (dashTimer > 0){
				dashTimer -= Time.deltaTime;
			}
			else{
				dash = false;
                once = true;
                //anim.SetBool("isdash", false);
            }
		}

		if(attack){
			if(attackTimer > 0){
				attackTimer -= Time.deltaTime;
			}
			else{
				attack = false;
				hitbox.enabled = false;
				attackanim.SetActive(false);
				hitboxDown.enabled = false;
				attackDownanim.SetActive(false);
				hitboxUp.enabled = false;
				attackUpanim.SetActive(false);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.layer != 8)
        {
            candash = false;
        }
        if (col.gameObject.layer == 8)
        { // layer 8 : ground
           
            //grounded = true;
            //jumpcount = 2;
            anim.SetBool("isjumping", false);
        }
        if (col.gameObject.tag == "ClimbingWall")
        {
            //jumpcount = 2;
            //grounded = true;
        }
		if(col.gameObject.tag == "GroundCanJumpDown"){
           // jumpcount = 2;
            //grounded = true;
            canjumpdown = true;
		}
		if(jumpdown&&col.gameObject.tag == "GroundCanJumpDown"){
			col.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        candash = true;
    }

    void OnCollisionStay2D(Collision2D col){
		if(jumpdown&&col.gameObject.tag == "GroundCanJumpDown"){
			col.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "EndOfScene")
        {
            Debug.Log("TriggerEnter");
            MoveCamera.GetInstance().CameraCanMove = false;
        }

    }

    void OnTriggerExit2D(Collider2D col){
        if (col.gameObject.tag == "EndOfScene")
        {
            Debug.Log("TriggerExit");
            MoveCamera.GetInstance().CameraCanMove = true;
        }

        if (col.gameObject.tag == "GroundCanJumpDown"){
			col.gameObject.GetComponent<Collider2D>().enabled = true;
			canjumpdown = false;
			jumpdown = false;
		}

        if(col.gameObject.tag == "CheckPointR")
        {
            Debug.Log("Enter");
            ObstacleScript.instance.respawntrans.position = ObstacleScript.instance.respawntransR.position;
        }

	}

    IEnumerator delaydash()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isdash", false);
    }

	public void Knockback(float knockbackPwr,bool Leftknock){
		 
			Vector2 knockvel = rb2d.velocity;
			if(Leftknock){
				knockvel.y = knockbackPwr;
				knockvel.x = -knockbackPwr;
			}
			else{
				knockvel.y = knockbackPwr;
				knockvel.x = knockbackPwr;
			}
			rb2d.velocity = knockvel;
	}

	void FixedUpdate(){
		Move(Input.GetAxis("Horizontal"));
        HandleDash();

        if (Input.GetAxis("Horizontal")>0 && !lookRight &&!GetAttacked){
			Flip();
			lookRight = true;
		}
        else if (Input.GetAxis("Horizontal")<0 && lookRight&&!GetAttacked){
			Flip();
			lookRight = false;
		}

		if (jump&&!GetAttacked)
        {
            rb2d.velocity = Vector2.up*jumpForce;
            jump = false;
            if (jumpcount == 1)
            {
                anim.SetBool("isjumping", true);
            }
            else if (jumpcount == 0)
            {
                anim.SetTrigger("doublejump");
            }
        }

	}

    public void AnimatorController()
    {

        anim.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal"))*Speed);
    }

	public void Move(float horizontalInput){
		Vector2 moveVel = rb2d.velocity;
		if(!crouch&&!GetAttacked){
            /*
			if(dash && dashnum>0){
				dashnum--;

				if(lookRight){
                 //   moveVel.x =  Speed * dashSpeed;
                    //moveVel.x = horizontalInput/Mathf.Abs(horizontalInput) * dashSpeed*2;
                }
				else{
					//moveVel.x =  -1 * Speed * dashSpeed;
				}
			}
            */
			//else{
		    		moveVel.x = horizontalInput * Speed;
			//}
		}
		rb2d.velocity = moveVel;
	}

    private void HandleDash()
    {
        if (!crouch && !GetAttacked)
        {
            Debug.Log("1");
            if (dash && dashnum>0 )
            {
                Debug.Log("2");
                dashnum--;
                StartCoroutine(DashLoop());
            }
        }
    }

    IEnumerator DashLoop()
    {
        Debug.Log("3");
        if (lookRight)
            for (int i = 0; i < 10; i++)
            {
                if (candash)
                {
                    transform.position += new Vector3(1, 0).normalized * dashdistance;
                    yield return new WaitForSeconds(0.001f);
                }
            }
        else
            for (int i = 0; i < 10; i++)
            {
                if (candash)
                {
                    transform.position += new Vector3(-1, 0).normalized * dashdistance;
                    yield return new WaitForSeconds(0.001f);
                }
            }
    }

	void Flip()
    {
        lookRight = !lookRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void PlayerHit(Vector3 vect)
    {
        bool LeftKnock;
        GetAttacked = true;
        attackedTimer = 0.7f;
        playerHealth -= 1;

        if (vect.x > myTrans.position.x)
        {
            LeftKnock = true;       //왼쪽에서 맞았나 오른쪽에서 맞았나 판단
        }
        else
        {
            LeftKnock = false;
        }
       Knockback(5f, LeftKnock);
    }
}
