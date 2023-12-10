import * as React from 'react';
import { Link } from 'react-router-dom';

import { getBookCategories } from '../../api';

import './navigation-bar.css';

/** Свойства компоненты. */
interface IBookProps {
  className: string;
}

/** Состояние компоненты. */
interface IBookState {
  data: Array<string>;
}

/** Компонент для навигации по категориям книг. */
export class NavigationBar extends React.Component<IBookProps, IBookState> {
  constructor(props: IBookProps) {
    super(props);
    this.state = { data:  [] };
  }

  /** Получаем товары, которые есть в наличии. */
  public async componentDidMount(): Promise<void> {
    try {
      const categories: Array<string> = await getBookCategories();
      this.setState({ data: categories });
    }
    catch (error) {
      alert(error.message);
    }
  }

  public render(): React.ReactNode {
    const categories: Array<string> = this.state.data;

    const links = categories.map(сategory => {
      const link = '/category/' + сategory;
      return (
        <Link
          key={сategory}
          className='navigation-bar__list_element'
          to={link}
        >
            {сategory}
        </Link>
      );
    });

    return (
      <div className={`navigation-bar ${this.props.className}`}>
        <h2 className='navigation-bar__list_header'>Категории:</h2>
        <div className='navigation-bar__list'>
          {links}
        </div>
      </div>
    );
  }
}