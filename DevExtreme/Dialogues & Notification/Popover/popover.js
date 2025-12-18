$(() => {
    const popover = $('#container').dxPopover({
        target: '#link1',
        showEvent: 'mouseenter',
        hideEvent: 'mouseleave',
        position: 'top',
        height: 150,
        width: 300,
        showTitle: true,
        showCloseButton: true,
        title: 'This is title',
        shading: true,                          //Default value is false
        shadingColor: 'rgba(0, 0, 0, 0.3)',
        hideOnOutsideClick: false,
    }).dxPopover('instance');
});