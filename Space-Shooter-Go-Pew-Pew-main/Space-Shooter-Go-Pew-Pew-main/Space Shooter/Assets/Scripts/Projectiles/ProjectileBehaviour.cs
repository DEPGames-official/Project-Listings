using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed;

    void Update()
    {

        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            var scriptHealth = collision.gameObject.GetComponent<MeteorHealth>();
            scriptHealth.health -= 25;
            Destroy(gameObject);
        }
    }
}
