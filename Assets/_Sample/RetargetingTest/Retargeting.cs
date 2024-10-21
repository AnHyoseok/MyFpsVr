using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// w 키 누르고 있으면 이동 애니메이션, 떼면 대기 동작
//스페이스바 누르면 점프 애니메이션
namespace MySample
{

    public class Retargeting : MonoBehaviour
    {
        Animator animator;

        private bool isMove;
        public bool IsMove
        {

            get { return isMove; }
            set { isMove = value; }
        }


        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Jump();
        }

        public void Move()
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("IsMove", true);

            }
            else
            {
                animator.SetBool("IsMove", false);
            }
        }

        public void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Jump");
            }
            else
            {

            }
        }

    }
}