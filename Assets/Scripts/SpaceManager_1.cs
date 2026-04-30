using UnityEngine;

public class SpaceManager_1 : MonoBehaviour
{
    [Header("Target Settings")]
    public float targetAngle = 90f;

    [Header("Tracking Status")]
    public bool isTracking = false;
    public float CurrentAngleDifference { get; private set; }

    private float initialOffset;

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if (!isTracking) return;

        Quaternion deviceRotation = Input.gyro.attitude;
        float yAngle = deviceRotation.eulerAngles.y;

        float adjustedAngle = Mathf.DeltaAngle(yAngle - initialOffset, targetAngle);

        CurrentAngleDifference = Mathf.Lerp(CurrentAngleDifference,Mathf.Abs(adjustedAngle),0.2f);
    }

    public void StartTracking()
    {
        initialOffset = Input.gyro.attitude.eulerAngles.y;
        isTracking = true;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
}
