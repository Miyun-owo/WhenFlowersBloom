using UnityEngine;

public class SpaceManager_1 : MonoBehaviour
{
    [Header("Target Settings")]
    public float targetAngle = 90f;

    [Header("Tracking Status")]
    public bool isTracking = false;

    public float CurrentAngleDifference { get; private set; }

    void Start()
    {
        Input.compass.enabled = true;
    }

    void Update()
    {
        if (!isTracking) return;

        float currentHeading = Input.compass.trueHeading;
        CurrentAngleDifference = Mathf.Abs(Mathf.DeltaAngle(currentHeading, targetAngle));
    }

    public void StartTracking()
    {
        isTracking = true;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
}
