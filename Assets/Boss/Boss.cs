using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public float BossHP = 10;
    private float BossMaxHP = 10;
    public Slider BossHpBar;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        BossHpBar.value = BossHP / BossMaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bosshit(float damege)
    {
        BossHP -= damege;
        UpdateHpBar();
    }

    public void UpdateHpBar()
    {
        BossHpBar.value = BossHP/ BossMaxHP;
    }

}
