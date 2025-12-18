$(() => {
    //Local data for dataSource of grid
    var data = [
        { id: 1, firstName: 'Ajay', lastName: 'Sharma', age: 20, dob: '01-01-2005' },
        { id: 2, firstName: 'Rohit', lastName: 'Verma', age: 22, dob: '12-03-2003' },
        { id: 3, firstName: 'Sneha', lastName: 'Patel', age: 19, dob: '08-07-2006' },
        { id: 4, firstName: 'Vikram', lastName: 'Singh', age: 24, dob: '11-09-2001' },
        { id: 5, firstName: 'Priya', lastName: 'Khan', age: 21, dob: '10-11-2003' },
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
        paging: {
            pageSize: 10
        },
        showBorders: true,          //Show border around dataGrid
        showColumnLines: false,     //Hide vertical column lines
        showRowLines: true,         //Show horizonatal row lines
        rowAlternationEnabled: true //Enable zebra striping in rows
    });
});