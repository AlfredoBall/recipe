import type { Recipe, Ingredient, PaginatedQuery } from '../State/Types'

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

interface IPlanningService {
    /**
     * Gets the Kitchen
     * @returns {Promise<Ingredient[]} - kitchen
     */
    getKitchen() : Promise<Ingredient[]>

    /**
     * @param kitchen - kitchen ingredients
     * @returns {Promise<Ingredient[]>} -  kitchen
     */
    createKitchen(kitchen: Ingredient[]) : Promise<Ingredient[]>

    /**
     * Gets the Grocery List
     * @returns {Promise<Ingredient[]} - grocery list
     */
    getGroceryList() : Promise<Ingredient[]>

    /**
     * @param groceryList - grocery list ingredients
     * @returns {Promise<string[]>} -  grocery list
     */
    createGroceryList(groceryList: Ingredient[]) : Promise<Ingredient[]>
}

export { IRecipeService, IPlanningService }