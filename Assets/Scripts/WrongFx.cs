using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrongFx : MonoBehaviour
{
    public Category cat;
    [SerializeField] Image render;
    [SerializeField] Canvas canvas;
    [SerializeField] Sprite compostImg;
    [SerializeField] Sprite donateImg;
    [SerializeField] Sprite landfillImg;
    [SerializeField] Sprite liquidImg;
    [SerializeField] Sprite recycleImg;
    // Start is called before the first frame update
    void Start()
    {
        switch (cat)
        {
            case Category.compost:
                render.sprite = compostImg;
            break;

            case Category.donate:
                render.sprite = donateImg;
            break;

            case Category.landfill:
                render.sprite = landfillImg;
            break;

            case Category.liquid:
                render.sprite = liquidImg;
            break;

            case Category.recycle:
                render.sprite = recycleImg;
            break;
        }

        if (transform.position.y > 6) {
            canvas.transform.rotation = Quaternion.Euler(0, 0, 180);
            render.transform.rotation = Quaternion.identity;
            canvas.transform.localPosition = new Vector3(0, -5, 0);
        }
    }
}
