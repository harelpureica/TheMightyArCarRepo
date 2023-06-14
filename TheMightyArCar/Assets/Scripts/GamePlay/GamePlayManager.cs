using UnityEngine;
using Cysharp.Threading.Tasks;
using TheMightyArCar.Infrastructure.Services.Popups;
using System.Collections.Generic;
using TheMightyArCar.Infrastructure.Tracking;
using TheMightyArCar.Data;

namespace TheMightyArCar.GamePlay
{
    public class GamePlayManager:MonoBehaviour
    {
       
        #region Methods

        #region Mono
        private async void Start()
        {
            var popupManager = await PopupsManagerLocator.GetPopupsManager();
            var popup= popupManager.CreatePopup(PopupsEnums.PopupType.Text);
            var closeToken = new PopupsCloseToken();
            popup.SetData(new PopupData(closeToken,new List<object>() {"point your camera towards the gorund and wait for the square indicator to show up ,than press on it to deploy a car  "}));
            await popup.Open();
            while(!closeToken.IsClosed)
            {
                await UniTask.Yield();
            }
            await popupManager.UnloadPopupSceneAsync();
        }
        #endregion

        #endregion

    }
}
