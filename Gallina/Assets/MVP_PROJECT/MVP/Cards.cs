using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cards")]
public class Cards : ScriptableObject
{
    public List<CardInfo> cards;
}

[System.Serializable]
public class CardInfo
{
    public int Number;
    public int PageNumber;
    public TypeCard cardType;
    public Sprite Sprite;
}
