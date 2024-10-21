using MyFps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCellExit : Interactive
{
    #region Variables
    public SceneFader fader;
    [SerializeField] private string loadToScene = "MainScene02";
    private Collider m_Collider;
    private Animator animator;
    public AudioSource creakyDoor;
    public AudioSource bgm01;

    #endregion

    private void Start()
    {
        //참조
        animator = GetComponent<Animator>();
        m_Collider= GetComponent<Collider>();
    }

    protected override void DoAction()
    {
        //문이 열리는 액션
        animator.SetBool("IsOpen", true);
        m_Collider.enabled = false;
        //문 여는 사운드
        creakyDoor.Play();

        ChangeScean();
    }
    void ChangeScean()
    {
        //3초있다가 (문열리는시간있다가
        fader.FadeTo(loadToScene);
    }

  
}
