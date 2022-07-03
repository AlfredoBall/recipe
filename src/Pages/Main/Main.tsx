import React from 'react';

import { Outlet } from 'react-router-dom';
import { Link } from 'react-router-dom';

const Main = () => {
  return (
    <div>
      <div>Hi</div>
      <Outlet/>
    </div>
  );
}


export default Main;
