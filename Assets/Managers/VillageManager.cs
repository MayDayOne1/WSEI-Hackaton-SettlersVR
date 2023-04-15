using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    [SerializeField] int _villagers = 10;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _villagers--;

            Debug.Log("Villager has died");

            Destroy(other.gameObject);
            _textMeshProUGUI.text = $"{_villagers} villagers";
        }

    }
}
