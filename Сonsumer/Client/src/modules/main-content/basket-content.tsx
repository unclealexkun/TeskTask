import * as React from 'react';

import { IBook } from '../../types/book';
import { removeBasketBook, getBasketBooks } from '../../api';
import { BookCard } from '../book-card/book-card';

require('../main-content/main-content.css');

/** Свойства компоненты. */
interface IBasketProps {
  className: string;
}

/** Состояние компоненты. */
interface IBasketState {
  basket: Array<IBook>;
}

/** Компонент отображения книг в корзине. */
export class BasketContent extends React.Component<IBasketProps, IBasketState> {
  constructor(props: IBasketProps) {
    super(props);
    this.state = {
      basket: [{
        Id: '', Title: '', Category: '', Authors: [{ Name: '', Language: '' }],
        PublicationDate: 0, Language: '', Pages: 0, AgeLimit: 0, PathToPhoto: ''
      }]
    };
    this.handleClick = this.handleClick.bind(this);
  }

  /** Получаем содержимое корзины. */
  public async componentDidMount(): Promise<void> {
    const books: Array<IBook> = await getBasketBooks();
    this.setState({ basket: books });
  }

  /** Обработка события нажатия кнопки: Удаляем книгу из корзины. */
  private async handleClick(book: IBook): Promise<void> {
    try {
      const basket: Array<IBook> = this.state.basket;
      const isDel: boolean = await removeBasketBook(book.Id);
      if (!isDel) {
        alert('Товар не был удалён из корзины.');
      }
      else {
        const index: number = basket.indexOf(book);
        basket.splice(index, 1);
        this.setState({ basket: basket });
      }
    }
    catch (error) {
      alert(error.message);
    }
  }

  public render(): React.ReactNode {
    const basket: Array<IBook> = this.state.basket;
    const items = basket.map(book => {
      return (
        <BookCard key={book.Id} book={book} basketBookIds={null} onClick={this.handleClick} />
      );
    });

    return (
      <div className={`main-content ${this.props.className}`}>
        <h2 className='main-content__header'>Корзина:</h2>
        <div className='main-content__products'>
          {items}
        </div>
      </div>
    );
  }
}