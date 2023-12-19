Ext.define('MarketMaven.model.StocksStore', {
    extend: 'Ext.data.Store',
    alias: 'store.StocksStore',
    model: 'MarketMaven.model.Stock',
    autoLoad: true,
    fields:
    [
        {name: 'name'},
        {name: 'priceNow'},
        {name: 'diff'}
    ],
    // Data for stock will come from this proxy
    proxy:{
        type: 'ajax', 
        reader:{
            type: 'json',
            rootProperty: 'items'
        },
        url: 'http://localhost:5209/stock' // TODO CHANGE URL
    }

});