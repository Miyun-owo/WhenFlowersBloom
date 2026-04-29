using UnityEngine;

public class GameResult_1 : MonoBehaviour
{
    [Header("Reference")]
    public SpaceManager_1 spaceManager;

    [Header("Result Settings")]
    public float successAngleRange = 30f;

    public bool CheckResult()
    {
        float angleDiff = spaceManager.CurrentAngleDifference;

        if (angleDiff <= successAngleRange)
        {
            return true;
        }

        return false;
    }
}
