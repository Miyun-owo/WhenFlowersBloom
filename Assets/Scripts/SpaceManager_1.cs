using UnityEngine;

public class SpaceManager_1 : MonoBehaviour
{

    [Header("References")]
    public Transform playerCamera;
    public AudioSource targetSource;
    public AudioSource[] otherSources;
    public FlowManager_1 flowManager;

    [Header("Explore Settings")]
    [Range(1f, 5f)] public float focusPower = 2f;
    public float targetMinVolume = 0.3f;
    public float targetMaxVolume = 0.6f;
    public float otherMinVolume = 0.2f;
    public float otherMaxVolume = 0.4f;

    [Header("Confirm Settings")]
    public float confirmBoost = 1.5f;
    private bool isTracking = false;
    private bool isConfirmed = false;
    public float CurrentDot { get; private set; }

    
    public void StartTracking()
    {
        isTracking = true;
        isConfirmed = false;
    }

    public void StopTracking()
    {
        isTracking = false;
    }
    void Update()
    {
        if (!isTracking) return;
        UpdateAudio();
    }

    void UpdateAudio()
    {
        Vector3 camForward = playerCamera.forward;
        Vector3 dirToTarget = (targetSource.transform.position - playerCamera.position).normalized;

        float dot = Vector3.Dot(camForward, dirToTarget);
        CurrentDot = dot;
        float focus = Mathf.Pow(Mathf.Clamp01(dot), focusPower);

        // target
        float targetVol = Mathf.Lerp(targetMinVolume, targetMaxVolume, focus);
        targetSource.volume = targetVol;

        // other
        foreach (var src in otherSources)
        {
            float otherVol = Mathf.Lerp(otherMaxVolume, otherMinVolume, focus);
            src.volume = otherVol;
        }
    }

    public void Confirm(bool isCorrect)
    {
        isConfirmed = true;

        //Vector3 camForward = playerCamera.forward;
        //Vector3 dirToTarget = (targetSource.transform.position - playerCamera.position).normalized;
        //float dot = Vector3.Dot(camForward, dirToTarget);

        if (isCorrect)
        {
            targetSource.volume = 1f * confirmBoost;
            foreach (var src in otherSources)
                src.volume = 0f;
        }
        else
        {
            //failed
            foreach (var src in otherSources)
                src.volume *= 0.5f;

            targetSource.volume *= 0.5f;
        }
    }

    public void ResetState()
    {
        isConfirmed = false;
    }
}
