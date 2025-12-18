$(() => {
    $('#gridContainer').dxDataGrid({
        dataSource: 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students',
        paging: {
            pageSize: 15
        },
        columns: [{
            dataField: 'id',
            allowFiltering: false,        //Disables filter by filterRow
            allowHeaderFiltering: false,  //Disables header filtering
            allowSearch: false            //Exclude column from seaching
        }, 'name', 'number', 'age', 'address', 'roomNumber', 'feesPaid'
        ],
        filterValue: ["name", "<>", null],  //Predefine the filter value
        filterRow: {
            visible: true,
            //showOperationChooser: false,
            //applyFilter: 'onClick'
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
            //text: 'false'         //Predefine the search value
        }
    });
});