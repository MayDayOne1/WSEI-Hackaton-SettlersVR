using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleAddFood : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Planet")
            return;

        FoodManager.instance.addFood();
    }
}
