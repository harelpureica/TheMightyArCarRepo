using Assets.Scripts.GamePlay.Vfx;
using System;
using System.Collections;
using System.Collections.Generic;
using TheMightyArCar.GamePlay.Events;
using TheMightyArCar.GamePlay.Events.Args;
using UnityEngine;

public class VfxSpawner : MonoBehaviour
{
    #region Fields
    [SerializeField]
    private List<VfxBase> vfxPrefabs;
    #endregion

    #region Methods
    private void Start()
    {
        EventBus.Subscribe(GamePlayEventType.carSpawned, SpawnVfx);
    }
    public void SpawnVfx(EventArgs args)
    {
        var parameters = args as CarSpawnedEventArgs;
        for (int i = 0; i < vfxPrefabs.Count; i++)
        {
            if (vfxPrefabs[i].MyVfxType == parameters.VfxType)
            {
                Instantiate(vfxPrefabs[i],parameters.SpawnPosition,Quaternion.identity);
            }
        }
    }
    #endregion
}
