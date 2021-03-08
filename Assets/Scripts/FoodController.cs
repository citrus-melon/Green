using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public Food data;
    private Category answer;
    private bool answered = false;
    private Vector3 destination;
    [SerializeField]
    private GameObject correctFX;
    [SerializeField]
    private WrongFx wrongFX;
    public static float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = data.image;
    }

    // Update is called once per frame
    void Update()
    {
        if (answered) {
            if (transform.position == destination) {
                if (answer == data.category) {
                    ScoreKeeper.score++;
                    Instantiate(correctFX, transform.position, Quaternion.identity);
                } else {
                    WrongFx f = Instantiate(wrongFX, transform.position, Quaternion.identity);
                    f.cat = data.category;
                    ScoreKeeper.lives--;
                }
                Destroy(gameObject);
            }
            transform.position = Vector2.MoveTowards(transform.position, destination, 30 * Time.deltaTime);
        } else {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void Select(Category a)
    {
        answered = true;
        answer = a;
        switch (answer)
        {
            case Category.recycle:
                destination = new Vector3(-13, -6.5f);
                break;
            case Category.liquid:
                destination = new Vector3(0, 7);
                break;
            case Category.compost:
                destination = new Vector3(0, -6.5f);
                break;
            case Category.landfill:
                destination = new Vector3(13, -6.5f);
                break;
            case Category.donate:
                destination = new Vector3(6, -6.5f);
                break;
        }
    }
}
