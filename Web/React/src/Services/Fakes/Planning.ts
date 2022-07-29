import { IPlanningService } from '../Types'

import { Ingredient } from '../../State/Types'

export default class FakePlanningService implements IPlanningService {
    async getKitchen() : Promise<Ingredient[]> {
        return Promise.resolve(kitchenIngredients);
    }

    async createKitchen(ingredients: Ingredient[]) : Promise<Ingredient[]> {
        return Promise.resolve(ingredients);
    }

    async getGroceryList() : Promise<Ingredient[]> {
        return Promise.resolve(groceryListIngredients);
    }

    async createGroceryList(ingredients: Ingredient[]) : Promise<Ingredient[]> {
        return Promise.resolve(ingredients);
    }
}

const groceryListIngredients = [
    {
        text: "Celery"
    },
    {
        text: "Tomatoes"
    },
    {
        text: "Bread"
    },
] as Ingredient[]

const kitchenIngredients = [
    {
        text: "Butter"
    },
    {
        text: "Crackers"
    },
    {
        text: "Juice"
    },
] as Ingredient[]