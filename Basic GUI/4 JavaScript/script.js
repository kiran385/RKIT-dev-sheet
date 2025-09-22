// Generate random number on load
function onloadNumber(){
    const number = Math.floor(Math.random() * 100);
    document.getElementById("load").innerHTML = "Generate new number by refreshing page: <b>" + number + "</b>";
}

// document.getElementById('btn1').value = "Initial Value";

document.getElementById('submit').addEventListener('click', function(){
    // const value = document.getElementById('btn1').value;
    console.log(`This is onclick`);
})

document.getElementById('btn1').addEventListener('change', function(value){
    console.log(value);
})
