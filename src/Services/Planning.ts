/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'

import { IPlanningService } from "./Types"
import { Ingredient } from '../State/Types'

class PlanningService implements IPlanningService {
    async getKitchen(): Promise<Ingredient[]> {
        return (await axios.get('https://localhost:7250/api/planning/kitchen')).data;
    }

    async createKitchen(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post('https://localhost:7250/api/planning/kitchen', ingredients)).data;
    }

    async getGroceryList(): Promise<Ingredient[]> {
        return (await axios.get('https://localhost:7250/api/planning/grocerylist')).data;
    }

    async createGroceryList(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post('https://localhost:7250/api/planning/grocerylist', ingredients)).data;
    }
}

export default PlanningService;