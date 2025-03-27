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

    public GameObject Flame;
    public GameObject Smoke;

    public GameObject BreathBound;
    // Start is called before the first frame update
    void Start()
    {
        BossHpBar.value = BossHP / BossMaxHP;
        BossAnimator = GetComponent<Animator>();
        Flame.SetActive(false);
        Smoke.SetActive(false);
        BreathBound.SetActive(false);

        // 2초 뒤부터 3초마다 BossPattern 호출
        InvokeRepeating("BossPattern", 2.0f, 5.0f);
        Flame.SetActive(false);
        Smoke.SetActive(false);
        BreathBound.SetActive(false);
        
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

        if (BossHP <= 0 && !isDead)
        {
            isDead = true;
            BossAnimator.SetTrigger("Dead");

            // 패턴 멈춤
            CancelInvoke("BossPattern");
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
                Flame.SetActive(true);
                Smoke.SetActive(true);
                StartCoroutine(ActivateBreathBound(1.0f));
                StartCoroutine(EndBreathRoutine(5.0f));
                break;
            case 3:
                BossAnimator.SetTrigger("UpDown");
                break;
            case 4:
                BossAnimator.SetTrigger("TwoHand");
                break;
        }

       
    }
    private IEnumerator EndBreathRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Flame.SetActive(false);
        Smoke.SetActive(false);
        BreathBound.SetActive(false);
    }
    private IEnumerator ActivateBreathBound(float delay)
    {
        yield return new WaitForSeconds(delay);
        BreathBound.SetActive(true);
    }
}
