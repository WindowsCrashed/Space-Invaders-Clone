using UnityEngine;

public class CameraAdjuster : MonoBehaviour
{
    [SerializeField] SpriteRenderer reference;

    void Start()
    {
        Application.targetFrameRate = 120;
        ScaleWithScreenSize();
    }

    void ScaleWithScreenSize()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = reference.bounds.size.x / reference.bounds.size.y;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = reference.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = reference.bounds.size.y / 2 * differenceInSize;
        }
    }
}
