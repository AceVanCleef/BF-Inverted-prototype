using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMover2D : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.forward * speed;
	}
	
	
}
