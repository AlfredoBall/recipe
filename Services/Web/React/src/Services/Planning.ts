/* eslint-disable @typescript-eslint/no-unused-vars */

import axios from 'axios'
import config from '../config.json'

import { IPlanningService } from "./Types"
import { Ingredient } from '../State/Types'

class PlanningService implements IPlanningService {
    async getKitchen(): Promise<Ingredient[]> {
        return (await axios.get(`${config.BASE_URL}/planning/kitchen`)).data;
    }

    async createKitchen(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post(`${config.BASE_URL}/planning/kitchen`, ingredients)).data;
    }

    async getGroceryList(): Promise<Ingredient[]> {
        return (await axios.get(`${config.BASE_URL}/planning/groceryList`)).data;
    }

    async createGroceryList(ingredients: Ingredient[]): Promise<Ingredient[]> {
        return (await axios.post(`${config.BASE_URL}/planning/groceryList`, ingredients)).data;
    }
}

export default PlanningService;