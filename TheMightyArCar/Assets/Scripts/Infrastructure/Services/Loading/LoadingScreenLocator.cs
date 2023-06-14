using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;
using System.Linq;

namespace TheMightyArCar.Infrastructure.Services.Loading
{
    public static class LoadingScreenLocator
    {
        public static async UniTask<ILoadingScreen> GetLoadingScreen()
        {
            await SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive);
            var service = Object.FindObjectsOfType<MonoBehaviour>().OfType<ILoadingScreen>().FirstOrDefault();
            return service;
        }

    }
}
