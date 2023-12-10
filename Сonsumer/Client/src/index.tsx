import * as React from 'react';
import { render } from 'react-dom';
import { HashRouter } from 'react-router-dom';

import { Explorer } from './modules/explorer/explorer';

require('./styles/app.css');

render(
  <HashRouter hashType='noslash'>
    <Explorer />
  </HashRouter>,
  document.getElementById('root')
);
