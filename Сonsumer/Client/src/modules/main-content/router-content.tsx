import * as React from 'react';
import { Route, Switch } from 'react-router-dom';

import MainContent from './main-content';
import { BasketContent } from './basket-content';
import { HomeContent } from './home-content';
import { NotFoundContent } from './not-found-content';

require('modules/main-content/main-content.css');

/** Свойства компоненты. */
interface IRouterContentProps {
  className: string;
}

export function RouterContent(props: IRouterContentProps) {
  return (
    <Switch>
        <Route exact={true} path='/'>
          <HomeContent className={props.className} />
        </Route>
        <Route exact={true} path='/category/:category'>
          <MainContent className={props.className} />
        </Route>
        <Route exact={true} path='/basket' >
          <BasketContent className={props.className} />
        </Route>
        <Route >
          <NotFoundContent className={props.className}/>
        </Route>
    </Switch>
  );
}