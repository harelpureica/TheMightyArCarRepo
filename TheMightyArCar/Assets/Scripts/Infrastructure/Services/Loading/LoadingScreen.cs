using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TheMightyArCar.Infrastructure.Services.Loading
{
    public class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        #region Fields
        [SerializeField]
        private RectTransform UIpanelRectTransform;

        [SerializeField]
        private GameObject UIparent;

        [SerializeField]
        private Slider loadingSlider;

        [SerializeField]
        private float fadeSpeed;
        #endregion

        #region Methods


        public async UniTask FadeIn()
        {
            if (UIpanelRectTransform != null)
            {
                UIpanelRectTransform.localScale = Vector3.zero;
            }

            if (UIparent != null)
            {
                UIparent.SetActive(true);
            }

            var lerp = 0f;
            while (lerp < 1)
            {
                if (UIpanelRectTransform == null)
                {
                    return;
                }
                UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp += Time.deltaTime * fadeSpeed;
                await UniTask.Yield();
            }
            UIpanelRectTransform.localScale = Vector3.one;
        }

        public async UniTask FadeOut()
        {
            var lerp = 1f;
            while (lerp > 0)
            {
                if (UIpanelRectTransform == null)
                {
                    return;
                }
                UIpanelRectTransform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
                lerp -= Time.deltaTime * fadeSpeed;
                await UniTask.Yield();
            }
            if (UIparent != null)
            {
                UIparent.SetActive(false);
            }
            UIpanelRectTransform.localScale = Vector3.zero;
            
        }

        public void UpdateProgress(float progress)
        {
            loadingSlider.value = progress;
        }
        public async UniTask UnloadLoadingSceneAsync()
        {
            await SceneManager.UnloadSceneAsync("Loading");
           
        }
        #endregion
    }
}
