using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBlendTest : MonoBehaviour
{
    #region
    private Animator animator;
    [SerializeField] private float moveSpeed = 5f;
    //입력값
    private float moveX;
    private float moveY;
    #endregion
    void Start()
    {
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        //앞뒤 좌우 입력 처리
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        //이동, 방향 ,속도
        Vector3 dir = new Vector3(moveX, 0, moveY);

        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        //AnimatorStateTest();
        AnimationBlendTest();
    }
    void AnimatorStateTest()
    {
        if (moveY == 0f && moveX == 0f)
        {
            animator.SetInteger("MoveState", 0); //대기
        }
        if (moveY > 0f)
        {
            animator.SetInteger("MoveState", 1); //앞
        }
        if (moveY < 0f)
        {
            animator.SetInteger("MoveState", 2);//뒤
        }
        if (moveX < 0f)
        {
            animator.SetInteger("MoveState", 3);//좌
        }
        if (moveX > 0f)
        {
            animator.SetInteger("MoveState", 4);//우
        }
    }

    void AnimationBlendTest()
    {
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);
    }
}
