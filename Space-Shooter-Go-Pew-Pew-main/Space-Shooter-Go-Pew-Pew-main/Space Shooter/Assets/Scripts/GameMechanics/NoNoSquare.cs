using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoNoSquare : MonoBehaviour
{
    Collider2D thisCollider;
    Collider2D colliderToIgnore;

    private void Awake()
    {
        thisCollider = gameObject.GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    


    // Update is called once per frame
    void Update()
    {
        //Physics.IgnoreCollision(thisCollider, colliderToIgnore);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        
        if (collision.gameObject.tag != "Player")
        {
            colliderToIgnore = collision.gameObject.GetComponent<Collider2D>();
            Physics2D.IgnoreCollision(colliderToIgnore, thisCollider);
        }
    }
}
