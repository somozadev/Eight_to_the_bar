using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public CameraPoints cameraPoints;
    [SerializeField] float total_time = 1f;
    [SerializeField] float time_stamp = 0f;


    public void MoveCameraToChat() { LerpCamToPos(cameraPoints.player_talking); }
    public void MoveCameraToCafeteria() { LerpCamToPos(cameraPoints.main_position); }



    private void LerpCamToPos(Transform pos) { StartCoroutine(LerpCam(pos)); }
    private IEnumerator LerpCam(Transform pos)
    {
        time_stamp = 0f;
        TransformSaver ts = new TransformSaver(transform);
        while (time_stamp < total_time)
        {
            transform.position = Vector3.Lerp(ts.Position, pos.position, time_stamp / total_time);
            transform.rotation = Quaternion.Lerp(ts.Rotation, pos.rotation, time_stamp / total_time);
            time_stamp += Time.deltaTime;
            yield return null;
        }
        time_stamp = total_time;
        transform.position = pos.position;
        transform.rotation = pos.rotation;
        yield return null;
    }

}
