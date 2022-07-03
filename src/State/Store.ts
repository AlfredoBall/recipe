import { configureStore, AnyAction } from '@reduxjs/toolkit'
import thunk, { ThunkAction, ThunkDispatch } from 'redux-thunk';

import rootReducer from './Reducer';

export const store = configureStore({
  reducer: rootReducer
})

/* Types */
export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof rootReducer>;
export type TypedDispatch = ThunkDispatch<RootState, any, AnyAction>;
export type TypedThunk<ReturnType = void> = ThunkAction<
  ReturnType,
  RootState,
  unknown,
  AnyAction
>;