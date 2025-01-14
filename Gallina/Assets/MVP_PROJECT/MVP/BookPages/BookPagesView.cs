using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [SerializeField] private TextMeshProUGUI textPage;

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

    private IEnumerator OpenPage_Coroutine(int index)
    {
        int currentIndex = currentOpenPage.Index;

        if(currentIndex < index)
        {
            for(int i = currentIndex;  i <= index; i++)
            {
                currentOpenPage = openPages[i];
                currentOpenPage.ClosePage();
                currentOpenPage.transform.SetParent(parentClosePages);

                OnChoosePage?.Invoke(currentOpenPage);

                yield return new WaitForSeconds(0.1f);
            }

            OnEndOpenPage?.Invoke();
            Debug.Log(currentOpenPage.Index);
            yield break;
        }
        else if(currentIndex > index)
        {
            for (int i = currentIndex; i >= index; i--)
            {
                currentOpenPage = openPages[i];

                if (i != index)
                {
                    currentOpenPage.OpenPage();
                    currentOpenPage.transform.SetParent(parentOpenPages);
                }

                OnChoosePage?.Invoke(currentOpenPage);

                yield return new WaitForSeconds(0.1f);
            }

            OnEndOpenPage?.Invoke();
            Debug.Log(currentOpenPage.Index);
            yield break;
        }

        OnEndOpenPage?.Invoke();
    }

    public void OpenPage(int page)
    {
        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(page);
        Coroutines.Start(enumerator);
    }

    public void OpenSecondPage()
    {
        int index = currentOpenPage.Index + 1;
        if(index > openPages[openPages.Count - 1].Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(index);
        Coroutines.Start(enumerator);
        OnClickToLeft?.Invoke();
    }

    public void OpenPastPage()
    {
        int index = currentOpenPage.Index - 1;
        if (index < openPages[0].Index) return;

        if (enumerator != null)
            Coroutines.Stop(enumerator);

        enumerator = OpenPage_Coroutine(index);
        Coroutines.Start(enumerator);
        OnClickToLeft?.Invoke();
    }


    public void SetDisplayNumberPage(BookPage bookPage)
    {
        textPage.text = $"Page: {bookPage.Index + 1}";
    }

    #region Input

    public event Action<BookPage> OnChoosePage;

    public event Action OnEndOpenPage;

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
