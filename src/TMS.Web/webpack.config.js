var path = require('path');
var WebpackNotifierPlugin = require('webpack-notifier');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

const PATHS = {
    app: path.join(__dirname, './app'),
    build: path.join(__dirname, './wwwroot/built')
};
module.exports = {
    context: PATHS.app,
    entry: [
        'bootstrap-loader',
        './main.js'
    ],
    output: {
        path: PATHS.build,
        filename: '[name].bundle.js'
    },
    devtool: "source-map",
    plugins: [
      new WebpackNotifierPlugin(),
      new ExtractTextPlugin('bundle.css'),
        new webpack.ProvidePlugin({
            $: "jquery",
            jQuery: "jquery"
        })

    //   new webpack.DefinePlugin({
    //       "process.env": {
    //         NODE_ENV: JSON.stringify("production")
    //       }
    //     })
      //new webpack.optimize.UglifyJsPlugin({minimize: true})
    ],
    module: {
        loaders: [
            {
                test: /\.scss$/,
                loader: ExtractTextPlugin.extract("style", "css!sass?sourceMap")
            },
            { test: /\.js?$/, exclude: /(node_modules|bower_components)/, loader: 'babel' },
            { test: /\.css$/, loader: 'style-loader!css-loader' },
            { test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: 'file-loader?mimetype=image/svg+xml&name=[name].[ext]' },
            { test: /\.woff(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/font-woff&name=../fonts/[name].[ext]" },
            { test: /\.woff2(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/font-woff&name=../fonts/[name].[ext]" },
            { test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/octet-stream&name=../fonts/[name].[ext]" },
            { test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?name=../fonts/[name].[ext]" }
        ]
    },
    resolve: {
        extensions: ['', '.js'],
        alias: {
            jquery: "jquery/src/jquery"
        }
    }
};