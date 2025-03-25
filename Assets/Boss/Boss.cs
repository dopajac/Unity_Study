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
    
    private Animator BossAnimator;
    // Start is called before the first frame update
    void Start()
    {
        BossHpBar.value = BossHP / BossMaxHP;
        BossAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bosshit(float damege)
    {
        if (!isDead)
        { 
            BossHP -= damege;
            UpdateHpBar();
        
            BossAnimator.SetTrigger("Hit");
        }

        
        if (BossHP <= 0)
        {
            isDead = true;
            BossAnimator.SetTrigger("Dead");
        }
    }

    public void UpdateHpBar()
    {
        BossHpBar.value = BossHP/ BossMaxHP;
    }

    public void BossPattern()
    {
        int patternnumber = Random.Range(1, 5);
        switch (patternnumber)
        {
            case 1:
                BossAnimator.SetTrigger("Scratch");
                break;
            case 2:
                BossAnimator.SetTrigger("Breath");
                break;
            case 3:
                BossAnimator.SetTrigger("UpDown");
                break;
            case 4:
                BossAnimator.SetTrigger("TwoHand");
                break;
        }

    }

}
