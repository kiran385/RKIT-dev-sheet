// Call Methods
$("#popup").dxPopup({
    visible: false,
    closeOnOutsideClick: true,
    contentTemplate: () => {
      const content = $("<div />");
      content.append(
        $("<img />").attr(
          "src",
          "https://images.pexels.com/photos/1563355/pexels-photo-1563355.jpeg?_gl=1*1ih6od6*_ga*MjAwNTE4MDk5Mi4xNzYxODIyODgy*_ga_8JE65Q40S6*czE3NjE4MjI4ODIkbzEkZzEkdDE3NjE4MjI4OTIkajUwJGwwJGgw"
        )
      );
      return content;
    },
  });
  
  var popupInstance = $("#popup").dxPopup("instance");
  
  // Create and Configure a Widget
  $("#buttonContainer").dxButton({
    text: "button",
    type: "success",
    stylingMode: "outlined",
    icon: "add",
  });
  
  // Get a Widget Instance (can only get if widget is initialized)
  var isClicked = false;
  var buttonInstance = $("#buttonContainer").dxButton("instance");
  console.log("Button Instance " + buttonInstance);
  buttonInstance.option({
    onClick: () => {
      // var isClicked = $(this).dxButton("option", "text") === "Click Me";
      // $(this).dxButton("option", {
      //   text: isClicked ? "Clicked!" : "Click Me",
      //   type: isClicked ? "success" : "default",
      //   icon: isClicked ? "favorites" : "add",
      // });
      isClicked = !isClicked;
      buttonInstance.option({
        text: isClicked ? "Clicked!" : "Click Me",
        type: isClicked ? "success" : "default",
      });
      //  $("#popup").dxPopup("show");
      popupInstance.show();
    },
  });
  
  // Get and Set Options
  var buttonIcon = buttonInstance.option("icon");
  console.log("Button Instance " + buttonInstance);
  console.log(buttonIcon);
  
  // Destroy a Widget
  // buttonInstance.dxButton("dispose");