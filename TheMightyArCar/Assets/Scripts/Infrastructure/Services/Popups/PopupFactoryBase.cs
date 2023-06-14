using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public abstract class PopupFactoryBase:MonoBehaviour,IPopupFactory
    {
        #region Fields
        [SerializeField]
        protected GameObject PopupPrefab;

        public abstract PopupsEnums.PopupType FactoryType { get; }

        #endregion

        #region Methods
        public virtual IPopup CreatePopup()
        {
            var popup=Instantiate(PopupPrefab);
            var popupComponent = popup.GetComponent<IPopup>();
            return popupComponent;
        }
        #endregion
    }
}
