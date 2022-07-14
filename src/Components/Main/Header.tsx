import React from 'react'
import { useNavigate } from 'react-router-dom'

import SearchBar from './SearchBar'

const Header = () => {
    const navigate = useNavigate();
    return (
        <>
            <div className="row">
                <div className="col-8">
                    Home Page
                </div>
                <div className="col-4">
                    Profile and Settings
                </div>
            </div>
            <div className="row">
                <div className="col-8">
                    <SearchBar/>
                </div>
                <div className="col-4">
                    <button onClick={() => navigate("recipe/edit")}>Create New Recipe</button>
                </div>
            </div>
        </>
    )
}

export default Header