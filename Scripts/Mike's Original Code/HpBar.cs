
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : MonoBehaviour
{
    private Image hpBar;
    public float maxHp;
    public float hp;

    private void Start()
    {
        hpBar = GetComponent<Image>();
        hp = maxHp;
    }
    private void Update()
    {
        hpBar.fillAmount = hp / maxHp;
    }
}
