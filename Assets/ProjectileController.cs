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
            Vector3 vSpawnPos = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, gameObject.transform.position.z);
            GameObject Clone = Instantiate(Projectile, vSpawnPos, gameObject.transform.rotation) as GameObject;
            Clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(ProjectileSpeed, 0));
        }

	
	}
}
