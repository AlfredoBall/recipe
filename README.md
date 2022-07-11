# Recipe App

This project is intended to demonstrate procifiency in building a simple React Recipe App

## Available Scripts

In the project directory, you can run:

### `npm run local`

Runs the app in the local mode.\
Local mode swaps out real services for fake services that do not interact with environment resources.\
Open [http://localhost:9000](http://localhost:9000) to view it in your browser.

### `npm run build`

Builds the app for production to the `dist` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

## Testing

### `npm run test`

Launches the Jest test runner in the interactive watch mode.\

The reason why the tests are all in one file is because the mock msw/node server can't be shared between files.\
There's no way to have a global server as far as I can tell.\

## Styling

Syling uses css modules to scope classes.\
The clsx library is used to combine the css module styles variable scoped class names with other regular class names\
I tried to use TypeScript part templating