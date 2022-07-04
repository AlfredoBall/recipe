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
      state.recipes = action.payload;
      return state;
    })
    .addCase(createRecipe.fulfilled, (state, action) => {
      state.recipes.push(action.payload);
      return state;
    })
  },
})

export { getRecipes, createRecipe };
export default recipeSlice.reducer