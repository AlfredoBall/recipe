import './App.css';

import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

import RecipeEdit from '../Pages/Recipe/RecipeEdit'

// import PublicRoutes from './Infrastructure/PublicRoutes'

import Main from '../Pages/Main/Main'

const App = () => { 
  return (
    <Router>
      <Routes>
        {/* // Map ownProperties */}
        <Route exact path="/recipe/:id" element={<RecipeEdit/>}></Route>
        <Route exact path="/recipe/edit" element={<RecipeEdit/>}></Route> {/* Make this explicit */}
        <Route path="/" element={<Main/>}/>
        {/* https://thewebdev.info/2022/03/07/how-to-pass-parameters-to-component-with-react-router/ */}
        {/* https://dev.to/javila35/react-router-hook-useparam-now-w-typescript-m93 */}

        
            {/* child routes */}
      </Routes>
    </Router>
  );
}

export default App;
