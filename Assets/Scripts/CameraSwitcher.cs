using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera camera_I;
    public Camera camera_III;
    public static Camera activeCamera;

    private void Start()
    {
        SetActiveCamera(camera_III);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) // ���������� "C" ����� ������
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        if (camera_I.enabled)
        {
            SetActiveCamera(camera_III);
        }
        else
        {
            SetActiveCamera(camera_I);
        }
    }

    void SetActiveCamera(Camera newActiveCamera)
    {
        camera_I.enabled = (newActiveCamera == camera_I);
        camera_III.enabled = (newActiveCamera == camera_III);
        activeCamera = newActiveCamera;
    }
}
