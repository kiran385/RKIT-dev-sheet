$(() => {
    var menuData = [
        { id: '1', name: 'Home', icon: 'home' },
        { id: '2', name: 'About', icon: 'info' },
        {
            id: '3', name: 'Add', icon: 'add',
            items: [
                { id: '3_1', name: 'Add Item' },
            ]
        },
    ]
    $('#menu').dxMenu({
        items: menuData,
        displayExpr: 'name',
        orientation: 'horizontal',
        showFirstSubmenuMode: 'onHover',
        hideSubmenuOnMouseLeave: true,
        adaptivityEnabled: true,
        onItemClick: function (e) {
            if (e.itemData.name === 'Add Item') {
                popup.show();
            }
        },
    });

    var treeData = [
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
    $('#treeView').dxTreeView({
        items: treeData,
        keyExpr: 'id',
        displayExpr: 'name',
        dataStructure: 'tree',
        showCheckBoxesMode: 'selectAll',
        selectionMode: 'multiple',
        searchEnabled: true,
        expandNodesRecursive: true,
        selectNodesRecursive: true,
        expandAllEnabled: true,
        expandEvent: 'click'
    });

    var popup = $('#popup').dxPopup({
        title: 'Add New Item',
        showCloseButton: false,
        hideOnOutsideClick: true,
        resizeEnabled: true,
        toolbarItems: [
            {
                toolbar: 'bottom',
                location: 'after',
                widget: 'dxButton',
                options: {
                    text: 'Save',
                    type: 'success',
                    onClick: function () {
                        let form = $('#form').dxForm('instance');
                        if (form.validate().isValid) {
                            savePost();
                            popup.hide();
                        }
                    }
                }
            },
            {
                toolbar: 'bottom',
                location: 'after',
                widget: 'dxButton',
                options: {
                    text: 'Close',
                    type: 'danger',
                    onClick: function () {
                        popup.hide();
                    }
                }
            }
        ],
        contentTemplate: function (contentElement) {
            contentElement.append(
                '<div class="form-container">' +
                '<div id="form"></div>' +
                '</div>'
            );
            $('#form').dxForm({
                items: [
                    {
                        dataField: 'id',
                        label: { text: 'Id' },
                        validationRules: [
                            { type: 'required', message: 'Id is required' }
                        ]
                    },
                    {
                        dataField: 'name',
                        label: { text: 'Name' },
                        editorType: 'dxTextArea',
                        validationRules: [
                            { type: 'required', message: 'Name is required' }
                        ]
                    },
                    {
                        dataField: 'items',
                        label: { text: 'Items (comma separated)' },
                        editorType: 'dxTextArea',
                        validationRules: [{ type: 'required' }]
                    }
                ]
            });
        }
    }).dxPopup('instance');

    function savePost() {
        var data = $('#form').dxForm('instance').option('formData');
        loadPanel.option('visible', true);

        const items = data.items
            .split(',')
            .map((name, index) => ({
                id: `${data.id}_${index + 1}`,
                name: name.trim()
            }));

        const newNode = {
            id: data.id,
            name: data.name,
            items: items
        };

        treeData.push(newNode);

        setTimeout(() => {
            $('#treeView').dxTreeView('instance').option('items', treeData);
            loadPanel.option('visible', false);
            DevExpress.ui.notify('Item saved!!', 'success');
        }, 500);
    };

    var loadPanel = $('#loadPanel').dxLoadPanel({
        visible: false,
        hideOnOutsideClick: true,
        indicatorSrc: 'https://js.devexpress.com/Content/data/loadingIcons/rolling.svg',
        message: 'Please wait....',
        shadingColor: 'rgba(0, 0, 0, 0.3)',
    }).dxLoadPanel('instance');

    $('#popover').dxPopover({
        target: '#link',
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'bottom',
        shadingColor: 'rgba(0, 0, 0, 0.3)',
    }).dxPopover('instance');
});