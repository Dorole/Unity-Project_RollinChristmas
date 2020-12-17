using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : MonoBehaviour
{
    public HealthManager PlayerHealthManager;

    private Slider _healthBarSlider;

    private void Awake()
    {
        _healthBarSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        // pripaziti na izvodenje operacija int i / *
        _healthBarSlider.value = (float) PlayerHealthManager.Health / PlayerHealthManager.StartingHealth;
    }
}
