using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileConsumer : MonoBehaviour {

    public int healthRecovered = 5;

    void OnCollisionEnter2D(Collision2D col)
    {

        if (tag.Equals("Player") && col.gameObject.tag == "Projectile")
        {
            //regainHealth
            //GetComponent<UnitHealth>().regainHealth(healthRecovered);
            Destroy(col.gameObject);
        }
        else if (tag.Equals("Enemy") && col.gameObject.tag == "EnemyProjectile")
        {
            //regainHealth
            //GetComponent<UnitHealth>().regainHealth(healthRecovered);
            Destroy(col.gameObject);
        }
        //regainHealth
        GetComponent<UnitHealth>().regainHealth(healthRecovered);
    }
}
