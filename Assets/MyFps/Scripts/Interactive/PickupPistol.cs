using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{

    public class PickupPistol : Interactive
    {
        #region Variables

        
 
        //action
        public GameObject realPistol;
        public GameObject Arrow;
        public GameObject enemyTrigger;
        public GameObject ammoUI;
        public GameObject ammoBox;
       
        #endregion

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            ammoUI.SetActive(true);
            Arrow.SetActive(false);
           ammoBox.SetActive(true);

            PlayerStats.Instance.AmmoCount = 0;
           
            enemyTrigger.SetActive(true);
            
            Destroy(gameObject);
        }

     
    }

}

