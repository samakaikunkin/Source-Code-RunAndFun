using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _healthSlider;
    public Gradient gradient;
    public Image HealFill;

    private void Start() {
        _healthSlider = GetComponent<Slider>();
    }

    public void SetMaxHealth(float maxHealth)
    {
        _healthSlider.maxValue = maxHealth;
        _healthSlider.value = maxHealth;

        HealFill.color = NewMethod();
    }

    private Color NewMethod()
    {
        return gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        _healthSlider.value = health;

        HealFill.color = NewMethod1();
    }

    private Color NewMethod1()
    {
        return gradient.Evaluate(_healthSlider.normalizedValue);
    }
}
