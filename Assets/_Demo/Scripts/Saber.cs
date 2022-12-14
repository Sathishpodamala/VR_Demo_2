using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saber : MonoBehaviour
{
    #region Variables
    [SerializeField] private Color saberColor;
    #endregion Variables

    #region Unity Methods
    void Start()
    {
        
    }
    #endregion Unity Methods

    #region Public Methods
    public Color GetSaberColor()
    {
        return saberColor;
    }
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
