using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Color damageColor;

    private TextMeshPro damageText;

    private void Awake()
    {
        damageText = GetComponent<TextMeshPro>();
        transform.localPosition += offset;
        Destroy(gameObject, destroyTime);
    }

    public void Initialise(int damageValue)
    {
        damageText.text = damageValue.ToString();
    }
}
