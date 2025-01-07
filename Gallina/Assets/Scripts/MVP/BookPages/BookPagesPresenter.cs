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

    }

    private void DeactivateEvents()
    {

    }
}
