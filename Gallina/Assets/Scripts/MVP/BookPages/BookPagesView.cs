using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookPagesView : View
{
    [SerializeField] private Button buttonOpen;
    [SerializeField] private Button buttonClose;

    [SerializeField] private List<BookPage> bookPages = new List<BookPage>();

    public void Initialize()
    {
        buttonOpen.onClick.AddListener(HandleClickToOpenButton);
        buttonClose.onClick.AddListener(HandleClickToCloseButton);
    }

    public void Dispose()
    {
        buttonOpen.onClick.RemoveListener(HandleClickToOpenButton);
        buttonClose.onClick.RemoveListener(HandleClickToCloseButton);
    }

    private IEnumerator OpenPages()
    {
        for (int i = 0; i < bookPages.Count; i++)
        {
            bookPages[i].OpenPage();

            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator ClosePages()
    {
        for (int i = 0; i < bookPages.Count; i++)
        {
            bookPages[i].ClosePage();

            yield return new WaitForSeconds(1f);
        }
    }

    #region Input

    public event Action OnClickToOpenButton;
    public event Action OnClickToCloseButton;

    private void HandleClickToOpenButton()
    {
        Coroutines.Start(OpenPages());
        OnClickToOpenButton?.Invoke();
    }

    private void HandleClickToCloseButton()
    {
        Coroutines.Start(ClosePages());
        OnClickToCloseButton?.Invoke();
    }

    #endregion
}
