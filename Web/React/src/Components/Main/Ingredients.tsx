import s from '../Styles/Ingredients.css'
import c from 'clsx'
import React, { useState, ElementType, Component, ReactNode } from 'react'
import _ from 'lodash'

import { Ingredient } from '../../State/Types'

import '../../Fonts/Thin_Pencil_Handwriting.ttf'

const Ingredients = (
    {       isReadOnly = false,
            ingredients = [],
            onRemove = () => undefined,
            onAdd = () => undefined,
            DeleteButtonTemplate} : { 
        isReadOnly? : boolean,
        ingredients : Ingredient[], 
        onRemove? : (ingredient: Ingredient) => void,
        onAdd? : (ingredient: Ingredient) => void,
        DeleteButtonTemplate? : ElementType // Maybe get this working
        }) => {

    const [newIngredient, setNewIngredient] = useState<string>('');

    return (
        <>
            {/* {DeleteButtonTemplate !== undefined ? DeleteButtonTemplate : undefined} // Doesn't work well, maybe look into https://www.npmjs.com/package/@bem-react/core */}
            {ingredients.map((ingredient, i) =>
                <div key={i} className={c(s['ingredient-item'])}>
                    <li className={c(s['font-pencil'])}>{ingredient.text}</li>
                    {!isReadOnly ? <button onClick={() => onRemove(ingredient)}>Remove</button> : undefined }
                </div>
            )}
            {!isReadOnly ?
                <li className={c(s['ingredient-item-new'])}>
                    <input type="text" value={newIngredient} onChange={e => setNewIngredient(e.target.value)}/>
                    <button disabled={
                            newIngredient.length === 0 ||
                            // dedupe
                            _.includes(ingredients.map(x => x.text.toLowerCase()), newIngredient.toLowerCase()) as boolean
                        }
                            onClick={() => {
                                onAdd({ text: newIngredient });
                                setNewIngredient('');
                            }
                        }
                    >Add</button>
                </li> :
                undefined
            }
        </>
    )
}

export default Ingredients;

type Props = {
    onToggle: (on: boolean) => void,
    children: (api: API) => ReactNode
}

type API = ReturnType<DeleteButtonTemplate['getAPI']>

type State = Readonly<typeof initialState>
const initialState = { on: false}

// https://github.com/DefinitelyTyped/DefinitelyTyped/issues/18051

export class DeleteButtonTemplate extends Component<Props, State> {
    public state = initialState

    public toggle = () =>
        this.setState(
            ({ on }) => ({ on: !on }),
            () => this.props.onToggle(this.state.on)
        )

    private getAPI() {
        return {
            on: this.state.on,
            toggle: this.toggle,
        }
    }

    render() {
        const { children } = this.props
        if(!isFunction(children)) {
            throw new Error("");
        }

        console.log("DeleteButtonTemplate render");

        return children(this.getAPI())
    }
}

type IsFunction<T> = T extends (...args: any[]) => any ? T : never

const isFunction = <T extends {}>(value: T): value is IsFunction<T> => typeof value === 'function'