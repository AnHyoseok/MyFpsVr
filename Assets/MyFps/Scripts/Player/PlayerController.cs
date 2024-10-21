using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    #region Variables

    #endregion
    public class PlayerController : MonoBehaviour
    {
        #region
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOverScene";
        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;

        private bool isDeath;

        //데미지 효과
        public GameObject damageFlash; //데미지 플래쉬 효과
        public AudioSource[] hurts;

      

        #endregion

        void Start()
        {
            //초기화
            currentHealth = maxHealth;
        }
        public void TakeDamage(float damage)
        {
            currentHealth -= damage; ;
            StartCoroutine(DamageEffect());

            Debug.Log($"플레이어 체력 {currentHealth}");
            if (currentHealth <= 0 && !isDeath)
            {
                //다이
                Die();

            }
        }

        private void Die()
        {
            isDeath = true;
            Debug.Log($"GameOver!!");
            fader.FadeTo(loadToScene);
        }

        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(0, 2);
            hurts[randNumber].Play();
            yield return new WaitForSeconds(1f);

            damageFlash.SetActive(false);
        }

    }


}