using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private FoodController foodPrefab;
    [SerializeField]
    private Vector3 spawnPosition;
    [SerializeField]
    private Food[] foodsList;
    private Queue queue = new Queue();
    private FoodController next;
    private FoodController recursion;
    public int mousePress = 0;
    public float delay = 3;
    public float speedIncrement = 2;
    public float difficultyIncrement = 0.1f;
    public float difficultyInterveral = 20;
    public float difficultyCutoff = 0.1f;
    public float startSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        FoodController.speed = startSpeed;
        Spawn();
        InvokeRepeating("Difficulty", difficultyInterveral, difficultyInterveral);
    }

    // Update is called once per frame
    void Update()
    {
        if (!recursion && queue.Count == 0) return;
        FoodController f = null;
        if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift") || Input.GetKeyDown("left") || Input.GetKeyDown("right") || Input.GetKeyDown("up") || Input.GetKeyDown("down") || next.transform.position.x > 13 || mousePress != 0) {
            if (!recursion) {

                f = (FoodController) queue.Dequeue();
                if (f.data.progression) {
                    recursion = Instantiate(foodPrefab, f.transform.position, Quaternion.identity);
                    recursion.data = f.data.progression;
                    next = recursion;
                } else if (queue.Count > 0) {next = (FoodController) queue.Peek();}

            } else {

                f = recursion;
                recursion = null;
                if (queue.Count > 0) {next = (FoodController) queue.Peek();}

            }

            if (Input.GetKeyDown("left") || mousePress == 1){ //recycle
                f.Select(Category.recycle);
                
            }
            else if (Input.GetKeyDown("up") || mousePress == 2){ //liquid
                f.Select(Category.liquid);
            }
            else if (Input.GetKeyDown("down") || mousePress == 3){ //Compost
                f.Select(Category.compost);
            }
            else if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift") || mousePress == 5){ //Compost
                f.Select(Category.donate);
            }
            else { //landfill
                f.Select(Category.landfill);
            }
            mousePress = 0;
        }
    }

    void Spawn()
    {
        FoodController f = Instantiate(foodPrefab, spawnPosition, Quaternion.identity);
        f.data = foodsList[Random.Range(0, foodsList.Length)];
        queue.Enqueue(f);
        if (queue.Count == 1) next = f;

        Invoke("Spawn", delay);
    }

    void Difficulty() {
        delay -= difficultyIncrement;
        FoodController.speed += speedIncrement;
        if (delay <= difficultyCutoff) CancelInvoke("Difficulty");
    }
}
