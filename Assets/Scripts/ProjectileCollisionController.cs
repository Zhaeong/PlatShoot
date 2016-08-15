using UnityEngine;
using System.Collections;

public class ProjectileCollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 3);

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(gameObject);

    }

}
