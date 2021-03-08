using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField]
    private FoodSpawner spawner;
    [SerializeField]
    private int key;

    void OnMouseDown() {
        spawner.mousePress = key;
    }
}
