using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class fpsInput : MonoBehaviour
{
    [SerializeField] private float speed = 4.0F;
    [SerializeField] private float gravity = -9.8F;

    private CharacterController _characterController;
    private Transform _cameraTransform;
    private Vector3 _movement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = CameraSwitcher.activeCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        Vector3 forward = _cameraTransform.forward;
        Vector3 right = _cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();



        Vector3 desiredMoveDirection = (forward * vertical + right * horizontal) * speed;

        _movement = new Vector3(desiredMoveDirection.x, gravity, desiredMoveDirection.z);

        _characterController.Move(_movement * Time.deltaTime);

    }
}
