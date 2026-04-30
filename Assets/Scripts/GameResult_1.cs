using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class GameResult_1 : MonoBehaviour
{
    [Header("Reference")]
    public SpaceManager_1 spaceManager;
    public AudioManager_1 audioManager;

    [Header("Result Settings")]
    public float successAngleRange = 30f;

    [Header("UI")]
    public Image targetIcon;
    public Sprite state1Sprite;
    public Sprite state2Sprite;

    public bool CheckResult()
    {
        float angleDiff = spaceManager.CurrentAngleDifference;

        if (angleDiff <= successAngleRange)
        {
            return true;
        }

        return false;
    }

    public void ResetResultUI()
    {
        targetIcon.sprite = state1Sprite;
    }

    IEnumerator FailFeedback()
    {
        audioManager.PauseAudio();
        Handheld.Vibrate();
        targetIcon.sprite = state2Sprite;
        yield return new WaitForSeconds(3f);
        targetIcon.sprite = state1Sprite;
        audioManager.ResumeAudio();
    }
}
