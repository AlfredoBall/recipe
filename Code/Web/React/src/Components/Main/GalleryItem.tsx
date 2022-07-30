import React from 'react';
import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';

import { Recipe } from '../../State/Types'

import styles from '../Styles/GalleryItem.css'

import Ingredients from './Ingredients'

const GalleryItem = ({ recipe }: { recipe : Recipe}) => {
    return (
        <div className={styles['gallery-item']}>
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
                <Ingredients data-testid="gallery-item-ingredients"
                    isReadOnly={true} // TODO Make Ingredients blow up if the onAdd and onRemove inputs aren't provided and isReadOnly remains defaulted to false - low priority
                    ingredients={recipe.ingredients}/>
            </div>
            
            
        </div>
    )
}

export default GalleryItem