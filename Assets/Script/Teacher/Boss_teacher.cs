using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Boss_teacher : MonoBehaviour
{
    
    // 상태 패턴의 핵심조건
    // 상태를 관리하는 주체 필요 , 주체는 행동 x 
    
    static readonly int SCRATH = Animator.StringToHash("Scratch");
    static readonly int BREATH = Animator.StringToHash("Breath");
    // 상태 이벤트 정보를 만들어서 상태의 특정 시점을 지날 시 이벤트 발생
    // 특정시점이면 state의 isname, nomalizedtime 을 이용하여 이벤트 실행

    [Serializable]
    public class StateEventInfo
    {
        
        /// <summary>
        /// 이벤트가 등록될 animator의 상태이름
        /// </summary>
        public string TargetStateName;

        public BossStateEvent EventType;
        /// <summary>
        /// 이벤트를 발생시킬 시간
        /// </summary>
        public float EventTime;
    }
    public enum  BossStateEvent
    {
        OnIdleEnter,
        OnIdleExit,
        OnBreathEnter,
        OnBreathExit,
        OnScratchEnter,
        OnScrachExit
            
    }
    
    public StateEventInfo[] EventInfo;
    
    public List<StateEventInfo> EventInfoList { get; private set; }

    public Animator animator { get; set; }
    private AnimatorStateInfo previousState;
    private readonly int[] bossAttacks = { SCRATH, BREATH };

    public GameObject BreathObject;
    public Collider Breath;
    
    public Collider scratch;
    private void Awake()
    {
        EventInfoList = new List<StateEventInfo>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        if (previousState.shortNameHash != currentState.shortNameHash)
        {
            for (int i = 0; i < EventInfo.Length; i++)
            {
                if (currentState.IsName(EventInfo[i].TargetStateName))
                {
                    EventInfoList.Add(EventInfo[i]);
                }
            }
        }

        for (int i =EventInfoList.Count-1  ; i >= 0; i--)
        {
            if (EventInfoList[i].EventTime < currentState.normalizedTime)
            {
                HandleEvent(EventInfoList[i]);
                Debug.Log($"{EventInfoList[i].EventType}");
                EventInfoList.RemoveAt(i);
            }
        }

        previousState = currentState;
    }

    private void HandleEvent(StateEventInfo eventInfo)
    {
        switch(eventInfo.EventType)
        {
            case BossStateEvent.OnIdleEnter:
                int nextAttackTrigger = bossAttacks[Random.Range(0, bossAttacks.Length)];
                break;
            case BossStateEvent.OnIdleExit:
                break;
            case BossStateEvent.OnBreathEnter:
                animator.SetTrigger("Breath");
                
                break;
            case BossStateEvent.OnBreathExit:
                break;
            case BossStateEvent.OnScratchEnter:
                animator.SetTrigger("Scratch");
                break;
            case BossStateEvent.OnScrachExit:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
