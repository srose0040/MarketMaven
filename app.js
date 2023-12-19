/*
 * This file launches the application by asking Ext JS to create
 * and launch() the Application class.
 */
Ext.application({
    extend: 'MarketMaven.Application',

    name: 'MarketMaven',

    requires: [
        // This will automatically load all classes in the MarketMaven namespace
        // so that application classes do not need to require each other.
        'MarketMaven.*'
    ],

    // The name of the initial view to create.
    mainView: 'MarketMaven.view.main.Main'
});
