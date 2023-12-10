import * as React from 'react';
import { Link } from 'react-router-dom';

require('modules/header/header.css');

/** Свойства компоненты. */
interface IHeaderProps {
  className: string;
}

/** Окно заголовка заголовок */
export function Header(props: IHeaderProps) {
  return (
    <div className={`header ${props.className}`}>
      <img className='header__logo' src='../images/logo-face.svg' />
      <img className='header__logo' src='../images/logo-word.svg' />
      <Link className='header__link' to='/basket'>
        Корзина
      </Link>
    </div>
  );
}