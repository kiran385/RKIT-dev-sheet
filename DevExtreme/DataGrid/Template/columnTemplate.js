$(() => {
    var data = [
        { id: 1, name: 'User1', age: 20, image: 'https://picsum.photos/100?random=1' },
        { id: 2, name: 'User2', age: 17, image: 'https://picsum.photos/100?random=2' },
        { id: 3, name: 'User3', age: 21, image: 'https://picsum.photos/100?random=3' },
    ]

    $('#gridContainer').dxDataGrid({
        dataSource: data,
        columns: [
            {
                dataField: 'id',
                alignment: 'center'
            },
            {
                dataField: 'image',
                alignment: 'center',
                allowSorting: false,
                cellTemplate: function (container, options) {
                    console.log(options);
                    $('<img>')
                        .attr('src', options.value)
                        .attr('alt', 'Profile image')
                        .css({
                            width: '100px',
                            height: '100px',
                            'border-radius': '20px'
                        })
                        .appendTo(container);
                }
            },
            {
                dataField: 'name',
                alignment: 'center',
                headerCellTemplate: function (container) {
                    container.append('<b style="color: red; font-size: 20px;">User Name</b>');
                }
            },
            {
                dataField: 'age',
                alignment: 'center',
                cellTemplate: function (container, options) {
                    $("<span>")
                        .text(options.value) 
                        .css({
                            color: options.value < 18 ? 'red' : 'green',
                            'font-size': '18px',
                            'font-weight': 'bold'
                        })
                        .appendTo(container);
                }
            },
        ]
    });
});