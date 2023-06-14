using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public interface IPopupsManager
    {
       IPopup CreatePopup(PopupsEnums.PopupType popupType);

        UniTask UnloadPopupSceneAsync();

    }
}
