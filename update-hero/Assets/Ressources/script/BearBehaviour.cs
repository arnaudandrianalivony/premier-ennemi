using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBehaviour : MonoBehaviour
{
    public Animator anim;                     // animation de l'ennemi
    public Transform ennemyPos;               // position de l'ennemi
    public Transform target;                  // position du joueur
    public bool isInRange = false;            // definit si l'ennemi est a bonne distance du joueur
    public float dist;                        // distance entre l'ennemi et le joueur
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.ResetTrigger("Attente");
        dist = Vector2.Distance(ennemyPos.position, target.position);
        isInRange = dist < 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector2.Distance(ennemyPos.position, target.position);
        isInRange = dist < 10.0f;
        if(isInRange)
        {
            anim.SetTrigger("Attente");
        }
        else
        {
            anim.ResetTrigger("Attente");
        }
    }
}
