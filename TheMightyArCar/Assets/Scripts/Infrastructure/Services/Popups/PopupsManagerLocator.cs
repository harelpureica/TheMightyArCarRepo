using Cysharp.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public static class PopupsManagerLocator 
    {
        public static async UniTask<IPopupsManager> GetPopupsManager()
        {
           
            await SceneManager.LoadSceneAsync("Popups", LoadSceneMode.Additive);
            var service = Object.FindObjectsOfType<MonoBehaviour>().OfType<IPopupsManager>().FirstOrDefault();
           
            return service;

        }
    }
}
