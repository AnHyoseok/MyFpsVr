using MyFps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{


    //인터렉티브 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        protected float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";
        public GameObject extraCross;

        #endregion


        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        //마우스를 가져가면 액션 UI를 보여준다
        protected void OnMouseOver()
        {
            //거리가 2이하 일때
            if (theDistance <= 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();
                    //ACtion
                    DoAction();


                }
            }
            else
            {
                HideActionUI();
            }
        }


        //마우스가 벗어나면 액션 UI를 감춘다
        protected void OnMouseExit()
        {
            HideActionUI();
        }

        protected virtual void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }


        protected virtual void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }

    }

}
