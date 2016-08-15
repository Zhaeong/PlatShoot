using UnityEngine;
using System.Collections;

public class ProjectileController : MonoBehaviour {

    public float ProjectileSpeed;
    public GameObject Projectile;
    public Transform projectileSpawn;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 force = new Vector2(ProjectileSpeed, 0);
        Vector3 newForce = transform.localRotation * force;

        if (Input.GetKey(KeyCode.E))
        {
            //Vector3 vSpawnPos =  new Vector3(gameObject.transform.localPosition.x + 0.1f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

            GameObject Clone = Instantiate(Projectile, projectileSpawn.position, gameObject.transform.rotation) as GameObject;
            Clone.GetComponent<Rigidbody2D>().AddForce(newForce);
        }

	
	}
}
