import { configureStore, combineReducers, PreloadedState } from '@reduxjs/toolkit'
import thunk, { ThunkAction, ThunkDispatch } from 'redux-thunk';

import recipe from './Recipe'
import planning from './Planning'

const rootReducer = combineReducers({
    recipe,
    planning
});

export const store = configureStore({
  reducer: rootReducer
})

export function setupStore(preloadedState?: PreloadedState<RootState>) {
  return configureStore({
    reducer: rootReducer,
    preloadedState
  })
}

/* Types */
export type RootState = ReturnType<typeof rootReducer>
export type AppStore = ReturnType<typeof setupStore>
export type AppDispatch = AppStore['dispatch']