using UnityEngine;

[System.Serializable]
public static class Utils
{

}
[System.Serializable]
public class TransformSaver
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion rotation;
    public Vector3 Position { get { return position; } }
    public Quaternion Rotation { get { return rotation; } }
    public TransformSaver(Transform trf)
    {
        position = trf.position;
        rotation = trf.rotation;
    }
}