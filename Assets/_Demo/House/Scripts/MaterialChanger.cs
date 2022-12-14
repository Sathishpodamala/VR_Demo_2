using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialChanger : MonoBehaviour
{
    #region Variables
    [SerializeField] private Material material;
    [SerializeField]private List<Color32>colors = new List<Color32>();
    [SerializeField] private List<Image> buttonImages = new List<Image>();
    #endregion Variables

    #region Unity Methods
    void Start()
    {
        IntitButtonColors();
    }
    #endregion Unity Methods

    #region Public Methods
    public void OnClickButtonToChangeMaterial(int index)
    {
        material.color = colors[index];
    }
    #endregion Public Methods

    #region Private Methods
    private void IntitButtonColors()
    {
        for (int i = 0; i < colors.Count; i++)
        {
            buttonImages[i].color = colors[i];
        }
    }
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
