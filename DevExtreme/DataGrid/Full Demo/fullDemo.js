$(() => {
    const { jsPDF } = window.jspdf;

    //API endpoint
    var mockApi = 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students';

    //Custom store of mock API
    var customStore = new DevExpress.data.CustomStore({
        key: 'id',

        load: function () {
            return $.ajax({
                url: mockApi,
                method: 'GET'
            });
        },

        insert: function (values) {
            console.log(values);
            return $.ajax({
                url: mockApi,
                method: 'POST',
                data: JSON.stringify(values),
                contentType: 'application/json'
            });
        },

        update: function (key, values) {
            console.log('Updating:', key, values);
            return $.ajax({
                url: `${mockApi}/${key}`,
                method: 'PUT',
                data: JSON.stringify(values),
                contentType: 'application/json'
            });
        },

        remove: function (key) {
            return $.ajax({
                url: `${mockApi}/${key}`,
                method: 'DELETE'
            });
        }
    });

    //Data Grid for UI
    $('#gridContainer').dxDataGrid({
        dataSource: customStore,
        //remoteOperations: true,
        showBorders: true,              //Show border aroud dataGrid
        //showColumnLines: false,         //Hide vertical column lines
        showRowLines: true,             //Show horizonatal row lines
        rowAlternationEnabled: true,    //Enable zebra striping in rows
        allowColumnReordering: true,
        columnHidingEnabled: true,
        columnChooser: {
            enabled: true,
            allowSearch: true,
            mode: 'select' //(dragAndDrop, select)
        },
        columnFixing: {
            enabled: true       //Enable column fixing and show Fix/Unfix option in context menu
        },
        //showColumnHeaders: false,         //Hide column header
        columns: [
            {
                dataField: 'id',
                allowGrouping: false,            //Disable grouping on this column
                //groupIndex: 0,                   //Group by column with low index first
                sortIndex: 0,
                sortOrder: 'desc',
                allowSorting: false,            //Disable sorting on this column
                fixed: true,                    //Enable column fixing
                fixedPosition: 'left',          //Fix column to left side 
                showInColumnChooser: false,     //header should never appear in the column chooser
                validationRules: [{ type: 'required' }],
            },
            {
                dataField: 'name',
                //width: 1000,
                validationRules: [
                    { type: 'required' },
                    { type: "stringLength", min: 2, max: 50 }
                ]
            },
            {
                dataField: 'number',
                allowHeaderFiltering: false,      //Disable header filtering
                allowSearch: false,               //Exclude column from seaching
                validationRules: [{ type: 'required' }]
            },
            {
                dataField: 'age',
                customizeText: (cellInfo) => {
                    return cellInfo.value + " yrs";
                },
                validationRules: [
                    { type: 'required' },
                    { type: 'range', message: 'Age must be in range 18 to 100', min: 18, max: 100 }
                ]
            },
            {
                dataField: 'address',
                allowEditing: false,         //Disable updating of column data
                autoExpandGroup: true,
                validationRules: [{ type: 'required' }]
            },
            {
                dataField: 'feesPaid',
                cellTemplate: function (container, options) {      //Column template using cellTemplate
                    $("<span>")
                        .text(options.value)
                        .css({
                            color: options.value != 'true' ? 'red' : 'green',
                            'font-weight': 'bold'
                        })
                        .appendTo(container);
                },
                validationRules: [{ type: 'required' }]
            },
            {
                dataField: 'roomNumber',
                validationRules: [{ type: 'required' }]
            },
            {
                //caption: 'Action',
                type: 'buttons',
                headerCellTemplate: function (container) {      //Column template using headerCellTemplate
                    container.append('<b style="color: lightblue;">Action</b>');
                }
            }
        ],
        paging: {
            enabled: true,          //Default value is true
            pageSize: 10,           //Default value is 20
            pageIndex: 0            //Default value is 0
        },
        pager: {
            showNavigationButtons: true,        //Default value is false
            showPageSizeSelector: true,         //Default value is false
            allowedPageSizes: [5, 10, 15, 20, 50],
            showInfo: true,                     //Default value is false
            infoText: 'Page {0} of {1} (Total {2} items)',
            displayMode: 'compact'              //(adaptive, full, compact)
        },
        editing: {
            mode: 'popup',                      //(row, batch, cell, form, popup)
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true,                     //Default value is false
            confirmDelete: false,               //Default value is true
            /*
            This both options only applicable when editing mode is cell/batch
            startEditAction: 'dblClick',        //(click, dblclick)
            selectTextOnEditStart: true,        //Default value is false
            */
            form: {
                items: [{
                    itemType: 'group',
                    caption: 'Personal Information',
                    colCount: 3,                // Total number of columns in one row
                    colSpan: 2,                 // Total space required for item
                    items: ['id', 'name', 'number', 'age', {
                        dataField: 'address',
                        colSpan: 2
                    }]
                }, {
                    itemType: 'group',
                    caption: 'Other',
                    items: ['roomNumber', 'feesPaid']
                }]
            },
            popup: {
                showTitle: true,                //Default value is false
                title: 'Student Information'
            }
        },
        grouping: {
            contextMenuEnabled: true,       //Enable grouping
            autoExpandAll: false,           //Default value is true
            expandMode: 'rowClick',         //(buttonClick, rowClick)
            //allowCollapsing: false          //Default value true
        },
        groupPanel: {
            visible: true,                  //Default value is false
            //allowColumnDragging: false,
            emptyPanelText: 'Drag column to group'
        },
        filterRow: {
            visible: true,
            applyFilter: 'onClick'          //(auto, onClick)
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
            //text: '3'               //Predefine text for search
        },
        filterValue: [                //Predefine the filter value
            ['name', '<>', null],
            'and',
            ['age', '>', 20]
        ],
        sorting: {
            mode: 'multiple',          //(single, multiple, none)
            //showSortIndexes: false   //Default value is true
        },
        selection: {
            mode: 'multiple',
            selectAllMode: 'allPages',      //page or allPages
            allowSelectAll: true,           //Prevent select all record from single button
            showCheckBoxesMode: 'always'    //(onClick, onLongTap, always, none)
        },
        //selectedRowKeys: [98, 96, 90],     //Select rows initially
        stateStoring: {
            enabled: true,
            type: 'sessionStorage',         //(localStorage, sessionStorage, custom)
            storageKey: 'StudentData',
            savingTimeout: 2000,            //Specifies the delay in milliseconds between when a user makes a change and when this change is saved
        },
        summary: {
            totalItems: [
                {
                    column: 'Age',
                    summaryType: 'max',
                    displayFormat: 'Max Age: {0}',
                },
                {
                    column: 'roomNumber',
                    displayFormat: 'Total Rooms: {0}',
                }
            ],
            groupItems: [
                {
                    summaryType: 'count',
                },
                {
                    column: 'age',
                    summaryType: 'max',
                    alignByColumn: true,
                    showInGroupFooter: true,
                    displayFormat: 'Maximum age in this group: {0}'
                }
            ]
        },
        export: {
            enabled: true,
            allowExportSelectedData: true,
            formats: ['pdf', 'xlsx']
        },
        onExporting(e) {
            if (e.format === 'pdf') {
                const doc = new jsPDF();

                DevExpress.pdfExporter.exportDataGrid({
                    jsPDFDocument: doc,
                    component: e.component,
                }).then(() => {
                    doc.save('StudentData.pdf');
                });
            }

            if (e.format === 'xlsx') {
                const workbook = new ExcelJS.Workbook();
                const worksheet = workbook.addWorksheet('StudentList');

                DevExpress.excelExporter.exportDataGrid({
                    component: e.component,
                    worksheet,
                    autoFilterEnabled: true,
                }).then(() => {
                    workbook.xlsx.writeBuffer().then((buffer) => {
                        saveAs(new Blob([buffer], { type: 'application/octet-stream' }), 'StudentData.xlsx');
                    });
                });
            }
        }
    })
});