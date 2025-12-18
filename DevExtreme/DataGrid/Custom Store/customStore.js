$(() => {
    //API endpoint
    var mockApi = 'https://687f84e0efe65e52008a1051.mockapi.io/dummy/students';

    //Custom store of mock API
    var customStore = new DevExpress.data.CustomStore({
        key: 'id',

        load: () => {
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
        editing: {
            mode: 'form',
            allowAdding: true,
            allowUpdating: true,
            allowDeleting: true,
            useIcons: true
        }
    })
});