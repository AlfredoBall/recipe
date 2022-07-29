import s from '../Styles/Main.css'
import c from 'clsx'

import React from 'react';

import { Outlet } from 'react-router-dom';
import { Link } from 'react-router-dom';

import Header from '../../Components/Main/Header'
import Gallery from '../../Components/Main/Gallery'
import Planning from '../../Components/Main/Planning'

const Main = () => {

  return (
    <div className={c(s.main, 'container-fluid')}>
        <div className={c(s.header, 'sticky-top')}>
          <Header/>
        </div>
        <div className={c(s.content)}>
          <div className="row">
            <div className="col-8">
              <Gallery/>
            </div>
            <div className="col-4">
              <Planning/>
            </div>
          </div>
        </div>
    </div>
  );
}


export default Main;
