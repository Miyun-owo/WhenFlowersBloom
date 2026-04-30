using UnityEngine;

public class AudioManager_1 : MonoBehaviour
{
    [Header("Reference")]
    public SpaceManager_1 spaceManager;

    [Header("Directional Audio Sources")]
    public AudioSource frontSource;
    public AudioSource rightSource;
    public AudioSource backSource;
    public AudioSource leftSource;

    private bool isPlaying = false;

    void Update()
    {
        if (!isPlaying) return;

        UpdateVolumes();
    }

    public void PlayAudio()
    {
        if (!frontSource.isPlaying) frontSource.Play();
        if (!rightSource.isPlaying) rightSource.Play();
        if (!backSource.isPlaying) backSource.Play();
        if (!leftSource.isPlaying) leftSource.Play();

        isPlaying = true;
    }

    public void PauseAudio()
    {
        frontSource.Pause();
        rightSource.Pause();
        backSource.Pause();
        leftSource.Pause();
    }

    public void ResumeAudio()
    {
        frontSource.UnPause();
        rightSource.UnPause();
        backSource.UnPause();
        leftSource.UnPause();
    }

    public void StopAudio()
    {
        frontSource.Stop();
        rightSource.Stop();
        backSource.Stop();
        leftSource.Stop();

        isPlaying = false;
    }

    void UpdateVolumes()
    {
        float angleDiff = spaceManager.CurrentAngleDifference;

        float frontVolume = 1f - (angleDiff / 180f);
        float sideVolume = 1f - frontVolume;

        frontSource.volume = frontVolume;
        rightSource.volume = sideVolume * 0.5f;
        backSource.volume = sideVolume;
        leftSource.volume = sideVolume * 0.5f;
    }

}
