using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;


    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private Animator anim;
    public bool MoveEnable = false;
    public Slider hpSlider;
    public float Hp=10;
    public float hpMoveSpeed = 1;
    public GameObject warningImg;
    public GameObject endPanel;
    public GameManager manager;
    public int getCoin=0;
    public void StartMove()
    {
        MoveEnable = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hpSlider.maxValue = Hp;
        hpSlider.value = Hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MoveEnable) return;
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, whatIsGround);
        hpSlider.value = Hp;// Mathf.Lerp(hpSlider.value, Hp, hpMoveSpeed*Time .deltaTime );
        //if (Input.GetKey(left))
        //{
        //    theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        //}
        //else
        //if (Input.GetKey(right))
        //{
        //    theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        //}
        //else
        //{
        //    theRB.velocity = new Vector2(0, theRB.velocity.y);
        //}
        theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
        if (Hp <= 4)
        {
            warningImg.SetActive(true);
        }
        if(Hp <= 0)
        {
            Time.timeScale = 0;
            endPanel.SetActive(true);
            manager.EndGame(getCoin);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision .tag == "XJ")//陷阱
        {
            collision.gameObject.GetComponent<Trap>().ShowAniamtion();
            Hp -= 2;
            
        }else if(collision .tag == "HX")//回血
        {
            Destroy(collision.gameObject);
            if (Hp <= 8)
                Hp += 2;
        }else if(collision .tag == "Coin")
        {
            Destroy(collision.gameObject);
            getCoin += 1;
        }
       
    }
   
}
