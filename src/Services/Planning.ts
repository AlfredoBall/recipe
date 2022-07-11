/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'

import { IPlanningService } from "./Types"
import { Ingredient } from '../State/Types'

class PlanningService implements IPlanningService {
    async getKitchen(): Promise<Ingredient[]> {
        return (await axios.get('api/planning/kitchen')).data;
    }

    async createKitchen(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post('api/planning/kitchen', ingredients)).data;
    }

    async getGroceryList(): Promise<Ingredient[]> {
        return (await axios.get('api/planning/grocerylist')).data;
    }

    async createGroceryList(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post('api/planning/grocerylist', ingredients)).data;
    }
}

export default PlanningService;