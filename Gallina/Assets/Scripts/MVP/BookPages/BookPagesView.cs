using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPagesView : View
{
    [SerializeField] private int index;

    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;

    [SerializeField] private List<BookPage> openPages = new List<BookPage>();
    [SerializeField] private Transform parentClosePages;
    [SerializeField] private Transform parentOpenPages;

    [SerializeField] private BookPage currentOpenPage;

    private IEnumerator enumerator;

    public void Initialize()
    {

        currentOpenPage = openPages[0];
        currentOpenPage.ClosePage();
        currentOpenPage.transform.SetParent(parentClosePages);

        buttonLeft.onClick.AddListener(HandleClickToOpenPastPage);
        buttonRight.onClick.AddListener(HandleClickToCloseButton);
    }

    public void Dispose()
    {
        buttonLeft.onClick.RemoveListener(HandleClickToOpenPastPage);
        buttonRight.onClick.RemoveListener(HandleClickToCloseButton);
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

                Debug.Log("Close page - " + currentOpenPage.Index);

                yield return new WaitForSeconds(0.1f);
            }
            Debug.Log(currentOpenPage.Index);
            yield break;
        }
        else if(currentIndex > index)
        {
            for (int i = currentIndex; i >= index; i--)
            {
                currentOpenPage = openPages[i];

                if(i != index)
                {
                    currentOpenPage.OpenPage();
                    currentOpenPage.transform.SetParent(parentOpenPages);
                }

                Debug.Log("Open page - " + currentOpenPage.Index);

                yield return new WaitForSeconds(0.1f);
            }
            Debug.Log(currentOpenPage.Index);
            yield break;
        }
    }

    public void OpenSecondPage()
    {
        int index = currentOpenPage.Index + 1;
        if(index > openPages[openPages.Count - 1].Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage(index);
        Coroutines.Start(enumerator);
        OnClickToLeft?.Invoke();
    }

    public void OpenPastPage()
    {
        int index = currentOpenPage.Index - 1;
        if (index < openPages[0].Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage(index);
        Coroutines.Start(enumerator);
        OnClickToLeft?.Invoke();
    }

    #region Input

    public event Action OnClickToLeft;
    public event Action OnClickToRight;

    private void HandleClickToOpenPastPage()
    {
        OpenPastPage();
    }

    private void HandleClickToCloseButton()
    {
        OpenSecondPage();
    }

    #endregion
}
