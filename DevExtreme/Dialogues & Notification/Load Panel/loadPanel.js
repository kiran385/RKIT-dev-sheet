$(() => {
    $('#btnContainer').dxButton({
        text: 'Show Load Panel',
        onClick: function () {
            loadPanel.show()
        }
    });

    const loadPanel = $('#container').dxLoadPanel({
        hideOnOutsideClick: true,
        indicatorSrc: 'https://js.devexpress.com/Content/data/loadingIcons/rolling.svg',
        //showIndicator: false,               //Hides the loading indicator
        message: 'Please wait....',
        //showPane: false,                    //Hides loading pane
        shadingColor: 'rgba(0, 0, 0, 0.3)',
    }).dxLoadPanel('instance');
});