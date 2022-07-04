import s from '../Styles/Main.css'
import c from 'clsx'

import React from 'react';

import { Outlet } from 'react-router-dom';
import { Link } from 'react-router-dom';

import Header from '../../Components/Main/Header'
import Gallery from '../../Components/Gallery'

const Main = () => {

  return (
    <div className={c(s.main, 'container-fluid')}>
        <div className={c(s.header, 'sticky-top')}>
          <Header/>
        </div>
        <div className={c(s.content)}>
          <div className="row">
            <div className="col">
              Test 1
            </div>
            <div className="col">
              Test 2
            </div>
          </div>
          <div className="row">
            <div className="col">
              Test 1
            </div>
          </div>
          <div className="row">
            <div className="col">
              Test 1
            </div>
          </div>
        </div>
    </div>
  );
}


export default Main;
