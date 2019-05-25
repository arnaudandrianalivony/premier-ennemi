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
    public float area = 15.0f;                                 // zone definie pour l'ennemi
    public float range;                                        // zone de vision de l'ennemi
    public bool onGoing;                                       // defini si l'ennemi effectue un aller dans sons animation
    public bool isInRange;                                     // defini si l'ennemi est a bonne distance du joueur
    public float start;                                        // defini le point de depart de l'annimation de l'ennemi
    public float end;                                          // defini le point d'arrivée de l'annimation de l'ennemi


    // Start is called before the first frame update
    void Start()
    {
        posEnnemy = transform.position.x;
        start = posEnnemy;
        end = posEnnemy + area;
        posPlayer = player.transform.position.x;
        colPlayer = player.GetComponent<Collider2D>();
        colEnnemy = GetComponent<Collider2D>();        
        onGoing = true;
        isInRange = false;
        colPlayer = player.GetComponent<Collider2D>();
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
                onGoing = !onGoing;
                Vector3 vect = transform.localScale;
                vect.x*=-1;
                transform.localScale = vect;
            }
            Walk();
        }
        if(colEnnemy.IsTouching(colPlayer))
        {
            anim.SetTrigger("Attack_ennemy");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }

    // fonction qui permet a l'ennemi d'effectuer des aller-retour
    void Walk()
    {
        if(onGoing)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, 0.0f, 0.0f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - 0.1f, 0.0f, 0.0f);
        }
    }

    // fonction qui permet a l'ennemi de poursuivre le joueur
    void Follow()
    {
        if(posPlayer + 0.1f < posEnnemy)
        {
            transform.position = new Vector3(transform.position.x - 0.1f, 0.0f, 0.0f);
        }
        else if(posPlayer - 0.1f > posEnnemy)
        {
            transform.position = new Vector3(transform.position.x + 0.1f, 0.0f, 0.0f);
        }
        else
        {
            transform.position = player.transform.position;
            anim.ResetTrigger("Run");
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
