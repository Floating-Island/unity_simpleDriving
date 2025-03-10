using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private IOSNotificationHandler iosNotificationHandler;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text playButtonText;

    [SerializeField] private Button playButton;
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energyRechargeDelayMinutes;

    private int energyRemaining;

    private const int updateEnergyStatusIntervalSeconds = 5;
    private const int updateEnergyStatusFirstDelaySeconds = 0;

    private const string energyRemainingKey = "Key_EnergyRemaining";
    private const string energyReadyTimeKey = "Key_EnergyReadyTime";

    private void Start()
    {
        MenuSetup();
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        if (focusStatus)
        {
            MenuSetup();
        }
    }

    private void MenuSetup()
    {
        CancelInvoke(nameof(UpdateEnergyStatus));

        DisplayHighScore();
        LoadEnergyRemaining();

        InvokeRepeating(nameof(UpdateEnergyStatus), updateEnergyStatusFirstDelaySeconds, updateEnergyStatusIntervalSeconds);
    }

    private void DisplayHighScore()
    {
        string savedHighScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0).ToString();
        highScoreText.text = $"High Score: {savedHighScore}";
    }

    private void UpdateEnergyStatus()
    {
        RestoreEnergy();
        UpdatePlayButtonText();
        UpdatePlayButtonBehaviour();
    }

    private void UpdatePlayButtonText()
    {
        playButtonText.text = $"Play ({energyRemaining})";
    }

    private void UpdatePlayButtonBehaviour()
    {
        playButton.interactable = energyRemaining != 0;
    }

    private void RestoreEnergy()
    {
        if (energyRemaining != 0) { return; }
    
        string energyReadyTimeString = PlayerPrefs.GetString(energyReadyTimeKey, string.Empty);
        
        if (energyReadyTimeString == string.Empty) { return; }

        DateTime energyReadyTime = DateTime.Parse(energyReadyTimeString);

        if (DateTime.Now > energyReadyTime)
        {
            energyRemaining = maxEnergy;
            PlayerPrefs.SetInt(energyRemainingKey, energyRemaining);
        }
    }

    private void LoadEnergyRemaining()
    {
        energyRemaining = PlayerPrefs.GetInt(energyRemainingKey, maxEnergy);
    }

    public void PlayButtonAction()
    {
        if (energyRemaining == 0) { return; }

        energyRemaining -= 1;

        PlayerPrefs.SetInt(energyRemainingKey, energyRemaining);

        if (energyRemaining == 0)
        {
            DateTime energyReadyTime = DateTime.Now.AddMinutes(energyRechargeDelayMinutes);
            PlayerPrefs.SetString(energyReadyTimeKey, energyReadyTime.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReadyTime);
#endif
#if UNITY_IOS
            iosNotificationHandler.ScheduleNotification(energyReadyTime);
#endif
        }

        SceneManager.LoadScene("Scene_Game");
    }
}
