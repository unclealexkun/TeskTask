import * as React from 'react';

import { Header } from '../header/header';
import { NavigationBar } from '../navigation-bar/navigation-bar';
import { RouterContent } from '../main-content/router-content';

require('modules/explorer/explorer.css');

/** Основной компонент для рисования окна. */
export function Explorer() {
  return (
    <div className='explorer'>
      <Header className='explorer__header' />
      <div className='explorer__wrapper'>
        <NavigationBar className='explorer__navigation-bar' />
        <RouterContent className='explorer__main-content' />
      </div>
    </div>
  );
}
