using UnityEngine;

public class FlowManager_1 : MonoBehaviour
{
    public bool SignalSection;

    [Header("Managers")]
    public UIManager uiManager;
    public AudioManager_1 audioManager;
    public SpaceManager_1 spaceManager;
    public GameResult_1 gameResult;

    public void StartSection1()
    {
        uiManager.Active1();
    }

    public void OnSetPosition()
    {
        spaceManager.StartTracking();
        audioManager.PlayAudio();
    }

    public void OnSelect()
    {
        bool isCorrect = gameResult.CheckResult();

        if (isCorrect)
        {
            uiManager.Active1_1();
        }
    }
}
