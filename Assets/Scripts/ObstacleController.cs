using UnityEngine;
using System.Collections;
using System.Linq;

public class ObstacleController: MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            //Sprite frontSprite = Resources.Load("../Characters/MainPlot_SideChar_6", typeof(Sprite)) as Sprite;
            Sprite [] spr = UnityEditor.AssetDatabase.LoadAllAssetsAtPath("Assets/Characters/MainPlot_SideChar.png").OfType<Sprite>().ToArray();
            if (spr==null) Debug.Log("spr is null");

            //Sprite spr2 = other.GetComponent<SpriteRenderer>().sprite;
            //if (spr2==null) Debug.Log("spr2 is null");
            other.GetComponent<SpriteRenderer>().sprite = spr[6];

        }
    }

}