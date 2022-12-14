using Alpha.Events;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    #endregion Variables

    #region Unity Methods
    void OnEnable()
    {
        EventHandler.Subscribe(EventId.EVENT_ON_HIT_CUBE, Callback_OnHitCube);
        EventHandler.Subscribe(EventId.EVENT_ON_CUBE_MISSID,Callback_OnCubeMissid);
    }

    void OnDisable()
    {
        EventHandler.UnSubscribe(EventId.EVENT_ON_HIT_CUBE, Callback_OnHitCube);
        EventHandler.UnSubscribe(EventId.EVENT_ON_CUBE_MISSID,Callback_OnCubeMissid);

 
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    private void UpdateScoreText()
    {
        if(scoreText)
        {
            scoreText.text=score.ToString();
        }
    }
    #endregion Private Methods

    #region Callbacks
    private void Callback_OnCubeMissid(object args)
    {
        //score--;
        //if(score<0)
        //    score = 0;

        //UpdateScoreText();
    }

    private void Callback_OnHitCube(object args)
    {
        score++;
        UpdateScoreText();
    }
    #endregion Callbacks

}
