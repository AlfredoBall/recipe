import type { Recipe, PaginatedQuery } from '../State/Types'

interface IRecipeService {
    /**
     * Gets Recipes
     * @param request - paginated query
     * @returns {Promise<Recipe[]>} - recipes
     */
    getRecipes(request: PaginatedQuery) : Promise<Recipe[]>

    /**
     * Creates a Recipe
     * @param recipe - new recipe
     * @returns {Promise<Recipe>} - created recipe
     */
    createRecipe(recipe: Recipe) : Promise<Recipe>
}

export { IRecipeService }