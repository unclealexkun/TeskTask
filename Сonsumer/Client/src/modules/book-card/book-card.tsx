import * as React from 'react';

import { IBook } from '../../types/book';

require('modules/book-card/book-card.css');

/** Изображение по умолчани. */
const defaultImage = '../images/book1.png';

/** Свойства компоненты. */
interface IBookCardProps {
  book: IBook;
  basketBookIds: Array<string> | null;
  onClick: (book: IBook) => void;
}

/** Карточка книги. */
export function BookCard(props: IBookCardProps) {

  /** Вызываем действие той кнопки из которой формы был вызов. */
  function handleClick() {
    props.onClick(props.book);
  }

  /** Определяем какое сообщение выводить в кнопке. */
  function getValue(ids: Array<string> | null, bookId: string): string {
    if (ids === null)
      return 'Удалить из корзины';
    if (ids.indexOf(bookId) === -1) {
      return 'Добавить в корзину';
    }
    else {
      return 'Удалить из корзины';
    }
  }

  const book = props.book;
  const bookAuthors = props.book.Authors.map(({ Name, Language }) => { '${Name}[${Language}]'}).join(';');
  const basketBookIds = props.basketBookIds;

  return (
    <div
      key={book.Id}
      className='book-card'
    >
      <img
        className='book-card__img'
        src={book.PathToPhoto === '' ? defaultImage : book.PathToPhoto}
      />
      <p className='book-card__description'>{book.Title}</p>
      <p className='book-card__description'>Категория: {book.Category}</p>
      <p className='book-card__description'>Автор: {bookAuthors}</p>
      <p className='book-card__description'>Дата публикации: {book.PublicationDate}</p>
      <p className='book-card__description'>Язык: {book.Language}</p>
      <p className='book-card__description'>Количество страниц: {book.Pages}</p>
      <p className='book-card__description'>Возрастной лимит: {book.AgeLimit}</p>
      <button
        className='book-card__button'
        onClick={handleClick}
      >
        {getValue(basketBookIds, book.Id)}
      </button>
    </div>);
}