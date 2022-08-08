const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const ESLintPlugin = require('eslint-webpack-plugin');

__dirname = path.resolve(__dirname, "..");

module.exports = {
    entry: path.resolve(__dirname, "src", "index.tsx"),

    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: '[name].bundle.js',
        clean: true,
    },
    stats: {
        children: true
    },
    resolve: {
        extensions: [".js", ".jsx", ".json", ".ts", ".tsx"],
    },
    plugins: [
        new HtmlWebpackPlugin({
            template: "./src/index.template.html"
        }),
        new MiniCssExtractPlugin(),
        new ESLintPlugin({
            failOnError: false
        })
    ],
    module: {
        rules: [
            {
                test: /\.(js|jsx|tsx|ts)$/,
                exclude: /node_modules/,
                use: [
                    {
                        loader: "babel-loader"
                    },
                    {
                        loader: 'ts-loader',
                        options: {
                            configFile: path.resolve(__dirname, './tsconfig.json'),
                        },
                    },
                ],
            },
            {
                test: /\.css$/,
                use: [
                    'style-loader',
                    {
                    loader: 'css-loader',
                    options: {
                        importLoaders: 1,
                        modules: true
                    }
                    }
                ]
            },
            {
                test: /\.js$/,
                exclude: /node_modules/,
                enforce: "pre",
                use: ["source-map-loader"]
            },
            {
                test: /\.(eot|svg|ttf|woff|woff2)$/,
                loader: 'file-loader',
                options: {
                    name: 'font/[name].[ext]'
                }
            },
            {
                test: /\.(jpg|png)$/,
                loader: 'file-loader',
                options: {
                    name: 'image/[name].[ext]'
                }
            }
        ]
    }
}