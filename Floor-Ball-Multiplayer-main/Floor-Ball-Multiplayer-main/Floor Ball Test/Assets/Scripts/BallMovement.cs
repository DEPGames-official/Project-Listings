using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public Transform groundCheckTransform;

    public Transform playerTransform;

    public SphereCollider thisCollider;

    [Range (0f, 500f)]
    public float Speed;

    public int r;

    public bool rotateAroundPlayer = true;

    public float rotationSpeed;

    public bool lookAtPlayer = true;

    public Rigidbody thisRb;

    public float Horizontal;

    public float Vertical;

    public Transform cameraTransform;

    Vector3 offset;

    float backUpSpeed;

    public float jumpSpeed;

    bool isGrounded;

    public float distToGround;

    RaycastHit hit;

    public bool ignore;

    public Vector3 dir;

    public Collider Pcollider;
    void Start () {

        dir = new Vector3 (0, -1);

        backUpSpeed = Speed;

        offset = new Vector3 (0f, +1f, -1.5F);

        //Make cursor locked
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update () {

        ballMovement ();

        groundCheck ();

        ballSpeedContainment ();

        BallMoveMouse ();

        ballSpeed ();

        //checkForGround();
    }

    void ballMovement () {

        Horizontal = Input.GetAxis ("Horizontal");

        Vertical = Input.GetAxis ("Vertical");

        var camForward = cameraTransform.forward;
        camForward.y = 0.0f;
        camForward = new Vector3 (cameraTransform.forward.x, camForward.y, cameraTransform.forward.z);

        Vector3 forceDirection = camForward;
        Vector3 forceDirection2 = cameraTransform.right;
        thisRb.AddForce (Vertical * forceDirection * Speed * Time.deltaTime);
        thisRb.AddForce (Horizontal * forceDirection2 * Speed * Time.deltaTime);

        if (Input.GetKeyDown (KeyCode.Space)) {
            if (isGrounded == true) {
                thisRb.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
            }

        }

    }

    void BallMoveMouse () {

        if (rotateAroundPlayer == true) {
            offset = Quaternion.AngleAxis (Input.GetAxis ("Mouse X") * rotationSpeed, Vector3.up) * offset;
            cameraTransform.position = this.transform.position + offset;
            cameraTransform.LookAt (this.transform);

        }

        if (lookAtPlayer || rotateAroundPlayer) {
            cameraTransform.LookAt (this.transform);
        }

    }

    void ballSpeedContainment () {
        if (Horizontal == 1 && Vertical == 1 || Horizontal == -1 && Vertical == -1 || Horizontal == 1 && Vertical == -1 || Horizontal == -1 && Vertical == 1) {

            Speed = 100;

        } else {
            Speed = backUpSpeed;
        }

        if (Horizontal == 0 && Vertical == 0) {

            thisRb.angularDrag = 8f;
        } else if (Horizontal == 0 || Vertical == 0 || Horizontal != 0 || Vertical != 0) {

            thisRb.angularDrag = 3f;

        }

    }

    void ballSpeed () {
        var playerSpeed = thisRb.velocity;

        //print(playerSpeed);

    }

    public void groundCheck () {
        groundCheckTransform.position = playerTransform.position;

        float maxDistance = 0.4f;

        if (Physics.Raycast (transform.position, dir, out hit, maxDistance)) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }

}