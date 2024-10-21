using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

namespace MyFps
{

    public class PauseUI : MonoBehaviour
    {
        #region Variables

        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";
        public GameObject pauseUI;

        public GameObject thePlayer;
        #endregion

        private void Start()
        {
            //참조
            thePlayer = GameObject.Find("Player");
        }

        private void Update()
        {
            //ESC 입력시 
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                Toggle();
            }
        }
        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf) //pause 창이 오픈 되었을때
            {
                Time.timeScale = 0f;
                thePlayer.GetComponent<FirstPersonController>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else //pause 창이 클로즈 되었을때
            {
                Time.timeScale = 1f;
                thePlayer.GetComponent<FirstPersonController>().enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        public void Menu()
        {
            Time.timeScale = 1f;
            Debug.Log("메뉴이동");  
        }

        public void Restart()
        {
            Time.timeScale = 1f;
            fader.FadeTo(loadToScene);
            Debug.Log("리트라이");
        }
    }

}