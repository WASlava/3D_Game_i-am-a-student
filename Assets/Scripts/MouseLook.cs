using UnityEngine;


public class MouseLook : MonoBehaviour
{
    public enum RotationAxes 
    {
        MouseXAndY, MouseX, MouseY 
    }

    [SerializeField] private RotationAxes axes = RotationAxes.MouseXAndY;

    [SerializeField] private float sensitivityHorz = 4.0F;
    [SerializeField] private float sensitivityVert = 4.0F;
    [SerializeField] private float minVertAngle = -45.0F;
    [SerializeField] private float maxVertAngle = 45.0F;

    private float _rotationX = 0.0f;

    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null) 
        {
            rigidbody.freezeRotation = true;
        }
    }

    void Update()
    {
        if (axes == RotationAxes.MouseX || axes == RotationAxes.MouseXAndY)
        {
            float rotationY = Input.GetAxis("Mouse X") * sensitivityHorz;
            transform.Rotate(0, rotationY, 0);
        }
        
        if (axes == RotationAxes.MouseY || axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minVertAngle, maxVertAngle);

            transform.localEulerAngles = new Vector3(_rotationX, 0, 0.0F);
        }

    }
}
