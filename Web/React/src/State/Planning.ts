import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'

import PlanningService from '../Services/Planning';

import { Ingredient } from '../State/Types'

const getKitchen = createAsyncThunk(
  "kitchen/get",
  async () => {
    return await new PlanningService().getKitchen();
  }
)

const createKitchen = createAsyncThunk(
  "kitchen/create",
  async (ingredients: Ingredient[]) => {
    return await new PlanningService().createKitchen(ingredients);
  }
)

const getGroceryList = createAsyncThunk(
  "groceryList/get",
  async () => {
    return await new PlanningService().getGroceryList();
  }
)

const createGroceryList = createAsyncThunk(
  "groceryList/create",
  async (ingredients: Ingredient[]) => {
    return await new PlanningService().createGroceryList(ingredients);
  }
)

const initialState = {
  groceryList: [] as Ingredient[],
  kitchen: [] as Ingredient[]
}

const planningSlice = createSlice({
  name: 'planning',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
    .addCase(getKitchen.fulfilled, (state, action) => {
      state.kitchen = action.payload;
      return state;
    })
    .addCase(createKitchen.fulfilled, (state, action) => {
      state.kitchen = action.payload;
      return state;
    })
    .addCase(getGroceryList.fulfilled, (state, action) => {
      state.groceryList = action.payload;
      return state;
    })
    .addCase(createGroceryList.fulfilled, (state, action) => {
      state.groceryList = action.payload;
      return state;
    })
  },
})

export { getKitchen, createKitchen, getGroceryList, createGroceryList };
export default planningSlice.reducer