using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileConsumer : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col)
    {
        print("ouch");

        if (col.gameObject.tag == "Projectile")
        {
            Destroy(col.gameObject);
        }
    }
}
