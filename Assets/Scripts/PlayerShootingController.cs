using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject gunMuzzle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShoot()
    {
        Debug.Log("Shooting");
        
        GameObject newBullet = Instantiate(this.bullet, gunMuzzle.transform.position + gunMuzzle.transform.forward, Quaternion.Euler(-90,0,90));
        Rigidbody rigidbody = newBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(gunMuzzle.transform.forward * 1000);
        gun.GetComponent<Animation>().Play();
    }
}
