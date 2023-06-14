using Cysharp.Threading.Tasks;
using TheMightyArCar.Infrastructure.Services.Loading;
using UnityEngine.SceneManagement;

public class FromStartScreenToGameFlow 
{
    public  void StartFlow()
    {
        FlowRoutine();
    }
    private async void FlowRoutine()
    {
        var loadingScreen = await LoadingScreenLocator.GetLoadingScreen();
        await loadingScreen.FadeIn();
        loadingScreen.UpdateProgress(0f);
        await UniTask.Delay(200);
        await SceneManager.UnloadSceneAsync("Start");
        loadingScreen.UpdateProgress(0.2f);
        await UniTask.Delay(200);
        loadingScreen.UpdateProgress(0.4f);
        await UniTask.Delay(200);
        loadingScreen.UpdateProgress(0.6f);
        await UniTask.Delay(200);
        loadingScreen.UpdateProgress(0.8f);
        await UniTask.Delay(200);
        loadingScreen.UpdateProgress(1f);
        await SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        await UniTask.Delay(200);
        await loadingScreen.UnloadLoadingSceneAsync();
    }
}
