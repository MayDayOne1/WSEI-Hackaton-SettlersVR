using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject prefab;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 randomSpawnPosition = new Vector3( Random.Range(-15,15), Random.Range(-15,15), Random.Range(-15,15));
            Instantiate(prefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
