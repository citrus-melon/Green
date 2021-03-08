using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    public Food data;
    public Text nameText;
    public Text categoryText;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = data.name;
        categoryText.text = data.category.ToString();
        image.sprite = data.image;
    }

}