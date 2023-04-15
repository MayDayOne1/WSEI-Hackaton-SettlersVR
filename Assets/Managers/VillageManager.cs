using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VillageManager : MonoBehaviour
{
    public event Action onAllVillagersLost;

    [SerializeField] int _villagers = 10;
    [SerializeField] TextMeshProUGUI _textMeshProUGUI;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            _villagers--;

            Debug.Log("Villager has died");

            other.GetComponent<Tatakae>().OnMonsterDie();
            //Destroy(other.gameObject);
            _textMeshProUGUI.text = $"{_villagers} villagers";
        }

        if (other.gameObject.tag == "Creature")
        {
            _villagers++;

            Debug.Log("Villager has joined");

            Destroy(other.gameObject);
            _textMeshProUGUI.text = $"{_villagers} villagers";
        }

        if (_villagers < 1)
        {
            onAllVillagersLost?.Invoke();
            _textMeshProUGUI.color = Color.red;
            _textMeshProUGUI.text = "Game over!";
        }
    }
}
