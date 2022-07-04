/**
 * @jest-environment jsdom
 */

//https://redux.js.org/usage/writing-tests

import React from 'react'
import { act } from 'react-dom/test-utils'
import { faker } from '@faker-js/faker'

import { rest } from 'msw'
import { setupServer } from 'msw/node'
import { fireEvent, screen } from '@testing-library/react'
import { renderWithProviders } from './Test.utils'

import { RootState, setupStore } from '../State/Store'

import Gallery from '../Components/Gallery'
import SearchBar from '../Components/Main/SearchBar'

export const initialHandlers = [
  rest.get('/api/recipe', (req, res, ctx) => {
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
  })
]

const server = setupServer(...initialHandlers)

// Enable API mocking before tests.
beforeAll(() => server.listen())
afterEach(() => server.resetHandlers())
afterAll(() => server.close())

describe("Recipe Tests", () => {
  test('Should get recipes and populate the store when Gallery is loaded', async () => {
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
        expect(result.recipe.recipes.length).toBe(1);
      })
    })
  })

  test("Should get recipes filtered by searchTerm", async () => {
    throw new Error("Not Implemented");
  })

  test(`Should get recipes when the search bar button is clicked.
        The search term is not tested because that logic will exists on the API`, async () => {

    server.use(
      rest.get('/api/recipe', (req, res, ctx) => {
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