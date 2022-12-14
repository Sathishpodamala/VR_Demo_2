using Alpha.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    #region Variables
    [SerializeField] private bool canMove = true;
    [SerializeField] private float cubeSpeed = 2f;
    [SerializeField] private GameObject visualsParent;
    [SerializeField] private MeshRenderer cubeMesh;
    [SerializeField] private CubeDirection rightDirection;
    [SerializeField] private CubeDirection leftDirection;
    [SerializeField] private CubeDirection topDirection;
    [SerializeField] private CubeDirection bottomDirection;
    [SerializeField] private CubeDirection frontDirection;
    private Color cubeColor;
    private Direction requiredDirection;
    private bool isCubeLocked = true;
    #endregion Variables

    #region Unity Methods

    void Update()
    {
        if (canMove)
            transform.position -= Time.deltaTime * transform.forward * cubeSpeed;
    }
    #endregion Unity Methods

    #region Public Methods
    public void Init(Material cubeMaterial, Color cubeColor, Direction cubeDirection)
    {
        cubeMesh.material = cubeMaterial;
        this.cubeColor = cubeColor;
        requiredDirection = cubeDirection;

        InitCubeDirection(cubeDirection);
        isCubeLocked = false;
    }

    public void OnSaberTouchedCube(SaberAndCubeInfo info)
    {
        if (isCubeLocked)
            return;
        isCubeLocked = true;

        if (info.saberColor == cubeColor && info.cubeHitDirection == requiredDirection)
        {
            EventHandler.BroadCast(EventId.EVENT_ON_HIT_CUBE);
        }
        else
        {
            if (info.saberColor != cubeColor)
            {
                EventHandler.BroadCast(EventId.EVENT_ON_HIT_CUBE_WRONG_COLOR);
            }
            else if (info.cubeHitDirection != requiredDirection)
            {
                EventHandler.BroadCast(EventId.EVENT_ON_HIT_CUBE_WRONG_DIRECTION);
            }
        }


        visualsParent.SetActive(false);
        //StartCoroutine(set());
        Destroy(gameObject, 1f);
    }


    IEnumerator set()
    {
        yield return new WaitForSeconds(0.3f);
        isCubeLocked = false;
        visualsParent.SetActive(true);
    }
    #endregion Public Methods

    #region Private Methods
    private void InitCubeDirection(Direction cubeDirection)
    {
        switch (cubeDirection)
        {
            case Direction.LEFT:
                leftDirection.gameObject.SetActive(true);
                leftDirection.Init(this);
                break;
            case Direction.RIGHT:
                rightDirection.gameObject.SetActive(true);
                rightDirection.Init(this);
                break;
            case Direction.TOP:
                topDirection.gameObject.SetActive(true);
                topDirection.Init(this);
                break;
            case Direction.BOTTOM:
                bottomDirection.gameObject.SetActive(true);
                bottomDirection.Init(this);
                break;
            case Direction.FRONT:
                frontDirection.gameObject.SetActive(true);
                frontDirection.Init(this);
                break;
            default:
                break;
        }
    }
    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
}

public class SaberAndCubeInfo
{
    public Color saberColor;
    public Direction cubeHitDirection;

    public SaberAndCubeInfo(Color saberColor, Direction cubeHitDirection)
    {
        this.saberColor = saberColor;
        this.cubeHitDirection = cubeHitDirection;
    }
}


