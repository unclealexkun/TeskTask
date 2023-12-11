import * as React from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';

import { IBook } from '../../types/book';
import { addBasketBook, getBasketBooks, getBooksByCategory, removeBasketBook } from '../../api';
import { BookCard } from '../book-card/book-card';

require('modules/main-content/main-content.css');

interface ICategory {
  category: string;
}

/** Свойства компоненты. */
interface IMainContentProps extends RouteComponentProps<ICategory>{
  className: string;
}

/** Состояние компоненты. */
interface IMainContentState {
  books: Array<IBook>;
  basketBookIds: Array<string>;
}

/** Компонент отображения книг по категориям. */
class MainContent extends React.Component<IMainContentProps, IMainContentState> {
  constructor(props: IMainContentProps) {
    super(props);
    this.state = {
      books: [{
        Id: '', Title: '', Category: '', Authors: [{ Name: '', Language: '' }],
        PublicationDate: 0, Language: '', Pages: 0, AgeLimit: 0, PathToPhoto: ''
      }],
      basketBookIds: ['']
    };
    this.handleClick = this.handleClick.bind(this);
  }

  /** Загружаем содержимое корзины и книги по категории в первый раз. */
  public async componentDidMount(): Promise<void> {
    const category: string = this.props.match.params.category;
    const booksByCategory: Array<IBook> = await getBooksByCategory(category);
    const baskets: Array<IBook> = await getBasketBooks();

    const bookIds: Array<string> = baskets.map(book => book.Id);
    this.setState({
      books: booksByCategory,
      basketBookIds: bookIds
    });
  }

  /** Загружаем содержимое корзины и книг по категории при обновлении категории. */
  public async componentDidUpdate(prevProps: IMainContentProps): Promise<void> {
    if (this.props.match.params.category !== prevProps.match.params.category) {
      const category: string = this.props.match.params.category;
      const booksByCategory: Array<IBook> = await getBooksByCategory(category);
      const baskets: Array<IBook> = await getBasketBooks();

      const bookIds: Array<string> = baskets.map(book => book.Id);
      this.setState({
        books: booksByCategory,
        basketBookIds: bookIds
      });
    }
  }

  /** Обработка нажатия на кнопку: Добавляем или удаляем книги из корзины. */
  private async handleClick(book: IBook): Promise<void> {
    try {
      const basketBookIds: Array<string> = this.state.basketBookIds;
      const index = basketBookIds.indexOf(book.Id);

      if (index === -1) {
        const isAdd: boolean = await addBasketBook(book);
        if (isAdd) {
          basketBookIds.push(book.Id);
        }
      }
      else {
        const isDel: boolean = await removeBasketBook(book.Id);
        if (isDel) {
          basketBookIds.splice(index, 1);
        }
      }

      this.setState({ basketBookIds: basketBookIds });
    }
    catch (error) {
      alert(error.message);
    }
  }

  public render(): React.ReactNode {
    const books = this.state.books;
    const basketBookIds = this.state.basketBookIds;
    const items = books.map(book => {
      return (
        <BookCard key={book.Id} book={book} basketBookIds={basketBookIds} onClick={this.handleClick} />
      );
    });

    return (
      <div className={`main-content ${this.props.className}`}>
        <h2 className='main-content__header'>Категории "{this.props.match.params.category}":</h2>
        <div className='main-content__books'>
          {items}
        </div>
      </div>
    );
  }
}

export default withRouter(MainContent);
