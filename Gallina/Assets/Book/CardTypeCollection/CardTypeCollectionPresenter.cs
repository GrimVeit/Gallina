using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTypeCollectionPresenter
{
    private int countCommonCards;
    private int countRareCards;
    private int countEpicCards;
    private int countLegendaryCards;
    private int countGoldCards;


    public void AddCardType(TypeCard typeCard)
    {
        switch (typeCard)
        {
            case TypeCard.common:
                countCommonCards++;
                break;
            case TypeCard.rare:
                countRareCards++;
                break;
            case TypeCard.epic:
                countEpicCards++;
                break;
            case TypeCard.legendary:
                countLegendaryCards++;
                break;
        }
    }
}
