using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDirection : MonoBehaviour
{
    #region Variables
    [SerializeField] private Direction direction;
    [SerializeField] private GameObject arrowGameobject;
    [SerializeField] private CubeController cubeController;
    #endregion Variables

    #region Unity Methods

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Saber"))
        {
            if (other.TryGetComponent(out Saber saber))
            {
                SaberAndCubeInfo info = new SaberAndCubeInfo(saber.GetSaberColor(), direction);
                cubeController.OnSaberTouchedCube(info);
            }
        }
    }
    #endregion Unity Methods

    #region Public Methods
    public void Init(CubeController controller)
    {
        if (arrowGameobject)
            arrowGameobject.SetActive(true);
    }
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks

}
