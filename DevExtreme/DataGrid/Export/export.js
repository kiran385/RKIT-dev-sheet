$(() => {
    const { jsPDF } = window.jspdf;
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
        selection: {
            enabled: true,
            mode: 'multiple'
        },
        columns: [
            'OrderID', 'Customer', 'Product', 'Quantity', 'UnitPrice', 'OrderDate',
            {
                dataField: 'TotalPrice',
                dataType: 'number',
                calculateCellValue: function (row) {
                    return row.Quantity * row.UnitPrice;
                }
            }
        ],
        summary: {
            recalculateWhileEditing: true,
            totalItems: [{
                column: 'Quantity',
                summaryType: 'sum',
                displayFormat: 'Total Quantity: {0}',
            }, {
                column: 'TotalPrice',
                summaryType: 'sum',
                displayFormat: 'Total Sales Amount: {0}',
            }, {
                column: 'UnitPrice',
                summaryType: 'max',
            }]
        },
        export: {
            enabled: true,
            allowExportSelectedData: true,
            formats: ['pdf','xlsx']
        },
        onExporting(e) {
            if (e.format === 'pdf') {
                const doc = new jsPDF();

                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: doc,
                    component: e.component,
                    columnWidths: [10, 30, 30, 10, 20, 30],
                }).then(() => {
                    doc.save('SalesData.pdf');
                });
            }

            if (e.format === 'xlsx') {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet('Sales');

                DevExpress.excelExporter.exportDataGrid({
                    component: e.component,
                    worksheet,
                    autoFilterEnabled: true,
                }).then(() => {
                    workbook.xlsx.writeBuffer().then((buffer) => {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'SalesData.xlsx');
                    });
                });
            }
        }
    })
});