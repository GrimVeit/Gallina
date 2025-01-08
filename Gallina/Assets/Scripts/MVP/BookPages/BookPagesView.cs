using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPagesView : View
{
    [SerializeField] private int index;

    [SerializeField] private Button buttonOpen;
    [SerializeField] private Button buttonClose;

    [SerializeField] private List<BookPage> openPages = new List<BookPage>();
    [SerializeField] private Transform parentClosePages;
    [SerializeField] private Transform parentOpenPages;

    [SerializeField] private List<BookPage> closePages = new List<BookPage>();

    private BookPage currentOpenPage;

    private IEnumerator enumerator;

    public void Initialize()
    {

        currentOpenPage = openPages[0];

        buttonOpen.onClick.AddListener(HandleClickToOpenButton);
        buttonClose.onClick.AddListener(HandleClickToCloseButton);
    }

    public void Dispose()
    {
        buttonOpen.onClick.RemoveListener(HandleClickToOpenButton);
        buttonClose.onClick.RemoveListener(HandleClickToCloseButton);
    }

    private IEnumerator OpenPage(int index)
    {
        int currentIndex = currentOpenPage.Index;

        if(currentIndex < index)
        {
            for(int i = currentIndex;  i <= index; i++)
            {
                currentOpenPage = openPages[i];
                currentOpenPage.ClosePage();
                currentOpenPage.transform.SetParent(parentClosePages);

                yield return new WaitForSeconds(0.4f);
            }
            Debug.Log(currentOpenPage.Index);
            yield break;
        }
        else if(currentIndex > index)
        {
            for (int i = currentIndex; i >= index; i--)
            {
                currentOpenPage = openPages[i];
                currentOpenPage.OpenPage();
                currentOpenPage.transform.SetParent(parentOpenPages);

                yield return new WaitForSeconds(0.4f);
            }
            Debug.Log(currentOpenPage.Index);
            yield break;
        }
    }

    #region Input

    public event Action OnClickToOpenButton;
    public event Action OnClickToCloseButton;

    private void HandleClickToOpenButton()
    {
        if(enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage(index);
        Coroutines.Start(enumerator);
        OnClickToOpenButton?.Invoke();
    }

    private void HandleClickToCloseButton()
    {
        //if (enumerator != null)
        //    Coroutines.Stop(enumerator);

        //enumerator = OpenPage(1);
        //Coroutines.Start(enumerator);
        //OnClickToCloseButton?.Invoke();
    }

    #endregion
}
