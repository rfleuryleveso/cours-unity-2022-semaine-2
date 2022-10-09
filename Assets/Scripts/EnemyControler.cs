using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if (collision.relativeVelocity.magnitude > 2)
        {
            health -= Mathf.RoundToInt(collision.relativeVelocity.magnitude);
            Debug.Log($"Health {health}");
            if (health < 0)
            {
                this.HandleDeath();
            }
            
        }
    }

    void HandleDeath()
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.None;
        rigidbody.AddForce(new Vector3(2,0,0));
        StartCoroutine(WaitAndDestroy());
    }
    
    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2);
        GameObject.Destroy(gameObject);
    }
}