using MyFps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace MyFps
{
    public class PickupAmmoBox : Interactive
    {
        #region Variables
        //action

        public GameObject Ammobox;

        public GameObject ammoBoxArrow;
        [SerializeField] private int giveAmmo = 7;
        #endregion


        protected override void DoAction()
        {
            //탄환 지급 : 7개
            PlayerStats.Instance.AddAmmo(giveAmmo);
       
            Destroy(gameObject);
        }

    }
}