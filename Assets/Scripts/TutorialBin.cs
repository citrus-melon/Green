using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBin : MonoBehaviour
{
    [SerializeField]
    private Tutorial spawner;
    [SerializeField]
    private int key;

    void OnMouseDown() {
        spawner.mousePress = key;
    }
}
