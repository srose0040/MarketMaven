Ext.define('MarketMaven.view.main.Form', {
    extend: 'Ext.form.Panel',
    xtype: 'Form',
    title: 'Monitor a new Stock',
    width: 350,
    boddyPadding: 5,
    url: 'http://localhost:5209/stock', // TODO ADJUST
    method: 'POST', // HTTP Method

    layout: 'anchor',
    defaults: {
        anchor: '100%'
    },

    defaultType: 'textfield',
    items: [
        {   fieldLabel: 'Name', 
            name: 'nameInp', 
            allowBlank: false
        }
    ],
    jsonSubmit: true,
    buttons:[
        {   text: 'Submit', 
            formBind: true, 
            disabled: true, 
            handler: function(){
                var form = this.up('form');

                if(form.isValid()){
                    form.submit({
                        success: function(form, action){
                            Ext.Msg.alert(
                                'Success',
                                'The stock got added to your watchlist'
                            )
                        },
                        failure: function(){
                            Ext.Msg.alert("Failure", "Something went wrong.")
                        }
                    })
                }
            }
    
        }
    ]
})