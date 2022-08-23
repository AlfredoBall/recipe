import c from 'clsx'
import _ from 'lodash'
import React, { useState, useEffect } from 'react'
import { useAppSelector, useAppDispatch } from '../../App/Infrastructure/Hooks'
import { PlanningType } from '../../State/Types'
import ShoppingBasketIcon from '@mui/icons-material/ShoppingBasket';
import KitchenIcon from '@mui/icons-material/Kitchen';
import Ingredients from './Ingredients';
import { getGroceryList, createGroceryList, getKitchen, createKitchen } from '../../State/Planning'
import { DeleteButtonTemplate } from './Ingredients'

const Planning = () => {
    const dispatch = useAppDispatch();

    useEffect(() => {
        dispatch(getGroceryList())
    },[])

    useEffect(() => {
        dispatch(getKitchen())
    },[])

    const [activeTab, setActiveTab] = useState<PlanningType>("GroceryList") // Default
    const groceryList = useAppSelector(state => state.planning.groceryList)
    const kitchen = useAppSelector(state => state.planning.kitchen)

    return (
        <>
            <h2>Ingredient Plannings - Alfredo!</h2>
              <ul className="nav nav-tabs">
                <li className={c({active: activeTab === "GroceryList"})}>
                    <button onClick={() => setActiveTab("GroceryList")} data-bs-toggle="tooltip" data-bs-placement="top" title="Grocery List"><ShoppingBasketIcon/></button>
                </li>
                <li className={c({active: activeTab === "Kitchen"})}>
                    <button onClick={() => setActiveTab("Kitchen")} data-bs-toggle="tooltip" data-bs-placement="top" title="Kitchen"><KitchenIcon/></button>
                </li>
              </ul>

              <div className="tab-content">
                {/* Dispatch the full ingredient array because the store planning arrays will be overriden upon successful call to the API.
                    These actions are performed without a two step save confirmation */}
                <div id="grocery-list" className={c('tab-pane', { active: activeTab === "GroceryList"})}>
                    <Ingredients data-testid="grocery-list-ingredients"
                        onRemove={(ingredient) =>
                            dispatch(createGroceryList(groceryList.filter(x => x.text !== ingredient.text)))}
                        onAdd={(ingredient) => 
                            dispatch(createGroceryList(groceryList.concat(ingredient)))} ingredients={groceryList}/>
                </div>
                <div id="kitchen" className={c('tab-pane', { active: activeTab === "Kitchen"})}>
                    <Ingredients data-testid="kitchen-ingredients"
                        onRemove={(ingredient) =>
                            dispatch(createKitchen(kitchen.filter(x => x !== ingredient)))}
                        onAdd={(ingredient) => 
                            dispatch(createKitchen(kitchen.concat(ingredient)))} ingredients={kitchen}/>
                </div>
              </div>
        </>
    )
}

export default Planning