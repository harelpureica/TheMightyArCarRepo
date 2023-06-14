using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public abstract class PopupBase:MonoBehaviour,IPopup
    {
        #region Fields
    
        [SerializeField]
        protected GameObject uiParent;

        [SerializeField]
        protected RectTransform uiPanel;

        [SerializeField]
        protected float transitionSpeed;

        protected bool isOpen=false;

        protected PopupData data;
        protected PopupsCloseToken closeToken=>data.CloseToken;

        #endregion

        #region Properties
        public GameObject MyGameObject => gameObject;

        public PopupsCloseToken CloseToken => closeToken;

        #endregion

        #region Methods
        public virtual async UniTask Close()
        {
            if (isOpen)
            {
               await CloseRoutine();
                isOpen = false;
            }
        }
        protected virtual async UniTask CloseRoutine()
        {
            var lerp = 1f;
            while (lerp > 0)
            {
                uiPanel.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp -= Time.deltaTime * transitionSpeed;
                await UniTask.Yield();
            }
            uiPanel.localScale = Vector3.zero;
            uiParent.SetActive(false);
            closeToken.IsClosed = true;
        }

        public async virtual UniTask Open()
        {
            if(!isOpen)
            {
                await OpenRoutine();
                isOpen = true;
            }
          
        }
        protected virtual async UniTask OpenRoutine()
        {
            uiParent.SetActive(true);
            var lerp=0f;
            while(lerp<1)
            {
                uiPanel.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp += Time.deltaTime * transitionSpeed;
                await UniTask.Yield();
            }
            uiPanel.localScale=Vector3.one;
        }

        public virtual void SetData(PopupData data)
        {
            this.data = data;
        }

        #endregion
    }
}
