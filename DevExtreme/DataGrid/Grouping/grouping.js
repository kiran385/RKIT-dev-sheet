$(() => {
    $('#gridContainer').dxDataGrid({
        dataSource: 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students',
        allowColumnReordering: true,
        paging: {
            pageSize: 15
        },
        columns: [{
            dataField: 'id',
            allowGrouping: false,
        }, 'name', 'number', 'age', 'address',
        {
            dataField: 'roomNumber',
            groupIndex: 0,
            //autoExpandGroup: true
        }, 'feesPaid'
        ],
        groupPanel: {
            visible: true,
            emptyPanelText: "Drag Column Header Here To Group",
            //allowColumnDragging: false
        },
        grouping: {
            contextMenuEnabled: true,
            autoExpandAll: true,
            //allowCollapsing: false,
            expandMode: "rowClick"  // or "buttonClick"
        }
    });
});