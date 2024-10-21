using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{

    public class NewBehaviourScript : MonoBehaviour
    {
        #region Variables
        public TextMeshProUGUI ammoText;
        #endregion
        // Update is called once per frame
        void Update()
        {
            ammoText.text = PlayerStats.Instance.AmmoCount.ToString();
        }
    }

}