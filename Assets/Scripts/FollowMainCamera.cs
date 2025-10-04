using UnityEngine;

public class FollowMainCamera : MonoBehaviour
{
    public Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCam != null)
        {
            transform.position = mainCam.transform.position;
            transform.rotation = mainCam.transform.rotation;

            // Important : synchroniser le FOV aussi
            Camera colorCam = GetComponent<Camera>();
            colorCam.fieldOfView = mainCam.fieldOfView;
        }
    }
}
