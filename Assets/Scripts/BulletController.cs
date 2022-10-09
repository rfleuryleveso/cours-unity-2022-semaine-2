using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float creationTime;
    // Start is called before the first frame update
    void Start()
    {
       this.creationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time - this.creationTime > 0.3)
        {
            StartCoroutine(WaitAndDestroy());
        }
    }
    
    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.Destroy(gameObject);
    }

}
