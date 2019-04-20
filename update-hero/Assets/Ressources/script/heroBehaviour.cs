using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heroBehaviour : MonoBehaviour
{

    public Rigidbody2D rb;                    // Rigidbody du hero
    public float vitesse;                     // Vitesse du hero
    public float upforce;                     // Distance de saut du hero
    private Animator anim;                    // Animation du hero
    public bool isfacing;                     // Definit si le hero est tourne vers la droite
    private bool isGrounded;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isfacing = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Run", false);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.zero;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-vitesse, 0);
            anim.SetBool("Run", true);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(vitesse, 0);
            anim.SetBool("Run", true);
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("Run", false);
        }
        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("Run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(!(col.gameObject.CompareTag("Ground")))
        {
            isGrounded = false;
        }
    }

    protected void Flip()
    {
        isfacing = !isfacing;
        Vector3 vecteur = transform.localScale;
        vecteur.x*=-1;
        transform.localScale = vecteur;
    }

    
}
