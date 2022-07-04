import React from 'react';
import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';

import { Recipe } from '../State/Types'

import styles from './Styles/GalleryItem.css'

const GalleryItem = ({ recipe, className }: { recipe : Recipe, className : string }) => {
    return (
        <div className={`${styles.gallery_item} ${className}`}>
            <div>{recipe.title}</div>
            <div>
                {recipe.imageData == null
                    // The modals will both have an image section but the wording will be different depending on if an image already exists
                    // They will both use the input type at the bottom to upload an image
                    // The modal will have the same component that varies slightly in the wording
                    // https://6-4-0--reactstrap.netlify.app/components/modals/
                    ? <AddPhotoAlternateIcon/>
                    : <img src={"data:image/png;base64, " + recipe.imageData}/>
                }
            </div>
            
            
        </div>
    )
}

export default GalleryItem