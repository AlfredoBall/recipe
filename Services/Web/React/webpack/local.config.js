const { merge } = require('webpack-merge');
const webpack = require('webpack');
const path = require('path');
const baseConfig = require('./base.config.js');

module.exports = merge(baseConfig, {
    devtool: 'inline-source-map', //inline source maps should not be used in production
    mode: "development",
    devServer: {
      static: {
        directory: path.join(__dirname, "..", 'dist'),
      },
      compress: false,
      hot: false,
      port: 9000,
    },
    watchOptions: {
       ignored: /dist/,
      },
    optimization: {
      minimize: false
    },
    // plugins: [
    //   new webpack.NormalModuleReplacementPlugin(
    //     /Services/,
    //     function (resource) {
    //       resource.request = resource.request.replace(
    //         /Services/,
    //         'Services/Fakes'
    //       );
    //     }
    //   )
    // ]
});