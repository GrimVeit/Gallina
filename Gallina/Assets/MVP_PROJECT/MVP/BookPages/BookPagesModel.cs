using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPagesModel
{
    public event Action OnEndOpenPage;

    public event Action OnOpenSecondPage;
    public event Action OnOpenPastPage;
    public event Action<int> OnOpenPage;

    public event Action<BookPage> OnNumberPage;

    public void OpenPage(int page)
    {
        OnOpenPage?.Invoke(page);
    }

    public void OpenSecondPage()
    {
        OnOpenPastPage?.Invoke();
    }

    public void OpenPastPage()
    {
        OnOpenPastPage?.Invoke();
    }

    public void NumberPage(BookPage bookPage)
    {
        OnNumberPage?.Invoke(bookPage);
    }

    public void EndOpenPage()
    {
        OnEndOpenPage?.Invoke();
    }
}
