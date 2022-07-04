type Instruction = {
    order: number,
    text: string
}

type Recipe = {
    id: string,
    title: string,
    imageData?: string,
    ingredients: string[],
    instructions: Instruction[]
}

type PaginatedQuery = {
    page: number,
    itemsPerPage: number,
    searchTerm: string
}

type State = {
    recipes: Recipe[]
}

export { Recipe, Instruction, PaginatedQuery, State };