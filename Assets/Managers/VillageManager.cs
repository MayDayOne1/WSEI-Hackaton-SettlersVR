using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    [SerializeField] int _villagers = 10;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        _villagers--;

    //        Debug.Log("Villager has died");

    //        Destroy(collision.gameObject);
    //        _textMeshProUGUI.text = $"{_villagers} villagers";
    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _villagers--;

            Debug.Log("Villager has died");

            Destroy(other.gameObject);
            _textMeshProUGUI.text = $"{_villagers} villagers";
        }

        if (other.gameObject.tag == "Creature")
        {
            _villagers++;

            Debug.Log("Villager has joined");

            Destroy(other.gameObject);
            _textMeshProUGUI.text = $"{_villagers} villagers";
        }
    }
}
