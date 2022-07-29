import { createAsyncThunk, createSlice } from '@reduxjs/toolkit'

import RecipeService from '../Services/Recipe';
import { Recipe, PaginatedQuery } from '../State/Types'

const getRecipes = createAsyncThunk(
  "recipe/get",
  async (request: PaginatedQuery) => {
    return await new RecipeService().getRecipes(request);
  }
)

const createRecipe = createAsyncThunk(
  "recipe/create",
  async (recipe: Recipe) => {
    return await new RecipeService().createRecipe(recipe);
  }
)

const initialState = {
  recipes: [] as Recipe[]
}

const recipeSlice = createSlice({
  name: 'recipe',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
    .addCase(getRecipes.fulfilled, (state, action) => {
      console.log('inside getRecipies fulfilled');
      console.log(action.payload);
      state.recipes = action.payload;
      return state;
    })
    .addCase(createRecipe.fulfilled, (state, action) => {
      const index = state.recipes.findIndex(x => x.title === action.payload.title);
      if (index !== -1) {
        state.recipes[index] = action.payload
      } else {
        state.recipes.push(action.payload);
      }
      
      return state;
    })
  },
})

export { getRecipes, createRecipe };
export default recipeSlice.reducer