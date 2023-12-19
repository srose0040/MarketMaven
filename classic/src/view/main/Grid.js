Ext.define('MarketMaven.view.main.Grid', {
    extend: 'Ext.grid.Panel',
    store: {type: 'StocksStore'},
    xtype: 'mainGrid',
    title: 'Stocks',
    columns: [
       {text: 'Name', dataIndex: 'name', flex: 1},
       {text: 'Price Now', dataIndex: 'priceNow', flex: 1},
       {text: 'Starting Price', dataIndex: 'startingPrice', flex: 1},
       {
           text: 'Difference',
           dataIndex: 'diff',
           xtype: 'widgetcolumn',
           widget: {
               xtype: 'progress',
               textTpl: '{value:percent}'
           },
           flex: 1

       }
],
renderTo: Ext.getBody()
})