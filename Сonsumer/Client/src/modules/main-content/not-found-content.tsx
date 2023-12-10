import * as React from 'react';

require('modules/main-content/main-content.css');

/** Свойства компоненты. */
interface INotFoundContentProps {
  className: string;
}

/** Страница на случай неправильного перехода по адресу. */
export function NotFoundContent(props: INotFoundContentProps) {
  return (
    <div className={`main-content ${props.className}`}>
      <h2 className='main-content__header'>Ресурс не найден</h2>
      <img className='main-content__img' src='../images/not-found.png' />;
    </div>
  );
}