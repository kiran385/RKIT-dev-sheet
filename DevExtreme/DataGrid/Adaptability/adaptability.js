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
            {
                dataField: 'OrderID',
                width: 200
            },
            {
                dataField: 'Customer',
                width: 300
            },
            {
                dataField: 'Product',
                width: 400
            },
            {
                dataField: 'Quantity',
                width: 200,
                hidingPriority: 2
            },
            {
                dataField: 'UnitPrice',
                width: 200,
                hidingPriority: 1
            },
            {
                dataField: 'OrderDate',
                width: 200,
                hidingPriority: 0
            },
            {
                dataField: 'TotalPrice',
                dataType: 'number',
                width: 200,
                calculateCellValue: function (row) {
                    return row.Quantity * row.UnitPrice;
                }
            }
        ],
        columnHidingEnabled: true,
        showBorders: true,
        showRowLines: true,
        rowAlternationEnabled: true,
    })
});