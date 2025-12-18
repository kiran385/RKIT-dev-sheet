$(() => {
    $('#products-simple').dxSelectBox({
        items: simpleProducts,
        inputAttr: { 'aria-label': 'Simple Product' },
        searchEnabled: true,
    });

    $('#products-placeholder').dxSelectBox({
        items: simpleProducts,
        inputAttr: { 'aria-label': 'Product With Placeholder' },
        placeholder: 'Choose Product',
        showClearButton: true,
    });

    $('#products-disabled').dxSelectBox({
        items: simpleProducts,
        inputAttr: { 'aria-label': 'Disabled Product' },
        value: simpleProducts[0],
        disabled: true,
    });

    $('#products-data-source').dxSelectBox({
        inputAttr: { 'aria-label': 'Product ID' },
        dataSource: new DevExpress.data.ArrayStore({
            data: products,
            key: 'ID',
        }),
        displayExpr: 'Name',
        valueExpr: 'ID',
        value: products[0].ID,
    });

    $("#selectBoxContainer").dxSelectBox({
        dataSource: new DevExpress.data.DataSource({
            store: fruitsVegetables,
            map: function (item) {
                return {
                    key: item.type,
                    items: item.collection
                }
            }
        }),
        grouped: true,
        displayExpr: 'name',
        valueExpr: 'count'
    });

    $('#product-handler').dxSelectBox({
        items: simpleProducts,
        inputAttr: { 'aria-label': 'Product' },
        value: simpleProducts[0],
        onValueChanged(data) {
            DevExpress.ui.notify(`The value is changed to: "${data.value}"`);
        },
    });

});
