/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'

import { Recipe, PaginatedQuery } from "../State/Types"
import { IRecipeService } from "./Types"

const config = window._env_;

class RecipeService implements IRecipeService {
    async getRecipes(request: PaginatedQuery): Promise<Recipe[]> {
        return (await axios.get(`${config.BASE_URL}/recipe`, { params: request })).data;
    }

    // Override this based on title
    async createRecipe(recipe: Recipe): Promise<Recipe> {
        return (await axios.post(`${config.BASE_URL}/recipe`, recipe)).data;
    }
}

export default RecipeService;