using Assets.Scripts.GamePlay.Vfx;
using System;
using TheMightyArCar.GamePlay.Events;
using TheMightyArCar.GamePlay.Events.Args;
using UnityEngine;
using Vuforia;

namespace TheMightyArCar.Infrastructure.Tracking
{
    public class PlaneDetectionController:MonoBehaviour,IPlaneDetectionController
    {
        #region Fields
        [SerializeField]
        private AnchorInputListenerBehaviour anchorInputListenerBehaviour;

        [SerializeField]
        private ContentPositioningBehaviour contentPositioningBehaviour;

        [SerializeField]
        private PlaneFinderBehaviour planeFinderBehaviour;

        [SerializeField]
        private GameObject uiParent;

        #endregion

        #region Methods
        #region Mono
        private void Start()
        {
            uiParent.SetActive(false);
            contentPositioningBehaviour.OnContentPlaced.AddListener(OnContentPlaced);
        }

        #endregion
        public void SetPlacement(bool active)
        {
            anchorInputListenerBehaviour.enabled = active;
            contentPositioningBehaviour.enabled = active;
            planeFinderBehaviour.enabled = active;
            planeFinderBehaviour.PlaneIndicator.SetActive(active);

        }
        public void OnContentPlaced(GameObject placedObj)
        {
            EventBus.Publish(GamePlayEventType.carSpawned, new CarSpawnedEventArgs(VfxType.SpawnParticles, placedObj.transform.position));
            uiParent.SetActive(true);
            SetPlacement(false);
        }
       
        
        #endregion
    }
}
