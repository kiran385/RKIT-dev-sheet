$(() => {
    var menuData = [
        {
            id: '1',
            name: 'Fruits',
            items: [
                { id: '1_1', name: 'Apple' },
                { id: '1_2', name: 'Banana' },
                { id: '1_3', name: 'Mango' },
            ],
        },
        {
            id: '2',
            name: 'Vegetables',
            items: [
                { id: '2_1', name: 'Carrot' },
                { id: '2_2', name: 'Broccoli' },
                { id: '2_3', name: 'Spinach' },
            ],
        },
        {
            id: '3',
            name: 'Beverages',
            items: [
                {
                    id: '3_1',
                    name: 'Tea',
                    expanded: true,
                    items: [
                        { id: '3_1_1', name: 'Green Tea' },
                        { id: '3_1_2', name: 'Black Tea' },
                    ],
                },
                {
                    id: '3_2',
                    name: 'Juices',
                    items: [
                        { id: '3_2_1', name: 'Orange Juice' },
                        { id: '3_2_2', name: 'Apple Juice' },
                    ],
                },
            ],
        },
        {
            id: '4',
            name: 'Bakery',
            items: [
                { id: '4_1', name: 'Bread' },
                { id: '4_2', name: 'Croissant' },
                { id: '4_3', name: 'Muffin' },
            ],
        },
    ];

    $("#container").dxTreeView({

        // The data source for the tree view
        items: menuData,

        // Defines the structure of the data
        dataStructure: "tree", 

        // Specifies the unique identifier field
        keyExpr: "id",

        // Defines which field will be displayed as node text
        displayExpr: "name",

        // Enables checkboxes for selection
        showCheckBoxesMode: "normal",       //(none, normal, selectAll)

        // Enables search functionality
        searchEnabled: true,

        // Defines the search behavior
        searchMode: "contains",             //(contains, startswith, equals)

        // Customizes the search input options
        searchEditorOptions: { placeholder: "Search items..." },

        // Expands nodes recursively on load
        expandNodesRecursive: true, 

        // Ensures selection propagates to child nodes
        selectNodesRecursive: true, 

        // Specifies whether or not a user can expand all tree view items by the "*" hot key.
        expandAllEnabled: true,

        // Allows selection by clicking the node
        selectByClick: true, // Alternative: false (selection only via checkboxes if enabled)

        // Defines the selection mode
        selectionMode: "multiple", // Alternatives: "single", "none"

        // Specifies the event that triggers node expansion
        expandEvent: "click",

        // Event triggered when selection changes
        onItemSelectionChanged: (e) => {
            console.log("Selection changed: ", e.node);
        },

        // Event triggered when a node is expanded
        onItemExpanded: (e) => {
            console.log("Expanded: ", e.node.text);
        },

        // Event triggered when a node is collapsed
        onItemCollapsed: (e) => {
            console.log("Collapsed: ", e.node.text);
        },

        // Event triggered when the TreeView is initialized
        onInitialized: () => {
            console.log("TreeView Initialized");
        },

        // Event triggered when the TreeView is fully rendered
        onContentReady: () => {
            console.log("TreeView Loaded");
        },
    });
});