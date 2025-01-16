using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 speed;
    public Vector2 playerBarrier;
    void Start()
    {
        speed = new Vector2(20, 20);
    }

    public float inputX;
    public float inputY;



    //private CharacterController controller;
    void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        //print($"Input X = {inputX} \n Input Y ={inputY}");

        /*Vector2 movement = new Vector2(inputX * speed.x, inputY * speed.y);
        movement *= Time.deltaTime;
        transform.Translate(movement);*/

        Vector3 move = new Vector3(inputX, inputY, 0);
        //controller.Move(move * Time.deltaTime * speed);



    }
}
