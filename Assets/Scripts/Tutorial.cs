using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject[] popups;
    [SerializeField] private FoodController apple;
    [SerializeField] private FoodController appleSauce;
    [SerializeField] private FoodController appleSauce2;
    [SerializeField] private FoodController bannana;
    [SerializeField] private GameObject bins;
    [SerializeField] private GameObject score;
    private int currentStep = 0;
    public int mousePress = 0;
    void Start()
    {
        FoodController.speed = 2;
    }

    void Update() {
        if (currentStep == 1) {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
            NextPopup();
            apple.gameObject.SetActive(true);
            bins.SetActive(true);
            }
        }
        else if (currentStep == 2) {
            if (Input.GetKeyDown(KeyCode.DownArrow) || mousePress == 2) {
                NextPopup();
                apple.Select(Category.compost);
            }
            if (apple.transform.position.x > 0) FoodController.speed = 0;
        }
        else if (currentStep == 4) {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
            NextPopup();
            mousePress = 0;
            FoodController.speed = 2;
            appleSauce.gameObject.SetActive(true);
            }
        }
        else if (currentStep == 5) {
            if (appleSauce.transform.position.x > 0) FoodController.speed = 0;
            if (Input.GetKeyDown(KeyCode.DownArrow) || mousePress == 2) {
                currentStep = 55;
                appleSauce.Select(Category.compost);
                appleSauce2.gameObject.SetActive(true);
                appleSauce2.transform.position = appleSauce.transform.position;
                mousePress = 0;
                FoodController.speed = 2;
            }
        }
        else if (currentStep == 55) {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || mousePress == 1) {
                currentStep = 5;
                NextPopup();
                appleSauce2.Select(Category.recycle);
            }
            if (appleSauce2.transform.position.x > 0) FoodController.speed = 0;
        }
        else if (currentStep == 6) {
            if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
                NextPopup();
                bannana.gameObject.SetActive(true);
                FoodController.speed = 5;
            }
        }
        else if (currentStep == 7) {
            if (bannana.transform.position.x > 13) {
                bannana.Select(Category.landfill);
                NextPopup();
                score.SetActive(true);
            }
        }
        else if (currentStep == 10) return;
        else if (Input.anyKeyDown || Input.GetMouseButtonDown(0)) {
            NextPopup();
        }
    }

    void NextPopup() {
        popups[currentStep].SetActive(false);
        popups[++currentStep].SetActive(true);
    }
}
