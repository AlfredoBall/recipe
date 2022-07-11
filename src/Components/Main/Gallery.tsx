import styles from '../Styles/Gallery.css'
import React, { useEffect } from 'react'

import querystring = require('querystring')

// import { Link } from 'react-router-dom'
import { Link, Outlet } from "react-router-dom";

import { useAppDispatch, useAppSelector } from '../../App/Infrastructure/Hooks'
import { getRecipes } from '../../State/Recipe'
import { Recipe } from '../../State/Types'

import GalleryItem from './GalleryItem'

const Gallery = () => {

    const dispatch = useAppDispatch();
    const recipes = useAppSelector(state => state.recipe.recipes);

    useEffect(() => {
        dispatch(getRecipes({
            searchTerm: '',
            page: 1,
            itemsPerPage: 10
        })).then(x => {
            console.log('inside UseEffect dispatch then')
            console.log(x)
        })
    }, [])

    // https://ui.dev/react-router-pass-props-to-link
    // https://github.com/mui/material-ui/issues/16846


    // TODO Use the GalleryItem compoenent
    const galleryItems = recipes.map((recipe) => <div key={recipe.id}>
            {/* <div>
                {Object.keys(recipe).map(key => key + '=' + recipe[key]).join('&')}
            </div> */}
            <Link to={{
                // pathname: `recipe/${Object.keys(recipe).map(key => key + '=' + recipe[key]).join('&')}`,
                // pathname: `recipe/?${Object.keys(recipe).map(key => key + '=' + recipe[key]).join('&')}`
                pathname: `/recipe/${recipe.id}`
                // search: `/recipe/${recipe.id}`
            }}>test0</Link>Alfredo</div>
    )
    
    return (
        <div className={styles.gallery}>
            {galleryItems}
        </div>
    )
}

export default Gallery