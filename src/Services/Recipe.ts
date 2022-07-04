/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'

import { Recipe, Instruction, PaginatedQuery } from "../State/Types"
import { IRecipeService } from "./Types"

class RecipeService implements IRecipeService {
    async getRecipes(request: PaginatedQuery): Promise<Recipe[]> {
        return (await axios.get('api/recipe', { params: request })).data;
    }

    async createRecipe(recipe: Recipe): Promise<Recipe> {
        return (await axios.post('api/recipe', recipe)).data;
    }
}

export default RecipeService;