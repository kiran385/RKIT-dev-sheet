// class railwayForm{
//     constructor(name,train){
//         this.name = name;
//         this.train = train;
//     }
//     submit(){
//         alert(this.name + ' your form submitted successfully and train number is ' + this.train);
//     }
//     cancel(){
//         alert(this.name + ' your form cancelled successfully');
//         this.train = 0;
//     }
// }

// let kiranForm = new railwayForm("Kiran",14200);

// kiranForm.submit()
// kiranForm.cancel()


// function toCelsius(f) {
//   return (5/9) * (f-32);
// }

// let value = toCelsius(77);
// document.getElementById("demo").innerHTML = value;

// const person = new Object();
// person.firstName = "Kiran";
// person.lastName = "Baraiya";
// person.age = 19;
// person.fullName = function(){
//     return this.firstName + " " + this.lastName;
// }

// document.getElementById("demo").innerText = person.fullName() + " is " + person.age + " years old";
// document.getElementById('demo').innerHTML = typeof person;


// const cars = ["Audi", "BMW", "Mercedes"];

// let text = "<ul>";
// cars.forEach(func);
// text += "</ul>";

// document.getElementById("demo").innerHTML = text;

// function func(value) {
//   text += "<li>" + value + "</li>";
// }


// const numbers = [1,2,3,4,5];

// let text = "";
// // numbers.forEach(func);
// let over3 = numbers.filter(func);

// function func(value){
//   // text += value + "<br>";
//   return value>3;
// }

// // document.getElementById("demo").innerHTML = over3;

// const button = document.getElementById("click");
// button.addEventListener("click", () => {
//   console.log("Button clicked!");
// });

// let n = "";
// for(let i=0;i<numbers.length;i++){
//   n += numbers[i] + " ";
// }

// for(let i in numbers){
//   n += numbers[i] + " ";
// }

// for(let x of numbers){
//   n += x + " ";
// }

// numbers.forEach(function(value){
//   n += value + " ";
// })

// let n = "";
// const person = { name:"Kiran",age:19};
// Object.keys(person).forEach(k => {
//   n += "value of " + k + " is " + person[k] + "<br>";
// })

// document.getElementById("demo").innerHTML =  n;


// try{
//   allert('Hello');
// }
// catch(err){
//   document.getElementById("demo").innerHTML = err;
// }

// const person = {
//   firstName: "Kiran",
//   lastName: "Baraiya",
//   language: "en",
//   addr: "",
//   get lang() {
//     return this.language.toUpperCase();
//   },
//   set add(add){
//     this.addr = add;
//   }
// };

// person.add = "Botad";
// // Display data from the object using a getter:
// document.getElementById("demo").innerHTML = person.addr;