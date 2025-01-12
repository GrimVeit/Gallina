using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPagesPresenter
{
    private BookPagesModel bookPagesModel;
    private BookPagesView bookPagesView;

    public BookPagesPresenter(BookPagesModel bookPagesModel, BookPagesView bookPagesView)
    {
        this.bookPagesModel = bookPagesModel;
        this.bookPagesView = bookPagesView;
    }

    public void Initialize()
    {
        ActivateEvents();

        bookPagesView.Initialize();
    }

    public void Dispose()
    {
        DeactivateEvents();

        bookPagesView.Dispose();
    }

    private void ActivateEvents()
    {
        bookPagesModel.OnOpenPage += bookPagesView.OpenPage;
    }

    private void DeactivateEvents()
    {
        bookPagesModel.OnOpenPage -= bookPagesView.OpenPage;
    }

    #region Input

    public void OpenPage(int pageIndex)
    {
        bookPagesModel.OpenPage(pageIndex);
    }

    #endregion
}
