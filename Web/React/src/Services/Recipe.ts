/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'

import { Recipe, PaginatedQuery } from "../State/Types"
import { IRecipeService } from "./Types"

class RecipeService implements IRecipeService {
    async getRecipes(request: PaginatedQuery): Promise<Recipe[]> {
        return (await axios.get('https://localhost:7250/api/recipe', { params: request })).data;
    }

    // Override this based on title
    async createRecipe(recipe: Recipe): Promise<Recipe> {
        return (await axios.post('https://localhost:7250/api/recipe', recipe)).data;
    }
}

export default RecipeService;