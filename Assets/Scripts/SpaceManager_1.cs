using UnityEngine;

public class SpaceManager_1 : MonoBehaviour
{
    public AudioManager_1 audioManager;

    [Header("Target Settings")]
    public float targetAngle = 90f;

    [Header("Tracking Status")]
    public bool isTracking = false;
    public float CurrentAngleDifference { get; private set; }

    [Header("Smoothing")]
    public float smoothSpeed = 8f;

    private float rawAngle;
    private float smoothedAngle;
    private float anchorAngle;

    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update()
    {
        if (!isTracking) return;

        Quaternion deviceRotation = Input.gyro.attitude;
        deviceRotation = Quaternion.Euler(90, 0, 0) * deviceRotation;

        rawAngle = deviceRotation.eulerAngles.y;

        float delta = Mathf.DeltaAngle(smoothedAngle, rawAngle);
        smoothedAngle += delta * Time.deltaTime * smoothSpeed;

        float relativeAngle = Mathf.DeltaAngle(anchorAngle, smoothedAngle);

        float adjustedAngle = Mathf.DeltaAngle(relativeAngle, targetAngle);
        CurrentAngleDifference = Mathf.Abs(adjustedAngle);

        //four-directional volume calculation
        float angleRad = relativeAngle * Mathf.Deg2Rad;

        float front = Mathf.Clamp01(Mathf.Cos(angleRad));
        float right = Mathf.Clamp01(Mathf.Cos(angleRad - Mathf.PI / 2));
        float back = Mathf.Clamp01(Mathf.Cos(angleRad - Mathf.PI));
        float left = Mathf.Clamp01(Mathf.Cos(angleRad - 3 * Mathf.PI / 2));

        float sum = front + right + back + left;

        front /= sum;
        right /= sum;
        back /= sum;
        left /= sum;

        audioManager.SetDirectionalVolume(front, right, back, left);
    }

    public void StartTracking()
    {
        Quaternion deviceRotation = Input.gyro.attitude;
        deviceRotation = Quaternion.Euler(90, 0, 0) * deviceRotation;

        anchorAngle = deviceRotation.eulerAngles.y;
        smoothedAngle = anchorAngle;

        isTracking = true;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
}
