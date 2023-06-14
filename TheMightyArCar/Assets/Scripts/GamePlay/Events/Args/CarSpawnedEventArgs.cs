using Assets.Scripts.GamePlay.Vfx;
using System;
using UnityEngine;
namespace TheMightyArCar.GamePlay.Events.Args
{
    public class CarSpawnedEventArgs:EventArgs
    {
        [SerializeField]
        private VfxType vfxType;

        [SerializeField]
        private Vector3 spawnPosition;

        public CarSpawnedEventArgs(VfxType vfxType, Vector3 spawnPosition)
        {
            this.vfxType = vfxType;
            this.spawnPosition = spawnPosition;
        }

        public VfxType VfxType => vfxType; 
        public Vector3 SpawnPosition => spawnPosition; 
    }
}
