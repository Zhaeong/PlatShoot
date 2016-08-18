using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D curRigidbody;
    [HideInInspector]
    public bool facingRight = true;         // For determining which way the player is currently facing.
    [HideInInspector]
    public bool jump = false;				// Condition for whether the player should jump.
    public float speed = 3f;
    public float jumpForce = 300f;			// Amount of force added when the player jumps.
    private bool grounded = false;			// Whether or not the player is grounded.
    private Transform groundCheck;			// A position marking where to check if the player is grounded.

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
    }

    // Use this for initialization
    void Start()
    {
        curRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            Debug.Log("Jump pressed" + grounded);
        }

    }

    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");

        float input_x = Input.GetAxisRaw("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(input_x * speed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        // If the player should jump...
        if (jump)
        {

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }

    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
