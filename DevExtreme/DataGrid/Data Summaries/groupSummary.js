$(() => {
    var salesData = [
        { OrderID: 1, Customer: 'Rahul Sharma', Product: 'LED TV', Quantity: 1, UnitPrice: 42000, OrderDate: '2024-10-25' },
        { OrderID: 2, Customer: 'Sneha Patel', Product: 'Smartwatch', Quantity: 1, UnitPrice: 10000, OrderDate: '2024-10-26' },
        { OrderID: 3, Customer: 'Aman Verma', Product: 'Laptop', Quantity: 1, UnitPrice: 65000, OrderDate: '2024-10-27' },
        { OrderID: 4, Customer: 'Pooja Singh', Product: 'Headphones', Quantity: 2, UnitPrice: 11000, OrderDate: '2024-10-28' },
        { OrderID: 5, Customer: 'Karan Mehta', Product: 'Smartphone', Quantity: 3, UnitPrice: 16000, OrderDate: '2024-10-29' },
        { OrderID: 6, Customer: 'Neha Kapoor', Product: 'Laptop', Quantity: 2, UnitPrice: 52000, OrderDate: '2024-10-30' },
        { OrderID: 7, Customer: 'Vikas Rao', Product: 'Air Conditioner', Quantity: 1, UnitPrice: 36000, OrderDate: '2024-10-31' },
        { OrderID: 8, Customer: 'Ananya Roy', Product: 'Tablet', Quantity: 2, UnitPrice: 21000, OrderDate: '2024-11-01' },
        { OrderID: 9, Customer: 'Rohit Khanna', Product: 'Headphones', Quantity: 5, UnitPrice: 2500, OrderDate: '2024-11-02' },
        { OrderID: 10, Customer: 'Priya Desai', Product: 'Smartwatch', Quantity: 2, UnitPrice: 12000, OrderDate: '2024-11-03' }
    ];

    $('#gridContainer').dxDataGrid({
        dataSource: salesData,
        columns: [
            'OrderID', 'Customer',
            {
                dataField: 'Product',
                groupIndex: 0
            },
            'Quantity',
            {
                dataField: 'UnitPrice',
                format: { type: 'currency', currency: 'INR' }
            },
            'OrderDate',
            {
                dataField: 'TotalPrice',
                dataType: 'number',
                format: { type: 'currency', currency: 'INR' },
                calculateCellValue: function (row) {
                    return row.Quantity * row.UnitPrice;
                }
            }
        ],
        groupPanel: {
            visible: true
        },
        grouping: {
            contextMenuEnabled: true,
        },
        summary: {
            groupItems: [{
                column: 'Quantity',
                summaryType: 'sum',
                alignByColumn: true,
                customizeText: function (e) {
                    return e.value < 3 ? 'Less than 3 items: ' + e.value : 'Items: ' + e.value;
                }
            }, {
                column: 'TotalPrice',
                summaryType: 'sum',
                valueFormat: { type: 'currency', currency: 'INR' },
                displayFormat: 'Total Sales Amount: {0}',
                alignByColumn: true,
                showInGroupFooter: true,
            }, {
                summaryType: 'count'
            }]
        },
        sortByGroupSummaryInfo: [{
            summaryItem: 0,
            sortOrder: 'desc',
            //groupColumn: 'TotalPrice'     //Sort only when group by TotalPrice column
        }]
    })
});