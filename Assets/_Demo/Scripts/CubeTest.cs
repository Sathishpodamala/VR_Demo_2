using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    #region Variables
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;

    [Header("Red Cubes")]
    public CubeController leftRedCube;
    public CubeController rightRedCube;
    public CubeController topRedCube;
    public CubeController bottomRedCube;

    [Header("Blue Cubes")]
    public CubeController leftBlueCube;
    public CubeController rightBlueCube;
    public CubeController topBlueCube;
    public CubeController bottomBlueCube;

    #endregion Variables

    #region Unity Methods
    void Start()
    {
        leftRedCube.Init(redMaterial,Color.RED,Direction.LEFT);
        rightRedCube.Init(redMaterial, Color.RED, Direction.RIGHT);
        topRedCube.Init(redMaterial, Color.RED, Direction.TOP);
        bottomRedCube.Init(redMaterial, Color.RED, Direction.BOTTOM);

        leftBlueCube.Init(blueMaterial, Color.BLUE, Direction.LEFT);
        rightBlueCube.Init(blueMaterial, Color.BLUE, Direction.RIGHT);
        topBlueCube.Init(blueMaterial, Color.BLUE, Direction.TOP);
        bottomBlueCube.Init(blueMaterial, Color.BLUE, Direction.BOTTOM);
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
    
}
