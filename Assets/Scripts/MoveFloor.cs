using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour
{
    public float speed;

    bool movePos;
    Vector3 dir;
    float timer;

    void Start()
    {
        timer = 0f;

        if (gameObject.name == "Moving Floor")
        {
            dir = Vector2.left;

        } else
        {
            dir = Vector2.up;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5f)
        {
            dir = -dir;
            timer = 0f;
        }

        transform.Translate(-dir * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character"))
        {
            other.transform.parent = null;
        }
    }
}