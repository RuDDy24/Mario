using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBarTotal;
    [SerializeField] private Image healthBarCurrent;
    [SerializeField] private Health player;
    void Start()
    {
        healthBarTotal.fillAmount = player.currentHealth/10;
    }

    // Update is called once per frame
    void Update()
    {
        healthBarCurrent.fillAmount = player.currentHealth / 10;
    }
}
