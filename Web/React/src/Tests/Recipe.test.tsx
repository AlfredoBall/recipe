/**
 * @jest-environment jsdom
 */

import React from 'react'
import { act } from 'react-dom/test-utils'
import { faker } from '@faker-js/faker'

import { rest } from 'msw'
import { setupServer } from 'msw/node'

import { fireEvent, screen, within } from '@testing-library/react'
import { renderWithProviders } from './Test.utils'

import { RootState, setupStore } from '../State/Store'

import Gallery from '../Components/Main/Gallery'
import SearchBar from '../Components/Main/SearchBar'
import Planning from '../Components/Main/Planning'

export const initialHandlers = [
  rest.get('/api/recipe', (req, res, ctx) => {
    console.log('api/recipe handler is called')
    return res(ctx.json(
      [
        {
          id: faker.datatype.uuid(),
          title: 'Apple Pie',
          ingredients: ["apples"],
          instructions: [
            {
              order: 1,
              text: "Bake"
            }
          ]
        }
      ]
    ), ctx.delay(150))
  }),
  rest.post('/api/recipe', (req, res, ctx) => {
    return res(ctx.json(
      {...req.params, 
        id: faker.datatype.uuid()
      }
    ))
  }),
  rest.get('/api/planning/kitchen', (req, res, ctx) => {
      return res(ctx.json(
          [
              "Meat"
          ]
      ), ctx.delay(150))
  }),
  rest.post('/api/planning/kitchen', (req, res, ctx) => {
      return res(ctx.json(
          req.params
      ), ctx.delay(150))
  }),
  rest.get('/api/planning/groceryList', (req, res, ctx) => {
      return res(ctx.json(
          [
              "Meat"
          ]
      ), ctx.delay(150))
  }),
  rest.post('/api/planning/groceryList', (req, res, ctx) => {
      return res(ctx.json(
          req.params
      ), ctx.delay(150))
  })
]

const server = setupServer(...initialHandlers)

beforeAll(() => server.listen())
afterEach(() => server.resetHandlers())
afterAll(() => server.close())

describe.skip("Recipe Tests", () => {
  test.skip('Should get recipes and populate the store when Gallery is loaded', async () => {
    const store = setupStore();

    renderWithProviders(<Gallery/>, { store });

    const promise = new Promise<RootState>(function(resolve) {    
      store.subscribe(() => {
        const state = store.getState();
        
        resolve(state);
      })
    });

    await act(async () => {
      await promise.then((result: RootState) => {
        console.log('inside promise result');
        console.log(result);
        expect(result.recipe.recipes.length).toBe(1);
      })
    })
  })

  test(`Should get recipes when the search bar button is clicked.
        The search term is not tested because that logic will exists on the API`, async () => {

    server.use(
      rest.get('/api/recipe', (req, res, ctx) => {
        return res.once(ctx.json(
          [
            {
              id: faker.datatype.uuid(),
              title: 'Apple Pie',
              ingredients: ["apples"],
              instructions: [
                {
                  order: 1,
                  text: "Bake"
                }
              ]
            }
          ]
        ), ctx.delay(150))
      })
    )

    const store = setupStore();

    renderWithProviders(<SearchBar/>, { store });

    const searchBarInput = screen.getByTestId('search-bar-input');
    const searchBarButton = screen.getByTestId('search-bar-button');

    expect(store.getState().recipe.recipes.length).toBe(0);

    fireEvent.change(searchBarInput, {target: {value: 'Apple'}});
    fireEvent.click(searchBarButton);

    const promise = new Promise<RootState>(function(resolve) {    
      store.subscribe(() => {
        const state = store.getState();

        resolve(state);
      })
    });
    
    await act(async () => {
      await promise.then((result: RootState) => {
        expect(result.recipe.recipes.length).toBe(1);
      })
    })
  })
})

describe("Planning Tests", () => {
  test.skip("Should get kitchen and groceryList ingredients when Planning is loaded", async () => {
    // Since two async calls are made and we can't use specific store property selectors, it just waits slightly longer than specified by the mock API to return data
      const store = setupStore();

      renderWithProviders(<Planning/>, { store });

      const promise = new Promise(resolve => setTimeout(resolve, 200));

      await act(async () => {
          await promise.then(() => {
              const state = store.getState();

              expect(state.planning.groceryList.length).toBe(1);
              expect(state.planning.kitchen.length).toBe(1);
          })
      })
  })

  test("Should remove an ingredient from the grocery list when the remove user action is performed", async () => {
    const store = setupStore();

      const planningEl = renderWithProviders(<Planning/>, { store });

      const promise = new Promise(resolve => setTimeout(resolve, 200));

      await act(async () => {
        await promise.then(() => {

            const groceryListIngredients = planningEl.getByTestId("grocery-list-ingredients");

            const firstGroceryListIngredientItem = within(groceryListIngredients).getByTestId("delete-0");
            
            console.log(firstGroceryListIngredientItem);
            expect(1).toBe(0);
        })
      })
    })
})