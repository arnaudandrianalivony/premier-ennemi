using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyBehaviour : MonoBehaviour
{
    public Animator anim;                                      // represente l'annimation de l'ennemi;
    public GameObject player;                                  // represente le joueur
    public float posPlayer;                                    // represente la position du joueur
    public Collider2D colPlayer;                               // represente le collider du joueur
    public float posEnnemy;                                    // represente la position de l'ennemi
    public Collider2D colEnnemy;                               // represente le collider de l'ennemi
    public Rigidbody2D rb;                                     // represente le rigidbody de l'ennemi
    public float area;                                         // zone definie pour l'ennemi
    public float range;                                        // zone de vision de l'ennemi
    public bool onGoing;                                       // defini si l'ennemi effectue un aller dans son animation
    public bool isInRange;                                     // defini si l'ennemi est a bonne distance du joueur
    public float start;                                        // defini le point de depart de l'annimation de l'ennemi
    public float end;                                          // defini le point d'arrivée de l'annimation de l'ennemi
    public float vitesse;                                      // represente la vitesse de l'ennemi


    // Start is called before the first frame update
    void Start()
    {
        posPlayer = transform.position.x;
        posEnnemy = transform.position.x;
        start = posEnnemy;
        end = posEnnemy + area;
        colPlayer = player.GetComponent<Collider2D>();
        colEnnemy = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();        
        onGoing = true;
        isInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        posEnnemy = transform.position.x;
        posPlayer = player.transform.position.x;
        isInRange = (abs(posPlayer - posEnnemy) < range);
        if(isInRange)
        {
            anim.SetTrigger("Run");
            Follow();
        }
        else
        {
            if((posEnnemy < start) || (posEnnemy > end))
            {
                Return();
            }
            else
            {
                Walk();
            }
        }
        if(colEnnemy.IsTouching(colPlayer))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    // fonction qui permet a l'ennemi d'effectuer des aller-retour
    void Walk()
    {
        if(onGoing)
        {
            rb.velocity = new Vector2(vitesse, 0);
        }
        else
        {
            rb.velocity = new Vector2(-vitesse, 0);
        }
    }

    // fonction qui permet a l'ennemi de poursuivre le joueur
    void Follow()
    {
        if(posPlayer + 0.1f < posEnnemy)
        {
            rb.velocity = new Vector2(-vitesse, 0);
        }
        else if(posPlayer - 0.1f > posEnnemy)
        {
            rb.velocity = new Vector2(vitesse, 0);
        }
        else
        {
            transform.position = player.transform.position;
            anim.ResetTrigger("Run");
        }
    }


    // permet a l'ennemi de retourner dans sa zone d'origine
    void Return()
    {
        if(posEnnemy < start)
        {
            if(!onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(vitesse, 0);
        }
        if(posEnnemy > end)
        {
            if(onGoing)
            {
                onGoing = !onGoing;
                Vector2 vect = transform.localScale;
                vect = new Vector2(-vect.x, vect.y);
                transform.localScale = vect;
            }
            rb.velocity = new Vector2(-vitesse, 0);
        }
    }


    // fonction valeur absolue
    float abs(float a)
    {
        float res;
        if(a > 0.0f)
        {
            res = a;
        }
        else
        {
            res = - a;
        }
        return res;
    }
}
