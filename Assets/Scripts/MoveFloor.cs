using UnityEngine;
using System.Collections;

public class MoveFloor : MonoBehaviour
{
    public float speed;
    public float period;
    public Vector2 dir;

    bool movePos;
    float timer;

    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= period)
        {
            dir = -dir;
            timer = 0f;
        }

        transform.Translate(-dir * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character")|| other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Character")||other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}