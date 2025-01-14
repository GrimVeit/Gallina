using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpackerPackModel
{
    public event Action<CardInfo> OnSpawnDuplicateCard;
    public event Action<CardInfo> OnSpawnNewCard;

    public event Action<Pack> OnSpawnPack;
    public event Action OnMovePackToOpen;

    public void SpawnPack(Pack pack)
    {
        OnSpawnPack?.Invoke(pack);
    }

    public void MovePackToOpen()
    {
        OnMovePackToOpen?.Invoke();
    }
}
