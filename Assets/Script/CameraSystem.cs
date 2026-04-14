using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [Header("Assign Cameras Here")]
    public Camera[] securityCameras; // This creates a list of cameras

    public void SwitchCamera(int cameraIndex)
    {
        // First, turn OFF every camera in the list
        foreach (Camera cam in securityCameras)
        {
            cam.gameObject.SetActive(false);
        }
        
        // Then, turn ON only the specific one we asked for
        securityCameras[cameraIndex].gameObject.SetActive(true);
    }
}