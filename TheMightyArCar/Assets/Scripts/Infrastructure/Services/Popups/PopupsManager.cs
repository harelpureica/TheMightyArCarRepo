using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public class PopupsManager : MonoBehaviour, IPopupsManager
    {
        #region Fields
        [SerializeField]
        private List<GameObject> factoryObjs;

        private List<IPopupFactory> factorys;
        #endregion

        #region Methods
        private void Awake()
        {
            factorys = new List<IPopupFactory>();
            foreach (var factoryObj in factoryObjs)
            {
                if (factoryObj.TryGetComponent<IPopupFactory>(out IPopupFactory popupFactoryComponent))
                {
                    factorys.Add(popupFactoryComponent);
                }
            }
        }
        public IPopup CreatePopup(PopupsEnums.PopupType popupType)
        {
            foreach (var factory in factorys)
            {
                if(factory.FactoryType==popupType)
                {
                   return factory.CreatePopup();
                }
            }
            return null;
        }
       
        public async  UniTask UnloadPopupSceneAsync()
        {
            await SceneManager.UnloadSceneAsync("Popups");
           
        }
        #endregion
    }
}
