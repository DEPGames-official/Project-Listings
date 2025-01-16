using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : ColourRandomScript
{
    public SphereCollider player;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            Destroy(Player);
        }

    }

}