$(() => {
    $('#btnContainer').dxButton({
        text: 'Toggle load indicator',
        onClick: function () {
            const isLoadIndicatorVisible = loadIndicator.option('visible');
            loadIndicator.option('visible', !isLoadIndicatorVisible)
        }
    });

    const loadIndicator = $('#container').dxLoadIndicator({
        visible: false,
        height: 60,
        width: 60,
        indicatorSrc: 'https://js.devexpress.com/Content/data/loadingIcons/rolling.svg'
    }).dxLoadIndicator('instance');
});