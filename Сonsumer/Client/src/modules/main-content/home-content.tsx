import * as React from 'react';

require('modules/main-content/main-content.css');

/** Свойства компоненты. */
interface IHomeContentProps {
  className: string;
}

/** Домашняя страница. */
export function HomeContent(props: IHomeContentProps) {
  return <div className={`main-content ${props.className}`} />;
}