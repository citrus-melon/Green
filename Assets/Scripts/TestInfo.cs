using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestInfo : MonoBehaviour
{
    public Food[] foodsList;
    public Text nameText;
    public Text categoryText;
    public Image image;
    public GameObject useBtn;
    private Food selectedFood;
    // Start is called before the first frame update
    void Start()
    {
        LoadFood();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")){
            LoadFood();
        }
    }

    public void LoadFood()
    {
        selectedFood = foodsList[Random.Range(0, foodsList.Length)];
        nameText.text = selectedFood.name;
        categoryText.text = selectedFood.category.ToString();
        image.sprite = selectedFood.image;
        useBtn.SetActive((selectedFood.progression));
    }

    public void LoadRecursion()
    {
        selectedFood=selectedFood.progression;
        nameText.text = selectedFood.name;
        categoryText.text = selectedFood.category.ToString();
        image.sprite = selectedFood.image;
        useBtn.SetActive((selectedFood.progression));
    }
}
