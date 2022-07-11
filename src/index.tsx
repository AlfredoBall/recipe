import React from 'react';
import { Provider } from 'react-redux'
import { createRoot } from 'react-dom/client';

import './index.css';
import App from './App/App';
import { store } from './State/Store';


const container = document.getElementById('root') as HTMLElement;
const root = createRoot(container);

root.render(
  <Provider store={store}>
    <App />
  </Provider>
);