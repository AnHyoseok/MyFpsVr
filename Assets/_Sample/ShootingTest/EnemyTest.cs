using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFps;

namespace MySample
{

    public class EnemyTest : MonoBehaviour,IDamageable
    {
        #region Variables
        //체력
        [SerializeField] private float maxHealth = 20;
        private float currentHealth;
        private Color Color;
        //
        private bool isDeath = false;

        #endregion

        // Start is called before the first frame update
        void Start()
        {
            currentHealth = maxHealth;
            
        }

     
        public void TakeDamage(float damage)
        {
            currentHealth -= damage; ;
           
            Debug.Log($"{this.name} 체력 {currentHealth}");


            //데미지 효과, 

            if (currentHealth <= 0 && !isDeath)
            {
                //다이
                Die();
          
            }
        }

        //죽음처리
        void Die()
        {
            isDeath = true;
           
            //보상 - 경험치 ,돈

            //효과 

            //죽음처리
            Destroy(gameObject, 3f);
        }
    }

}