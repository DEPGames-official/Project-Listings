using UnityEngine;

public class MeteorMovement : MonoBehaviour
{

    public Vector2 speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.activeSelf == true)
        {
            Vector3 movement = Vector2.down * speed;
            movement *= Time.deltaTime;
            transform.Translate(movement);
        }


    }
}
