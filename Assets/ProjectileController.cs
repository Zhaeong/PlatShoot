using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float ProjectileSpeed;
    public GameObject Projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.E))
        {
            Instantiate(Projectile, gameObject.transform.position, gameObject.transform.rotation);
            Projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(ProjectileSpeed, 0);
        }

	
	}
}
