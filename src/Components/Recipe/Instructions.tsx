import s from '../Styles/Ingredients.css'
import c from 'clsx'
import React, { useState } from 'react'
import _ from 'lodash'

import { Instruction } from '../../State/Types'

import '../../Fonts/Thin_Pencil_Handwriting.ttf'

const Instructions = (
    {       isReadOnly = false,
            instructions = [],
            onRemove = () => undefined,
            onAdd = () => undefined} : { 
        isReadOnly? : boolean,
        instructions : Instruction[], // These should be sorted
        onRemove? : (instruction: Instruction) => void,
        onAdd? : (instruction: Instruction) => void
        }) => {

    const [newInstruction, setNewInstruction] = useState<Instruction>({
        order: -1,
        text: ''
    });

    return (
        <>
            <ol type="1">
                {instructions.map((instruction, i) =>
                    <li key={instruction.text} className={c(s['instruction-item'])}>
                        <div  className={c(s['font-pencil'])}>{instruction.text}</div>
                        {!isReadOnly ? <button onClick={() => onRemove(instruction)}>Remove</button> : undefined }
                    </li>
                )}
            </ol>
            {!isReadOnly ?
                <li className={c(s['ingredient-item-new'])}>
                    <input type="text" value={newInstruction.text} onChange={e => setNewInstruction({
                        order: instructions.length,
                        text: e.target.value
                    })}/>
                    <button disabled={
                            newInstruction?.text.length === 0 ||
                            // dedupe
                            _.includes(instructions.map(x => x.text), newInstruction.text.toLowerCase()) as boolean
                        }
                            onClick={() => {
                                onAdd(newInstruction);
                                setNewInstruction({
                                    order: -1,
                                    text: ''
                                });
                            }
                        }
                    >Add</button>
                </li> :
                undefined
            }
        </>
    )
}

export default Instructions;