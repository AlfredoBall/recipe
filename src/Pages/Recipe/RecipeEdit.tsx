// https://blog.logrocket.com/react-form-validation-sollutions-ultimate-roundup/

import React, { useCallback, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import { Formik, Form, Field, ErrorMessage } from "formik"; // Ugh I hate forms but I guess it makes the most sense here

import _ from 'lodash'

import s from '../Styles/RecipeEdit.css'
import c from 'clsx'

import { Recipe } from '../../State/Types'
import { useAppSelector, useAppDispatch } from '../../App/Infrastructure/Hooks'

import Ingredients from '../../Components/Main/Ingredients'
import Instructions from '../../Components/Recipe/Instructions'

import AddPhotoAlternateIcon from '@mui/icons-material/AddPhotoAlternate';
import { createRecipe } from '../../State/Recipe'

// Why does this page emit this error?
// react_devtools_backend.js:4026 Warning: You provided a `value` prop to a form field without an `onChange` handler. This will render a read-only field. If the field should be mutable use `defaultValue`. Otherwise, set either `onChange` or `readOnly`.

const RecipeEdit = () => {
    const {
        id
    } = useParams()

    const dispatch = useAppDispatch();
    const navigate = useNavigate();

    const recipes = useAppSelector<Recipe[]>(state => state.recipe.recipes)
    // TODO What if no ID is passed in?
    const recipe = useCallback(() => { // It's ok if the template uses this directly, let's see if it get updated
        // TODO rewrite this for bookmarks
        console.log('inside useCallback')
        if (id === undefined) {
            return {
                id: '',
                title: '',
                imageData: undefined,
                ingredients: [],
                instructions: []
            }
        } else {
            return _.find(recipes, (r : Recipe) => r.id.toString() === id)
        }
    }, recipes)() as Recipe

    const [state, setState] = useState<Recipe>(recipe)
    const [selectedFile, setSelectedFile] = useState<File>()

    console.log(state)
    // useEffect(() => {
    //     recipe = // Feature Request: This should perform a search if state.recipe.recipes isn't populated yet in case the url is bookmarked
    // }, [?])

    // On file select (from the pop up)
    const onFileChange = event => {
        setSelectedFile(event.target.files[0])
    };

    const onFileUpload = () => {

        const reader = new FileReader();
        reader.addEventListener("load", function () {
            setState({...state, ...{
                imageData: reader.result as string
            }})
        }, false);

        reader.readAsDataURL(selectedFile as File);

        // const formData = new FormData();
      
        // formData.append(
        //   "myFile",
        //   selectedFile ?? '',
        //   selectedFile?.name
        // );
      
        // // Details of the uploaded file
        // console.log(selectedFile);
      
        // TODO
        // Request made to the backend api
        // Send formData object
        // axios.post("api/uploadfile", formData);
    };

    const fileData = () => {
        if (selectedFile) {
            return (
                <div>
                    <h2>File Details:</h2>
                
                    <p>File Name: {selectedFile.name}</p>
                    
                                
                    <p>File Type: {selectedFile.type}</p>
        
                </div>
            );
        } else {
            return (
                <div>
                    <br />
                    <h4>Choose before Pressing the Upload button</h4>
                </div>
            );
        }
        };

    return (
        <>
            <h3>Recipe Design</h3>
            <div className="container-fluid">
                <div className="row">
                    <div className="col-12">
                        <input type="text" value={state.title}/>
                    </div>
                </div>
                <div className="row">
                    <div className={c(s["saving-options"], "col-12 ")}>
                        <button>Discard</button>
                        <button onClick={() => dispatch(createRecipe(state)).then(() => navigate('/'))}>Save</button>
                    </div>
                </div>
                <div className="row">
                    <div className="col-6">
                        {state.imageData === undefined || state.imageData === null
                            ? <div>
                                <div>
                                    <input type="file" onChange={onFileChange} />
                                    <button onClick={onFileUpload}>
                                    Upload!
                                    </button>
                                </div>
                                {fileData()}
                            
                                <AddPhotoAlternateIcon/>
                            </div>
                            :   <div>
                                    <button onClick={() => setState({...state, ...{imageData : undefined}})}>X</button>
                                    <img className={c(s['recipe-img'])} src={state.imageData} alt={selectedFile?.name}/>
                                </div>
                        }
                        Ingredients
                        <Ingredients
                            ingredients={state.ingredients}
                            onRemove={(ingredient) =>
                                setState({...state, ...{ingredients: state.ingredients.filter(x => x !== ingredient)}})
                            }
                            onAdd={(ingredient) =>
                                setState({...state, ...{ingredients: state.ingredients.concat(ingredient)}})}
                                isReadOnly={false}/>
                    </div> 
                    <div className="col-6">
                        Instructions
                        <Instructions
                            instructions={state.instructions}
                            onRemove={(instruction) =>
                                setState({...state, ...{instructions: state.instructions.filter(x => x.text !== instruction.text)}})
                            }
                            onAdd={(instruction) =>
                                setState({...state, ...{instructions: state.instructions.concat(instruction)}})}
                                isReadOnly={false}/>
                    </div>
                    
                </div>
            </div>
        </>
    )
}

export default RecipeEdit