$(() => {
    var newSales = [
        { OrderID: 1, Customer: 'Arjun Mehta', OrderDate: '2024-10-25' },
        { OrderID: 2, Customer: 'Neha Sharma', OrderDate: '2024-10-26' },
        { OrderID: 3, Customer: 'Rohan Kapoor', OrderDate: '2024-10-27' },
        { OrderID: 4, Customer: 'Priya Nair', OrderDate: '2024-10-28' },
        { OrderID: 5, Customer: 'Vikram Singh', OrderDate: '2024-10-29' },
        { OrderID: 6, Customer: 'Sanya Khanna', OrderDate: '2024-10-30' },
        { OrderID: 7, Customer: 'Kabir Malhotra', OrderDate: '2024-10-31' },
        { OrderID: 8, Customer: 'Ritika Joshi', OrderDate: '2024-11-01' },
        { OrderID: 9, Customer: 'Aditya Verma', OrderDate: '2024-11-02' },
        { OrderID: 10, Customer: 'Meera Desai', OrderDate: '2024-11-03' }
    ];

    var newOrderDetails = [
        // Order 1 - Arjun
        { OrderID: 1, Product: 'Gaming Laptop', Quantity: 1, UnitPrice: 65000 },
        { OrderID: 1, Product: 'Mechanical Keyboard', Quantity: 1, UnitPrice: 4000 },

        // Order 2 - Neha
        { OrderID: 2, Product: 'Air Fryer', Quantity: 1, UnitPrice: 9000 },
        { OrderID: 2, Product: 'Coffee Maker', Quantity: 1, UnitPrice: 7000 },

        // Order 3 - Rohan
        { OrderID: 3, Product: 'Smartphone', Quantity: 1, UnitPrice: 25000 },
        { OrderID: 3, Product: 'Phone Cover', Quantity: 2, UnitPrice: 500 },
        { OrderID: 3, Product: 'Screen Protector', Quantity: 1, UnitPrice: 300 },

        // Order 4 - Priya
        { OrderID: 4, Product: 'Washing Machine', Quantity: 1, UnitPrice: 22000 },
        { OrderID: 4, Product: 'Detergent Pack', Quantity: 3, UnitPrice: 300 },

        // Order 5 - Vikram
        { OrderID: 5, Product: 'Smart TV', Quantity: 1, UnitPrice: 45000 },
        { OrderID: 5, Product: 'TV Wall Mount', Quantity: 1, UnitPrice: 1500 },

        // Order 6 - Sanya
        { OrderID: 6, Product: 'Laptop', Quantity: 1, UnitPrice: 52000 },
        { OrderID: 6, Product: 'Laptop Bag', Quantity: 1, UnitPrice: 2000 },
        { OrderID: 6, Product: 'USB-C Cable', Quantity: 1, UnitPrice: 600 },

        // Order 7 - Kabir
        { OrderID: 7, Product: 'Air Conditioner', Quantity: 1, UnitPrice: 38000 },
        { OrderID: 7, Product: 'Voltage Stabilizer', Quantity: 1, UnitPrice: 3000 },

        // Order 8 - Ritika
        { OrderID: 8, Product: 'Tablet', Quantity: 1, UnitPrice: 18000 },
        { OrderID: 8, Product: 'Bluetooth Earbuds', Quantity: 1, UnitPrice: 2500 },

        // Order 9 - Aditya
        { OrderID: 9, Product: 'Gaming Headset', Quantity: 1, UnitPrice: 4500 },
        { OrderID: 9, Product: 'Wireless Mouse', Quantity: 1, UnitPrice: 1200 },

        // Order 10 - Meera
        { OrderID: 10, Product: 'Smartwatch', Quantity: 1, UnitPrice: 9000 },
        { OrderID: 10, Product: 'Fitness Band', Quantity: 1, UnitPrice: 3000 }
    ];

    $('#gridContainer').dxDataGrid({
        dataSource: newSales,
        columns: [
            {
                dataField: 'OrderID',
                alignment: 'center'
            },
            {
                dataField: 'Customer',
                alignment: 'center'
            },
            {
                dataField: 'OrderDate',
                alignment: 'center'
            },
        ],
        masterDetail: {
            enabled: true,
            //autoExpandAll: true,
            template: function (container, options) {
                var orderID = options.data.OrderID;
                $('<div>')
                    .appendTo(container)
                    .dxDataGrid({
                        dataSource: newOrderDetails.filter(item => item.OrderID === orderID),
                        columns: [
                            {
                                dataField: 'Product',
                                alignment: 'center'
                            },
                            {
                                dataField: 'Quantity',
                                alignment: 'center'
                            },
                            {
                                dataField: 'UnitPrice',
                                alignment: 'center'
                            },
                            {
                                dataField: 'TotalPrice',
                                alignment: 'center',
                                calculateCellValue: function (rowData) {
                                    return rowData.Quantity * rowData.UnitPrice;
                                }
                            },  
                        ],
                        summary: {
                            totalItems: [{
                                column: 'Quantity',
                                summaryType: 'sum',
                                displayFormat: 'Total Quantity: {0}'
                            }, {
                                column: 'TotalPrice',
                                summaryType: 'sum',
                                displayFormat: 'Total Price: {0}'
                            }]
                        }
                    })
            }
        }
    });
});