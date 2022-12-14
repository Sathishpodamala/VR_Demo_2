using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AudioSpectrum;

public class Spawner : MonoBehaviour
{
    #region Variables
    [SerializeField]private bool useBeat=true;
    [Range(0.01f,0.09f)]
    public float control = 0.04f;
    public int COUNT = 0;   
    [SerializeField] private AudioSpectrum spectrum;
    [Space]
    [SerializeField] private float beat;
    [SerializeField] private GameObject cubeControllerPrefab;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Transform[] spawnPoints;
    private float timer;

    #endregion Variables

    #region Unity Methods
    void Update()
    {
        if (useBeat)
        {
            if (GetSpectrumMean() > control)
            {
                GenerateCubesWithDelay();
            }
        }
        else
        {
            GenerateCubes();
        }

        timer += Time.deltaTime;
    }
    #endregion Unity Methods

    #region Public Methods
    #endregion Public Methods

    #region Private Methods
    [DebugButton("GenerateCubesWithDelay")]
    private void GenerateCubesWithDelay()
    {
        if (timer > beat)
        {
            CreateCubeAndInitalize();
            timer = 0;
        }
    }
    [DebugButton("GenerateCubes")]
    private void GenerateCubes()
    {
        if (timer > beat)
        {
            CreateCubeAndInitalize();
            timer -=beat;
        }
    }
    [DebugButton("CreateCubeAndInitalize")]
    private void CreateCubeAndInitalize()
    {
        COUNT++;

        GameObject cube = Instantiate(cubeControllerPrefab, spawnPoints[Random.Range(0, 4)]);
        cube.transform.localPosition = Vector3.zero;

        int randColor = Random.Range(0, 2);
        int randDirection = Random.Range(0, 4);
        CubeController cubeController = cube.GetComponent<CubeController>();
        cubeController.Init(GetMaterial(randColor), GetCubeColor(randColor), GetDirection(randDirection));
    }

    private Direction GetDirection(int num)
    {
        switch (num)
        {
            case 1:
                return Direction.LEFT;
            case 2:
                return Direction.RIGHT;
            case 3:
                return Direction.TOP;
            case 4:
                return Direction.BOTTOM;
            default:
                return Direction.RIGHT | Direction.TOP;
        }
    }

    private Material GetMaterial(int num)
    {
        if (num == 1)
            return redMaterial;
        else
            return blueMaterial;
    }

    private Color GetCubeColor(int num)
    {
        if (num == 1)
            return Color.RED;
        else
            return Color.BLUE;
    }


    private float GetSpectrumMean()
    {
        int barCount = spectrum.MeanLevels.Length;
        float mean = 0;
        for (var i = 0; i < barCount; i++)
        {
            mean += spectrum.MeanLevels[i];
            
        }
        return mean;
    }
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks



}
