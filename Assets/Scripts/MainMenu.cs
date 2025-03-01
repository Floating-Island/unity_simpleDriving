using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        string savedHighScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0).ToString(); 
        highScoreText.text = $"High Score: {savedHighScore}";
    }
    public void PlayButtonAction()
    {
        SceneManager.LoadScene("Scene_Game");
    }
}
