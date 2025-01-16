using UnityEngine;

public class MeteorHealth : MonoBehaviour
{
    public int health = 100;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
