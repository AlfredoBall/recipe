import React from 'react'

import SearchBar from './SearchBar'

const Header = () => {
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
                    <button>Create New Recipe</button>
                </div>
            </div>
        </>
    )
}

export default Header