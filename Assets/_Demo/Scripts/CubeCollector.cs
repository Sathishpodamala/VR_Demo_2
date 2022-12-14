using Alpha.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    #region Variables
    #endregion Variables

    #region Unity Methods
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cube"))
        {
            EventHandler.BroadCast(EventId.EVENT_ON_CUBE_MISSID);
            Destroy(other.gameObject);
        }
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks

}
