using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Rigidbody2D curRigidbody;

    // Use this for initialization
    void Start () {
        curRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {



    }

    void FixedUpdate()
    {
        float input_x = Input.GetAxisRaw("Horizontal");
        float input_y = Input.GetAxisRaw("Vertical");
        curRigidbody.velocity = new Vector2(input_x * speed, input_y * speed);

    }

    void flip()
    {
        foreach (Transform child in transform)
        {
            Vector3 theScale = child.transform.localScale;
            theScale.x *= -1;
            child.transform.localScale = theScale;
        }
    }
}
