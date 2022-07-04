import './App.css';

import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

// import PublicRoutes from './Infrastructure/PublicRoutes'

import Main from '../Pages/Main/Main'

const App = () => {
  return (
    <Router>
      <Routes>
      <Route path="/" element={<Main/>}/>
          {/* child routes */}
      </Routes>
    </Router>
  );
}

export default App;
