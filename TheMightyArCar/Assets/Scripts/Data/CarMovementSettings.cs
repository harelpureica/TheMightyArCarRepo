using UnityEngine;
namespace TheMightyArCar.Data
{
    [CreateAssetMenu(fileName = "CarMovementSettings", menuName = "DataModels/CarMovementSettings")]
    public class CarMovementSettings : ScriptableObject
    {
        #region Fields

        [SerializeField]
        private float speed;

        [SerializeField]
        private float acceleration;

        [SerializeField]
        private float jumpForce;

        [SerializeField]
        private float rotationSpeed;

        #endregion

        #region Properties

        public float Speed => speed; 

        public float Acceleration  => acceleration;

        public float JumpForce  => jumpForce;

        public float RotationSpeed => rotationSpeed;

        #endregion
    }
}
