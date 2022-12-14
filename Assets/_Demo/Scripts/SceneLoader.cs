using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    #region Variables
    public int index;
    #endregion Variables

    #region Unity Methods
    #endregion Unity Methods

    #region Public Methods
    public void LoadScene()
    {
        SceneManager.LoadScene(index);
    }
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
