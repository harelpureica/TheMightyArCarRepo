using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public class TextPopup:PopupBase
    {
        #region Fields
        [SerializeField]
        private TextMeshProUGUI _text;

        [SerializeField]
        private Button closeBtn;
        #endregion

        #region Methods
        private   void Start()
        {
            closeBtn.onClick.AddListener(OnCloseClick);
            closeBtn.interactable = true;
        }
        public override void SetData(PopupData popupData)
        {
           this.data = popupData;
           var stringData = (string)popupData.Data[0];
            if (string.IsNullOrEmpty(stringData))
            {
                Debug.Log("[TextPopup]eror popupData is null or empty");
                return;
            }
            _text.text = stringData;
        }
        public async void OnCloseClick()
        {
            closeBtn.interactable = false;
            await Close();

        }
        protected override async UniTask CloseRoutine()
        {
            var lerp = 1f;
            while (lerp > 0)
            {
                uiPanel.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp -= Time.deltaTime * transitionSpeed;
                await UniTask.Yield();
            }
            closeToken.IsClosed = true;
            Destroy(gameObject);
        }
        #endregion
    }
}
