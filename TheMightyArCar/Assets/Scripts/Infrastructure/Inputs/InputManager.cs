
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Windows;
using Input= UnityEngine.Input;

namespace TheMightyArCar.Infrastructure.Inputs
{
    public class InputManager:MonoBehaviour
    {
        #region Fields
       private static InputManager instance;

        [SerializeField]
        private FixedJoystick joystickHorizontal;

        [SerializeField]
        private FixedJoystick joystickVertical;


        #endregion

        #region Properties

        public static InputManager Instance => instance;
        public float HorizontalInput => joystickHorizontal.Horizontal;
        public float VerticalInput => joystickVertical.Vertical;

        #endregion

        #region Methods
        private void Awake()
        {
            if(instance == null)
            {
                instance= this;
            }else if(instance!=this)
            {
                Destroy(gameObject);
            }
        }
        #endregion


    }
}
