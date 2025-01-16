using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(0f, 500f)]
    public float speed;

    Rigidbody thisRb;

    public bool rotateAroundPlayer = true;
    public float rotationSpeed;
    public bool lookAtPlayer = true;

    public float horizontal;
    public float vertical;

    public Transform cameraTransform;
    Vector3 OffSet;

    void Start()
    {
        thisRb = this.GetComponent<Rigidbody>();
        OffSet = new Vector3(0f, +1.5f, -5.5f);
    }


    void Update()
    {

        PlayerMoveMouse();
        PlayerMove();
        //PlayerSpeed();
    }

    void PlayerMove()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        var camForward = cameraTransform.forward;
        camForward.y = 0.0f;
        camForward = new Vector3(cameraTransform.forward.x, camForward.y, cameraTransform.forward.z);

        Vector3 forceDirection = camForward;
        Vector3 forceDirection2 = cameraTransform.right;
        thisRb.AddForce(vertical * forceDirection * speed * Time.deltaTime);
        thisRb.AddForce(horizontal * forceDirection2 * speed * Time.deltaTime);
    }



    void PlayerMoveMouse()
    {

        if (rotateAroundPlayer)
        {
            OffSet = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up) * OffSet;
            cameraTransform.position = this.transform.position + OffSet;
            cameraTransform.LookAt(this.transform);
        }

        if (lookAtPlayer || rotateAroundPlayer)
        {
            cameraTransform.LookAt(this.transform);
        }
    }

    void PlayerSpeed()
    {
        var playerSpeed = thisRb.velocity;
        print(playerSpeed);
    }

}
