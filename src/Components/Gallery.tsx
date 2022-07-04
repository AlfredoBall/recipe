import styles from './Styles/Gallery.css'
import React, { useEffect } from 'react'

import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

import { useAppDispatch, useAppSelector } from '../App/Infrastructure/Hooks'
import { getRecipes } from '../State/Recipe'

import GalleryItem from './GalleryItem'

const Gallery = () => {

    const dispatch = useAppDispatch();
    const recipes = useAppSelector(state => state.recipe.recipes);

    useEffect(() => {
        dispatch(getRecipes({
            searchTerm: '',
            page: 1,
            itemsPerPage: 10
        }))
    }, [])

    const galleryItems = recipes.map((recipe) => <GalleryItem className={styles['gallery-item']} recipe={recipe} key={recipe.id}/>)

    return (
        <div className={styles.gallery}>
            {galleryItems}
        </div>
    )
}

export default Gallery