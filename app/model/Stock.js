Ext.define('MarketMaven.model.Stock', {
    extend: 'MarketMaven.model.Base',

    store: 'MarketMaven.store.StockStore', // Provides data from backend
    fields: [
        {name: 'name', type: 'string'},
        {name: 'priceNow', type: 'float'},
        {name: 'startingPrice', type: 'float'},
        {name: 'diff', type: 'float'}
    ]
});