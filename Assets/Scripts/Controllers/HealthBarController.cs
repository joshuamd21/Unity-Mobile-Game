using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthBarController : MonoBehaviour
{
    private Slider healthbar;
    private TextMeshProUGUI healthText;
    [SerializeField]
    private Gradient healthColor;
    private Image fill;
    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        fill = transform.GetComponentInChildren<Image>();
        healthbar = GetComponent<Slider>();
        healthText = transform.GetComponentInChildren<TextMeshProUGUI>();
    }
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
    public void setTarget(Transform t, Vector3 offset)
    {
        this.target = t;
        this.offset = offset;
    }
    public void setMaxHealth(float maxHealth)
    {
        healthbar.maxValue = maxHealth;
    }
    public void setHealth(float health)
    {
        healthbar.value = health;
        healthText.text = healthbar.value + "/" + healthbar.maxValue;
        fill.color = healthColor.Evaluate(healthbar.normalizedValue);
    }
}
