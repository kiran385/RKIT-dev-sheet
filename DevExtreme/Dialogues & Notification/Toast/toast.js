$(() => {
    $('#btnContainer').dxButton({
        text: 'Toast',
        onClick: function () {
            toast.show();
        }
    });

    const toast = $('#container').dxToast({
        message: 'This is toast',
        type: 'success',
        //displayTime: 5000,
        closeOnClick: true,
        hideOnOutsideClick: true,
        position: 'center center',
        shading: true,                      //Default value is false
        shadingColor: 'rgba(0, 0, 0, 0.3)',
    }).dxToast('instance');
})