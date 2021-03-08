using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Animator anim;
    public void Activate(string scene)
    {
        anim.SetTrigger("In");
        StartCoroutine(LoadScene(scene));
    }

    IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
