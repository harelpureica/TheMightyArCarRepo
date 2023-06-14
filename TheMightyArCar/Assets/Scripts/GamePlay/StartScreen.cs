using System;
using UnityEngine;
using UnityEngine.UI;

namespace TheMightyArCar.GamePlay
{
    public class StartScreen:MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Button StartBtn;
        #endregion

        #region Methods
        #region Mono
        private void Start()
        {
            StartBtn.onClick.AddListener(OnStartClick);
        }
        #endregion

        public void OnStartClick()
        {
            StartBtn.interactable = false;
            var flow = new FromStartScreenToGameFlow();
            flow.StartFlow();
        }
        #endregion
    }
}
