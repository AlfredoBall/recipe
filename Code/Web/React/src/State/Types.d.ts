type PlanningType = "GroceryList" | "Kitchen"

type Instruction = {
    order: number,
    text: string
}

type Ingredient = {
    text: string
}

type Recipe = {
    id: string,
    title: string,
    imageData?: string,
    // Add an image type?
    ingredients: Ingredient[],
    instructions: Instruction[]
}

type PaginatedQuery = {
    page: number,
    itemsPerPage: number,
    searchTerm: string
}

type Planning = {
    kitchen: Ingredient[],
    groceryList: Ingredient[]
}

type State = {
    recipes: Recipe[],
    planning: Planning
}

export { Recipe, Instruction, Ingredient, PlanningType, PaginatedQuery, State };