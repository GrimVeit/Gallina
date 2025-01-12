using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPagesModel
{
    public event Action<int> OnOpenPage;

    public void OpenPage(int page)
    {
        OnOpenPage?.Invoke(page);
    }
}
