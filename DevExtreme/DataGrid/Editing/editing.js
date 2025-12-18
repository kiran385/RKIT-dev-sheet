$(() => {
    var mockApiUrl = 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students';

    // CustomStore for AJAX CRUD operations
    var customStore = new DevExpress.data.CustomStore({
        key: "id",

        // Load data
        load: function () {
            return $.ajax({
                url: mockApiUrl,
                method: "GET",
                dataType: "json"
            });
        },

        // Insert data
        insert: function (values) {
            return $.ajax({
                url: mockApiUrl,
                method: "POST",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        // Update data
        update: function (key, values) {
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "PUT",
                data: JSON.stringify(values),
                contentType: "application/json"
            });
        },

        // Delete data
        remove: function (key) {
            return $.ajax({
                url: `${mockApiUrl}/${key}`,
                method: "DELETE"
            });
        },
    });

    $('#gridContainer').dxDataGrid({
        dataSource: customStore,
        keyExpr: 'id',
        paging: {
            pageSize: 10
        },
        columns: [{
            dataField: 'id',
            validationRules: [{ type: 'required' }]
        }, {
            dataField: 'name',
            validationRules: [
                { type: 'required' },
                { type: "stringLength", min: 2, max: 50 }
            ]
        }, {
            dataField: 'number',
            validationRules: [{ type: 'required' }]
        }, {
            dataField: 'age',
            validationRules: [
                { type: 'required' },
                { type: 'range', message: 'Age must be in range 18 to 100', min: 18, max: 100 }
            ]
        }, {
            dataField: 'address',
            allowEditing: false,
            validationRules: [{ type: 'required' }],
        }, {
            dataField: 'roomNumber',
            validationRules: [{ type: 'required' }]
        }, {
            dataField: 'feesPaid',
            editCellTemplate: function (cellElement, cellInfo) {
                $("<div />").dxSwitch({
                    width: 50,
                    switchedOnText: "True",
                    switchedOffText: "False",
                    value: cellInfo.value,
                    onValueChanged: function (e) {
                        cellInfo.setValue(e.value);
                    }
                }).appendTo(cellElement);
            }
        }, {
            type: "buttons",
            buttons: [{
                name: "edit",
                visible: function (e) {
                    return e.row.data.roomNumber !== 0; //Disable edit button for condition
                }
            }, "delete"]
        }],
        editing: {
            mode: 'form',       //(row, cell, batch, form, popup)
            useIcons: true,
            allowUpdating: true,
            allowAdding: true,
            allowDeleting: true,
            confirmDelete: false,  //Default value is true
            startEditAction: 'dblClick',  // Applies only when mode is cell / batch
            selectTextOnEditStart: true,   // Applies only when mode is cell / batch
            form: {
                items: [{
                    itemType: 'group',
                    caption: 'Personal Information',
                    colCount: 3,  // Total number of columns in one row
                    colSpan: 2,   // Total space required for item
                    items: ['id', 'name', 'number', 'age', {
                        dataField: 'address',
                        colSpan: 2
                        //visible: false
                    }]
                }, {
                    itemType: 'group',
                    caption: 'Other',
                    items: ['roomNumber', 'feesPaid']
                }]
            },
            popup: {
                showTitle: true,
                title: 'Student Data'
            }
        },
        onRowUpdated: function (e) {
            console.log("Row Updated", e);
        },
        onRowInserted: function (e) {
            console.log("Row Inserted", e);
        },
        onRowRemoved: function (e) {
            console.log("Row Removed", e);
        }
    });

    $('#mode').text(
        $('#gridContainer').dxDataGrid('instance').option('editing.mode')
    );

    // Define the branches data
    var branches = [
        { id: 1, name: "Computer Science" },
        { id: 2, name: "Electrical Engineering" }
    ];

    // Define the sub-branches data
    var subBranches = [
        { id: 1, name: "Machine Learning", branchId: 1 },
        { id: 2, name: "Web Development", branchId: 1 },
        { id: 3, name: "Embedded Systems", branchId: 2 },
        { id: 4, name: "Power Systems", branchId: 2 }
    ];

    // Define the subjects data
    var subjects = [
        { id: 1, name: "Neural Networks", subBranchId: 1 },
        { id: 2, name: "Deep Learning", subBranchId: 1 },
        { id: 3, name: "Frontend Development", subBranchId: 2 },
        { id: 4, name: "Backend Development", subBranchId: 2 },
        { id: 5, name: "Microcontrollers", subBranchId: 3 },
        { id: 6, name: "Signal Processing", subBranchId: 3 },
        { id: 7, name: "Renewable Energy", subBranchId: 4 },
        { id: 8, name: "High Voltage", subBranchId: 4 }
    ];

    // Define the initial grid data
    var gridData = [
        { id: 1, branchId: 1, subBranchId: 1, subjectId: 1 },
        { id: 2, branchId: 2, subBranchId: 3, subjectId: 5 }
    ];

    // Initialize the DataGrid
    $("#cascadingLookupGridContainer").dxDataGrid({
        dataSource: gridData, // Set the data source for the grid
        keyExpr: "id", // Define the key expression for the grid
        columns: [
            {
                dataField: "branchId",
                caption: "Branch",
                lookup: {
                    dataSource: branches, // Set the branches as the lookup data source
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var branch = branches.find(b => b.id === rowData.branchId);
                    return branch ? branch.name : "";
                },
                setCellValue: function (rowData, value) {
                    rowData.branchId = value; // Set the branchId value
                    rowData.subBranchId = null; // Reset Sub-Branch when Branch changes
                    rowData.subjectId = null; // Reset Subject when Branch changes
                }
            },
            {
                dataField: "subBranchId",
                caption: "Sub-Branch",
                lookup: {
                    dataSource: function (options) {
                        if (!options.data || !options.data.branchId) {
                            return []; // Return empty array if no branch is selected
                        }
                        return {
                            store: subBranches, // Filter sub-branches based on selected branch
                            filter: ["branchId", "=", options.data.branchId]
                        };
                    },
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var subBranch = subBranches.find(sb => sb.id === rowData.subBranchId);
                    return subBranch ? subBranch.name : "";
                },
                setCellValue: function (rowData, value) {
                    rowData.subBranchId = value; // Set the subBranchId value
                    rowData.subjectId = null; // Reset Subject when Sub-Branch changes
                }
            },
            {
                dataField: "subjectId",
                caption: "Subject",
                lookup: {
                    dataSource: function (options) {
                        if (!options.data || !options.data.subBranchId) {
                            return []; // Return empty array if no sub-branch is selected
                        }
                        return {
                            store: subjects, // Filter subjects based on selected sub-branch
                            filter: ["subBranchId", "=", options.data.subBranchId]
                        };
                    },
                    valueExpr: "id", // Set the value expression for the lookup
                    displayExpr: "name" // Set the display expression for the lookup
                },
                calculateDisplayValue: function (rowData) {
                    var subject = subjects.find(s => s.id === rowData.subjectId);
                    return subject ? subject.name : "";
                }
            }
        ],
        editing: {
            mode: "popup",
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true
        }
    });
});