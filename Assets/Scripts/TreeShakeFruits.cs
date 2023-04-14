using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class TreeShakeFruits : MonoBehaviour
{
    public Transform[] fruitSpawnerPoints;
    public GameObject fruitPrefab;
    public float speedTreshold;
    public Rigidbody rb;
    public int fruitCount;
    public List<GameObject> gfxFruits;

    public bool temp;
    private int startingFruitNum;

    private void Start()
    {
        startingFruitNum = fruitCount;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Village")
            return;

        if (rb.velocity.magnitude > speedTreshold)
        {
            SpawnFruit();
        }
    }

    private void SpawnFruit()
    {
        if (fruitCount <= 0)
            return;

        Instantiate(fruitPrefab, fruitSpawnerPoints[0].transform.position, fruitSpawnerPoints[0].transform.rotation);
        fruitCount--;
        DropGFXApples();
    }

    private void DropGFXApples()
    {
        if(fruitCount % (startingFruitNum / 5) == 0)
        {
            Destroy(gfxFruits.First());
            gfxFruits.RemoveAt(0);
        }
    }

}
