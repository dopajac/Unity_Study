using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerCharactor : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public AnimatorOverrideController Replaceanimator;
    public float Speed;
    public float doubleSpeed;
    public GameObject Sward;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Speed = animator.GetFloat("Speed");
        doubleSpeed = animator.GetFloat("Speed") * 3;
        Move();
        UpdateAttackInput();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.runtimeAnimatorController = Replaceanimator;
        }
    }

    private void UpdateAttackInput()
    {
        if (animator.IsInTransition(0)) return;
        // 목표 : 3콤보 주먹질
        var currentAnimstateInfo = animator.GetCurrentAnimatorStateInfo(0);

        bool isAttack1 = currentAnimstateInfo.IsName("Attack1");
        bool isAttack2 = currentAnimstateInfo.IsName("Attack2");
        bool isAttack3 = currentAnimstateInfo.IsName("Attack3");
        bool isAttacking = isAttack1 || isAttack2 || isAttack3 ;

        bool inputAttack = Input.GetKeyDown((KeyCode.Mouse0));
        
        if (inputAttack && isAttack3 == false)
        {
            
            float normalizedTime = currentAnimstateInfo.normalizedTime;
            if (isAttacking == false)
            {
                animator.ResetTrigger("Attack");
                animator.SetTrigger("Attack");
            }
            else if (0.4f < normalizedTime && normalizedTime <= 0.85f) //두번째 이후부터 공격 
            {
                animator.ResetTrigger("Attack");
                animator.SetTrigger("Attack");
            }
            
        }
    }


    private void Move()
    {
        Vector2  axisInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        animator.SetFloat("MoveX", axisInput.x);
        animator.SetFloat("MoveY", axisInput.y);
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(new Vector3(axisInput.x,0.0f,axisInput.y) * doubleSpeed* Time.deltaTime);
            return;
        }
    
        transform.Translate(new Vector3(axisInput.x,0.0f,axisInput.y) * Speed* Time.deltaTime);

    }

    
}
