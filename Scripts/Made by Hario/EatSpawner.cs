using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatSpawner : MonoBehaviour
{
    public GameObject eatPrefab;
    public int numberToSpawn = 2;
    public Vector2 maxPos;
    public Vector2 minPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEatablePrefabs());
    }

    IEnumerator SpawnEatablePrefabs()
    {
        for(int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(eatPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), transform.position.z), Quaternion.identity);
        }
        numberToSpawn = 0;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(SpawnEatablePrefabs());
    }
}
