using TheMightyArCar.Data;
using TheMightyArCar.GamePlay.Cars.Components;
using UnityEngine;
using UnityEngine.UI;

public class CarMovementComponent : MonoBehaviour,ICarMovementComponent
{
    #region Fields

    [SerializeField]
    private CarMovementSettings movementSettings;

    private Rigidbody rb;

    private Button btn;

    #endregion

    #region Methods

    #region Mono
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    #endregion

    #region Public
   

    public void Jump()
    {
        rb.AddForce(Vector3.up * movementSettings.JumpForce, ForceMode.Impulse);
    }

    public void Move(float x, float y)
    {
        var direction = transform.forward*y;
        rb.velocity=Vector3.Lerp(rb.velocity, direction.normalized * movementSettings.Speed,movementSettings.Acceleration *Time.deltaTime);
        transform.Rotate(new Vector3(0, x*Time.deltaTime*movementSettings.RotationSpeed, 0));
    }


    #endregion

    #endregion
}
