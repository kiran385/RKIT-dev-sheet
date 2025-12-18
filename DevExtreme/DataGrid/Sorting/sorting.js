$(() => {
    $('#gridContainer').dxDataGrid({
        dataSource: 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students',
        paging: {
            pageSize: 15
        },
        columns: [{
            dataField: 'id',
            sortIndex: 1,
            sortOrder: 'desc',
            allowSorting: false     //Disables sorting on the column
        }, 'name', 'number', 'age', 'address',
        {
            dataField: 'roomNumber',
            sortIndex: 0,
            sortOrder: 'asc'
        }, 'feesPaid'
        ],
        sorting: {
            mode: 'multiple',    //single, multiple, none
            showSortIndexes: true,     //Show number next to sorted column
            ascendingText: "Apply Sorting By Ascending Order",
            descendingText: "Apply Sorting By Descending Order",
            clearText: "Clear Applied Sorting",
        }
    });
});