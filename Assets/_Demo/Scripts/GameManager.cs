using Alpha.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip wrongDirectionClip;
    [SerializeField] private AudioClip wrongColorClip;
    [SerializeField] private AudioClip hitClip;

    #endregion Variables

    #region Unity Methods
    void OnEnable()
    {
        EventHandler.Subscribe(EventId.EVENT_ON_HIT_CUBE, Callback_OnHitCube);
        EventHandler.Subscribe(EventId.EVENT_ON_HIT_CUBE_WRONG_COLOR, Callback_OnHitWrongColor);
        EventHandler.Subscribe(EventId.EVENT_ON_HIT_CUBE_WRONG_DIRECTION, Callback_OnHitWrongDirection);
    }

    void OnDisable()
    {
        EventHandler.UnSubscribe(EventId.EVENT_ON_HIT_CUBE, Callback_OnHitCube);
        EventHandler.UnSubscribe(EventId.EVENT_ON_HIT_CUBE_WRONG_COLOR, Callback_OnHitWrongColor);
        EventHandler.UnSubscribe(EventId.EVENT_ON_HIT_CUBE_WRONG_DIRECTION, Callback_OnHitWrongDirection);
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    private void Callback_OnHitWrongDirection(object args)
    {
        if (audioSource && wrongDirectionClip)
        {
            audioSource.Stop();
            audioSource.clip = wrongDirectionClip;
            audioSource.Play();
        }
    }

    public  void Callback_OnHitWrongColor(object args)
    {
        if(audioSource && wrongColorClip)
        {
            audioSource.Stop();
            audioSource.clip=wrongColorClip;
            audioSource.Play();
        }
    }

    private void Callback_OnHitCube(object args)
    {
        if (audioSource && hitClip)
        {
            audioSource.Stop();
            audioSource.clip = hitClip;
            audioSource.Play();
        }
    }
    #endregion Callbacks

}
