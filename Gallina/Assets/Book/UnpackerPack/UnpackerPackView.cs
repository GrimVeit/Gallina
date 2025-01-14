using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnpackerPackView : View
{
    [SerializeField] private UnpackPack unpackPackPrefab;
    [SerializeField] private Transform transformParentSpawn;
    [SerializeField] private Transform transformSpawn;
    [SerializeField] private Transform transformEnd;

    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    private UnpackPack currentPack;

    public void Initialize()
    {
        buttonLeft.onClick.AddListener(MovePackToClose_Left);
        buttonRight.onClick.AddListener(MovePackToClose_Right);
    }

    public void Dispose()
    {
        buttonLeft.onClick.RemoveListener(MovePackToClose_Left);
        buttonRight.onClick.RemoveListener(MovePackToClose_Right);
    }

    public void SpawnPack(Pack pack)
    {
        currentPack = Instantiate(unpackPackPrefab, transformParentSpawn);
        currentPack.transform.SetPositionAndRotation(transformSpawn.position, unpackPackPrefab.transform.rotation);
        currentPack.SetData(pack.SpritePack);
    }

    public void MovePackToOpen()
    {
        if(currentPack == null) return;

        currentPack.MoveTo(transformEnd.position, 0.5f, OnOpenPack);
        currentPack.ScaleTo(Vector3.one, 0.7f);
    }

    public void MovePackToClose_Left()
    {
        if(currentPack == null) return;

        OnStartClosePack?.Invoke();
        currentPack.RotateTo(new Vector3(0, -90, 0), 0.5f, ClosePack);
    }

    public void MovePackToClose_Right()
    {
        if (currentPack == null) return;

        OnStartClosePack?.Invoke();
        currentPack.RotateTo(new Vector3(0, 90, 0), 0.5f, ClosePack);
    }

    private void ClosePack()
    {
        OnClosePack?.Invoke();
        currentPack?.DestroyPack();
    }

    #region Input

    public event Action OnStartClosePack;
    public event Action OnOpenPack;
    public event Action OnClosePack;

    #endregion
}
