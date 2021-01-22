using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] points;
    private float timeBtwnSpawn;
    public float startTimeBtwnSpawn;
    public float dercTime;
    public float minTime;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        int ene = Random.Range(0, enemy.Length);
        int po = Random.Range(0, points.Length);
        

        if (timeBtwnSpawn <= 0)
        {
            Instantiate(enemy[ene], points[po].position, Quaternion.identity);
            timeBtwnSpawn = startTimeBtwnSpawn;
            if (startTimeBtwnSpawn > minTime)
            {
                startTimeBtwnSpawn -= dercTime;
            }
        }
        else
        {
            timeBtwnSpawn -= Time.deltaTime;
        }
    }
}
