var path = require('path');
var WebpackNotifierPlugin = require('webpack-notifier');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

const PATHS = {
    app: path.join(__dirname, 'app'),
    build: path.join(__dirname, '../TMS.Web/wwwroot/built')
};
module.exports = {
    context: PATHS.app,
    entry: [
        './tms.js'
    ],
    output: {
        path: PATHS.build,
        filename: '[name].bundle.js'
    },
    devtool: "source-map",
    plugins: [
      new WebpackNotifierPlugin(),
      new ExtractTextPlugin('bundle.css'),
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
            { test: /\.jsx?$/, exclude: /(node_modules|bower_components)/, loader: 'babel' },
            { test: /\.css$/, loader: 'style-loader!css-loader' },
            {test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, loader: 'file-loader?mimetype=image/svg+xml&name=[name].[ext]'},
            {test: /\.woff(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/font-woff&name=../fonts/[name].[ext]"},
            {test: /\.woff2(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/font-woff&name=../fonts/[name].[ext]"},
            {test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?mimetype=application/octet-stream&name=../fonts/[name].[ext]"},
            {test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, loader: "file-loader?name=../fonts/[name].[ext]"}
        ]
    },
    //externals: {
    //    //don't bundle the 'react' npm package with our bundle.js
    //    //but get it from a global 'React' variable
    //    'react': 'React'
    //},
    resolve: {
        extensions: ['','.js','.jsx']
    }
};
