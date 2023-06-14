using System;
using System.Collections.Generic;
using UnityEngine;

namespace TheMightyArCar.GamePlay.Events
{
    public static class EventBus
    {
        #region Fields
        private static Dictionary<GamePlayEventType, List<Action<EventArgs>>> subs = new Dictionary<GamePlayEventType, List<Action<EventArgs>>>();
        #endregion

        #region Methods

        #region Public
        public static void Publish(GamePlayEventType eventType,EventArgs eventArgs)
        {
            if(!subs.ContainsKey(eventType))
            {
                return;
            }
            for (int i = 0; i < subs[eventType].Count; i++)
            {
                subs[eventType][i].Invoke(eventArgs);
            }

        }
        public static void Subscribe(GamePlayEventType eventType, Action<EventArgs> action)
        {
            ValidateKeyExist(eventType);
            subs[eventType].Add(action);
        }
        public static void Unsubscribe(GamePlayEventType eventType,Action<EventArgs> action)
        {
            
            if(subs.ContainsKey(eventType))
            {
                if (subs[eventType].Contains(action))
                {
                    subs[eventType].Remove(action);
                }
            }
        }
        #endregion

        #region Private
        private static void ValidateKeyExist(GamePlayEventType eventType)
        {
          if(!subs.ContainsKey(eventType))
            {
                subs.Add(eventType,new List<Action<EventArgs>>());
            }
        }
        #endregion
        #endregion

    }
}
