using Cysharp.Threading.Tasks;
using UnityEngine;
namespace TheMightyArCar.Infrastructure.Services.Popups
{
    public interface IPopup
    {
        public GameObject MyGameObject { get; }
       UniTask Open();

        UniTask Close();

        void SetData(PopupData data);


    }
}
