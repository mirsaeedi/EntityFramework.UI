var merge = require('webpack-merge');
var common = require('./webpack.common.js');
module.exports = merge(common, {
    mode: 'production',
    devtool: 'source-map'
});
//# sourceMappingURL=webpack.prod.js.map