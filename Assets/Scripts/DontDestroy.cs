using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    void Awake() {
        if (GameObject.FindGameObjectsWithTag("Music").Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
