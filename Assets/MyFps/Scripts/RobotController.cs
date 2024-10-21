using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    //로봇 상태 
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }

    //로봇 Enemy 관리 클래스
    public class RobotController : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject thePlayer;
        private Animator animator;
       

        //로봇 현재 상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        //
        private bool isDeath;

        //이동
        [SerializeField] private float moveSpeed = 2f;

        //공격
        [SerializeField] private float attackRange = 1.5f; //공격범위
        [SerializeField] private float attackDamage = 5f;  //공격 데미지
        [SerializeField] private float attackTimer = 2f; //공속
        float countdown = 0f;

        //배경음
        public AudioSource bgm01;   //메인씬 1 배경음
        public AudioSource bgm02;   //적 등장 배경사운드
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //참조
            animator = GetComponent<Animator>();
            //초기화
            isDeath = false;
            currentHealth = maxHealth;
            countdown = attackTimer;
            SetState(RobotState.R_Idle);

            
        }

        private void Update()
        {
            if(isDeath)
            {
                return;
            }

            //타겟지정
            Vector3 dir = thePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);

            if (distance <= attackRange)
            {
                SetState(RobotState.R_Attack);
            }
       

            //로봇 상태 구현
            switch (currentState)
            {
                case RobotState.R_Idle:
                    break;
                case RobotState.R_Walk: //플레이어를 향해 걷는다
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                    transform.LookAt(thePlayer.transform);
                    break;
                case RobotState.R_Attack:
                    if (distance > attackRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    break;
                case RobotState.R_Death:
                    break;
            }
        }

        //2초마다 공격
        //private void AttackOnTimer()
        //{
        //    if(countdown < 0f)
        //    {
        //        //공격
        //        Attack();
        //        countdown = attackTimer;
        //    }
        //    countdown -= Time.deltaTime;
        //}

        private void Attack()
        {
            PlayerController playerController = thePlayer.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(attackDamage);
            }
            Debug.Log("플레이어에게 데미지를 준다");
        }

        //로봇의 상태 변경
        public void SetState(RobotState newState)
        {   //현재상태 체크
            if (currentState == newState)
                return;

            //이전상태 저장
            beforeState = newState;

            //상태 변경
            currentState = newState;

            //상태 변경에 따른 구현 내용
            animator.SetInteger("RobotState", (int)newState);
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= damage; ;

            Debug.Log($"로봇 체력 {currentHealth}");
            if (currentHealth <= 0 && !isDeath)
            {
                Die();
            }
        }

        private void Die()
        {
            isDeath = true;
            Debug.Log("Robot Death!");

            SetState(RobotState.R_Death);

            //배경음 변경
            bgm02.Stop();
            bgm01.Play();
        
            //충돌체 꺼지기
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

}