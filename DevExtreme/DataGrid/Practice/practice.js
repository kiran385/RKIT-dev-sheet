$(() => {
    //Custom store 
    var customStore = new DevExpress.data.CustomStore({
        key: 'OrderNumber',

        load: function (loadOptions) {
            const args = {};

            Object.keys(loadOptions).forEach((key) => {
                if (loadOptions[key] !== undefined && loadOptions[key] !== null) {
                    args[key] = JSON.stringify(loadOptions[key]);
                }
            });

            return $.ajax({
                url: 'https://js.devexpress.com/Demos/WidgetsGalleryDataService/api/orders',
                method: 'GET',
                data: args,
            }).then(function (result) {
                return {
                    data: result.data,
                    totalCount: result.totalCount
                }
            })
        },
        loadMode: 'processed',
    });

    //Data Grid for UI
    $('#gridContainer').dxDataGrid({
        dataSource: customStore,
        remoteOperations: true,
        columns: [{
            dataField: 'OrderNumber',
            dataType: 'number',
        }, {
            dataField: 'OrderDate',
            dataType: 'date',
        }, {
            dataField: 'StoreCity',
            dataType: 'string',
        }, {
            dataField: 'StoreState',
            dataType: 'string',
        }, {
            dataField: 'Employee',
            dataType: 'string',
        }, {
            dataField: 'SaleAmount',
            dataType: 'number',
            format: 'currency',
            sortOrder: 'desc'
        }],
        paging: {
            enabled: true,
            pageSize: 10
        },
        pager: {
            showPageSizeSelector: true,
            allowPageSizes: [10, 15, 20],
            showInfo: 'Item {0} of {1} & Total items: {3}',
            showNavigationButtons: true
        },
        grouping: {
            contextMenuEnabled: true,       //Enable grouping
            autoExpandAll: true,           //Default value is true
            expandMode: 'rowClick',         //(buttonClick, rowClick)
            //allowCollapsing: false          //Default value true
        },
        groupPanel: {
            visible: true,                  //Default value is false
            //allowColumnDragging: false,
            emptyPanelText: 'Drag column to group'
        },
        editing: {
            mode: 'form',
            allowAdding: true,
            form: {
                colCount: 3,
                items: ['OrderNumber', 'OrderDate', 'StoreCity', {
                    dataField: 'StoreState',
                    colSpan: 2
                }]
            }
        },
        filterRow: {
            visible: true,
            applyFilter: 'auto'          //(auto, onClick)
        },
        headerFilter: {
            visible: true,
            allowSearch: true
        },
        filterPanel: {
            visible: true
        },
        searchPanel: {
            visible: true,
        },
    })
});