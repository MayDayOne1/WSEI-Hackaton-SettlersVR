using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitInstances : MonoBehaviour
{
    public float lifeTime;


    // Update is called once per frame
    void Update()
    {
        if (lifeTime < 0)
            Destroy(gameObject);
        else
            lifeTime -= Time.deltaTime;
    }
}
