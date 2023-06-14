using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GamePlay.Vfx
{
    public abstract class VfxBase:MonoBehaviour
    {
        #region Fields
        [SerializeField]
        protected float killTime;

        #endregion

        #region Abstract
        public abstract VfxType MyVfxType { get; }
        #endregion

        #region Methods
        protected virtual async void Start()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(killTime));
            Destroy(gameObject);
        }
        #endregion
    }
}
