import React from 'react'

import SearchBar from './SearchBar'

const Header = () => {
    return (
        <>
            <div className="row">
                <div className="col-10">
                    Home Page
                </div>
                <div className="col-2">
                    Profile and Settings
                </div>
            </div>
            <div className="row">
                <div className="col-10">
                    <SearchBar/>
                </div>
            </div>
        </>
    )
}

export default Header