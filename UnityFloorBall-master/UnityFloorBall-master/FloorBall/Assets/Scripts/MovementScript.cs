using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    float timeDone = 0;
    public float timer = 1;
    public Rigidbody rb;
    public float Speed;
    public float Horizontal;
    public float Vertical;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void playerMoveMent()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        rb.AddForce(Horizontal * Speed * Time.deltaTime, 0, Vertical * Speed * Time.deltaTime, ForceMode.VelocityChange);

        if (Horizontal == 0 && Vertical == 0)
        {
            rb.angularDrag = 5;
        }
        else
        {
            rb.angularDrag = 0;
        }
    }


    private void Update()
    {
        playerMoveMent();
    }
    

}