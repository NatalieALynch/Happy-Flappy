using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePool : MonoBehaviour
{

    public int columPoolSize = 5;
    private GameObject [] Columns;
    public GameObject columnPrefab;
    private Vector2 position = new Vector2(-15,-25);
    private float time;
    public float spawnRate = 4f;
    public float min = -1f;
    public float max = 3.5f;
    private float spawnX = 10f;
    private int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        Columns = new GameObject[columPoolSize];
        for(int i = 0; i < columPoolSize; i++)
        {
            Columns[i] = (GameObject) Instantiate(columnPrefab, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if(!GameControl.instance.gameOver && time >= spawnRate)
        {
            time = 0;
            float spawnYPos = Random.Range(min, max);
            Columns[current].transform.position = new Vector2(spawnX, spawnYPos);
            current++;
            if(current >= columPoolSize)
            {
                current = 0;
            }
        }
    }
}
