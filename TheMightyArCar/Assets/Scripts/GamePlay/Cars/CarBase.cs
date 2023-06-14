using TheMightyArCar.GamePlay.Cars.Components;
using TheMightyArCar.Infrastructure.Inputs;
using UnityEngine;

namespace  TheMightyArCar.GamePlay.Cars
{
    public abstract class CarBase:MonoBehaviour
    {
        #region Fields
       
        protected ICarMovementComponent movementComponent;
        #endregion

        #region Methods
        #region Mono
        protected void Start()
        {
            movementComponent = GetComponent<ICarMovementComponent>();
        }
        protected void Update()
        {
            var input = new Vector2(InputManager.Instance.HorizontalInput, InputManager.Instance.VerticalInput);
            movementComponent.Move(input.x,input.y);
        }
        #endregion
        #endregion
    }
}
