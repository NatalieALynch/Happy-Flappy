using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    private Animator anim;
    public float UpAndAway = 200f;
    private Rigidbody2D rb2d;
    private bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, UpAndAway));
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        dead = true;
        anim.SetTrigger("Death");
        GameControl.instance.BirdDied();
    }
}
