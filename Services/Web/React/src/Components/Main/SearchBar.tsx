import React, { useState } from 'react'
import { useAppDispatch } from '../../App/Infrastructure/Hooks'

import SearchIcon from '@mui/icons-material/Search';

import { getRecipes } from '../../State/Recipe'

const SearchBar = (/* maybe pass in a value for itemsPerPage */) => {

    const [searchTerm, setSearchTerm] = useState<string>('');
    const dispatch = useAppDispatch();

    return (
        <div className="input-group">
            <div className="form-outline">
                <input value={searchTerm} data-testid="search-bar-input" id="form" type="search" className="form-control" placeholder='Search Recipe' onChange={e => setSearchTerm(e.target.value)}/>
            </div>
            <button data-testid="search-bar-button" type="button" className="btn btn-primary"
                onClick={() => {
                    dispatch(getRecipes({
                    searchTerm: searchTerm,
                    page: 1,
                    itemsPerPage: 10
                }))
                    setSearchTerm('')
                }}>
                <SearchIcon/>
            </button>
        </div>
    )
}

export default SearchBar