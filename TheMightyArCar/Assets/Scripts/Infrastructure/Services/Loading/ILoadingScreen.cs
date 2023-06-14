using Cysharp.Threading.Tasks;

namespace TheMightyArCar.Infrastructure.Services.Loading
{
    public interface ILoadingScreen
    {
        UniTask UnloadLoadingSceneAsync();
        void UpdateProgress(float progress);

        UniTask FadeIn();

        UniTask FadeOut();

    }
}
