using System.Threading;
using UnityEngine;

public class PlayerMechanics : MonoBehaviour
{
    public ProjectileBehaviour projectilePrefab;
    public Transform launchOffset;
    
    public float shootTimer;
    float shootTimerBackup;

    private void Awake()
    {
        shootTimerBackup = shootTimer;
    }

    void Update()
    {
        ShootGun();
    }

    
    void ShootGun()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shootTimer -= Time.deltaTime;
            while (shootTimer <= 0)
            {
                Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
                shootTimer = shootTimerBackup;
            }
            
            
        }
    }
}
