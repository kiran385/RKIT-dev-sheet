$(() => {
    //Local data for dataSource of grid
    var data = [
        { id: 1, firstName: 'Ajay', lastName: 'Sharma', age: 20, dob: '01-01-2005' },
        { id: 2, firstName: 'Rohit', lastName: 'Verma', age: 22, dob: '12-03-2003' },
        { id: 3, firstName: 'Sneha', lastName: 'Patel', age: 19, dob: '08-07-2006' },
        { id: 4, firstName: 'Vikram', lastName: 'Singh', age: 24, dob: '11-09-2001' },
        { id: 5, firstName: 'Priya', lastName: 'Patel', age: 21, dob: '10-11-2003' },
        { id: 6, firstName: 'Karan', lastName: 'Gupta', age: 23, dob: '05-05-2002' },
        { id: 7, firstName: 'Aman', lastName: 'Saxena', age: 17, dob: '08-08-2008' },
        { id: 8, firstName: 'Meera', lastName: 'Chopra', age: 18, dob: '12-02-2007' },
        { id: 9, firstName: 'Sameer', lastName: 'Rathore', age: 26, dob: '11-06-1999' },
        { id: 10, firstName: 'Neha', lastName: 'Mehta', age: 22, dob: '02-04-2003' },
        { id: 11, firstName: 'Kavya', lastName: 'Pillai', age: 23, dob: '09-12-2002' },
        { id: 12, firstName: 'Arjun', lastName: 'Bajwa', age: 19, dob: '03-03-2006' },
        { id: 13, firstName: 'Riya', lastName: 'Iyer', age: 20, dob: '10-10-2005' },
        { id: 14, firstName: 'Sahil', lastName: 'Yadav', age: 21, dob: '01-01-2004' },
        { id: 15, firstName: 'Tanya', lastName: 'Desai', age: 22, dob: '07-07-2003' },
        { id: 16, firstName: 'Dev', lastName: 'Nair', age: 24, dob: '02-02-2001' },
        { id: 17, firstName: 'Anjali', lastName: 'Malhotra', age: 18, dob: '11-05-2007' },
        { id: 18, firstName: 'Harsh', lastName: 'Trivedi', age: 23, dob: '09-09-2002' },
        { id: 19, firstName: 'Pooja', lastName: 'Reddy', age: 20, dob: '10-04-2005' },
        { id: 20, firstName: 'Nitin', lastName: 'Rajput', age: 25, dob: '12-08-2000' }
    ];

    $('#gridContainer').dxDataGrid({
        dataSource: data,
        keyExpr: 'id',
        paging: {
            pageSize: 10
        },
        editing: {
            mode: 'popup',
            allowUpdating: true,
            useIcons: true
        },
        allowColumnReordering: true,
        columnAutoWidth: true,
        //showColumnHeaders: false,   //Hide column header
        columnMinWidth: 150,
        //When allowColumnResizing is true then columnHidingEnabled stops working
        columnHidingEnabled: true,      //Contain expand/collapse button when certain columns do not fit into the screen size
        allowColumnResizing: true,
        columnResizingMode: 'widget', //widget or nextColumn
        //If the column is fixed then it can't move if we resize the columns
        columnFixing: {
            enabled: true             //Fix columns to left or right
        },
        columnChooser: {
            enabled: true,
            allowSearch: true,
            mode: 'select' // dragAndDrop or select
        },
        columns: [
            {
                dataField: 'id',
                minWidth: 160,
                visibleIndex: 1,          //position of a column among visible columns in the grid
                fixed: true,              //If i use fixed then it overwrite visibleIndex
                fixedPosition: 'left',
                alignment: 'center'
            },
            {
                caption: 'Name',
                columns: [
                    {
                        dataField: 'firstName',
                        width: 400
                    },
                    {
                        dataField: 'lastName',
                        width: 400
                    },
                ],
                visibleIndex: 0           //position of a column among visible columns in the grid
            },
            {
                caption: "Full Name",
                visibleIndex: 0,
                //display custom data by combining two columns
                calculateCellValue: function (rowData) {
                    return rowData.firstName + " " + rowData.lastName;
                }
            },
            {
                dataField: 'age',
                width: 150,
                //groupIndex: 0,
                //customize the text displayed in cells
                //customizeText: function (cellInfo) {
                //    return cellInfo.value + " yrs";
                //},
                //calculateCellValue: function (data) {
                //    return data.age + " years";
                //},
                //headerCellTemplate: function (header, info) {
                //    $('<div>')
                //        .html(info.column.caption)
                //        .css('font-size', '26px')
                //        .appendTo(header);
                //}
            },
            {
                dataField: 'dob',
                width: 300,
                dataType: 'date',        //Specify data type of column values
                allowResizing: false,    //Disable resizing of the column
                allowReordering: false,   //Disable re-ordering of the column
                allowFixing: false,       //Disable fixing of column
                allowHiding: false        //Column should not be hidden
            },
            //command columns become fixed automatically
            {
                type: 'buttons',
                caption: 'Action',
                width: 150,
                showInColumnChooser: false,  //header should never appear in the column chooser
                buttons: [
                    'edit',     //Built-in edit button
                    { icon: 'trash' },
                    {
                        icon: 'info',
                        hint: 'Data info',
                        onClick: function (e) {
                            const studentData = e.row.data;
                            console.log("Info :", studentData);
                            $('#popup').dxPopup({
                                visible: true,
                                title: 'Student Information',
                                height: 250,
                                width: 400,
                                contentTemplate: () => {
                                    const content = $("<div />");
                                    content.append($("<p>").text("Name: " + studentData.firstName));
                                    content.append($("<p>").text("Class: " + studentData.lastName));
                                    content.append($("<p>").text("Age: " + studentData.age));
                                    content.append($("<p>").text("Age: " + studentData.dob));
                                    return content;
                                },
                            }).dxPopup('instance')
                        }
                    },
                ]
            }
        ],
        onCellPrepared: function (e) {
            if (e.rowType === 'header' && e.column.dataField === 'age') {
                e.cellElement
                    .css('font-size', '30px');
            }
            if (e.rowType === 'data') {
                if (e.column.dataField === 'age') {
                    e.cellElement.text(e.value + ' yrs');
                }
                if (e.column.dataField === 'age' && e.data.age > 25) {
                    e.cellElement.css({
                        'color': 'black',
                        'background-color': 'yellow'
                    });
                }
            }
        },
        onRowPrepared: function (e) {
            //console.log(e.rowType);
            if (e.rowType === 'data') {
                if (e.data.age < 18) {
                    e.rowElement.css({
                        'color': 'white',
                        'background-color': 'red'
                    });
                }
            }
        },
        headerFilter: {
            visible: true
        },
        summary: {
            totalItems: [
                {
                    column: 'Dob',
                    summaryType: 'max'
                }
            ],
            groupItems: [
                {
                    column: 'Dob',
                    summaryType: 'count',
                    showInGroupFooter: true
                }
            ]
        }
    });
});