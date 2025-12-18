$(() => {
    var menuData = [
        {
            id: '1', name: 'Fruits', icon: 'food',
            items: [
                { id: '1_1', name: 'Apple', price: 100 },
                { id: '1_2', name: 'Mango', price: 200 },
            ]
        },
        {
            id: '2', name: 'Bakery', icon: 'cart',
            items: [
                { id: '2_1', name: 'Bread', price: 40 },
                { id: '2_2', name: 'Toast', price: 30 },
            ]
        },
        {
            id: '3', name: 'Dairy', icon: 'box',
            items: [
                { id: '3_1', name: 'Milk', price: 80 },
                { id: '3_2', name: 'ButterMilk', price: 30 },
            ]
        },
        {
            id: '4', name: 'Fast Food', icon: 'car',
            items: [
                { id: '4_1', name: 'Pizza', price: 250 },
                { id: '4_2', name: 'Burger', price: 80 },
            ]
        },
    ];


    $("#container").dxMenu({
        // The data source for the menu
        items: menuData,

        // Defines which field will be displayed as menu text
        displayExpr: 'name',

        // Enables responsive behavior for small screens
        adaptivityEnabled: true,

        // Defines menu orientation (horizontal by default)
        //orientation: 'vertical',         //(horizontal, vertical)

        // Hides submenus when the mouse leaves the menu area
        hideSubmenuOnMouseLeave: true,

        // Defines how the first submenu is displayed
        showFirstSubmenuMode: "onHover",    //(onClick, onHover)

        // Defines how other submenus are displayed
        showSubmenuMode: "onHover",         //(onClick, onHover)

        // Event triggered when a menu item is clicked
        onItemClick: (e) => {
            $("#toast").dxToast({
                message: "Clicked: " + e.itemData.name,
                type: "success",
                displayTime: 2000
            }).dxToast("show");
        },

        // Event triggered after submenu is fully shown
        onSubmenuShown: () => {
            console.log("Shown...")
        },

        // Event triggered after submenu is fully hidden
        onSubmenuHidden: () => {
            console.log("Hidden...")
        },
    });
});