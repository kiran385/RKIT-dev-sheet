sessionStorage.setItem("sessionUser", "Kiran");
localStorage.setItem("localUser", "Baraiya");

console.log("Session Storage:", sessionStorage.getItem("sessionUser"));
console.log("Local Storage:", localStorage.getItem("localUser"));

document.cookie = "user=Kiran; max-age=19; path=/";
document.cookie = "theme=dark; expires=Fri, 31 Dec 9999 23:59:59 GMT";
console.log("Cookies:", document.cookie);

function cacheData(key, data) {
  localStorage.setItem(key, JSON.stringify(data));
}

function getCachedData(key) {
  return JSON.parse(localStorage.getItem(key));
}

cacheData("posts", [{ id: 1, title: "JS Rocks" }]);
console.log("Cached Data:", getCachedData("posts"));

const person = {
  name: "Kiran Baraiya",
  greet() {
    console.log(`Hello, I am ${this.name}`);
  }
};
person.greet();

function Car(brand) {
  this.brand = brand;
}
Car.prototype.drive = function () {
  console.log(`${this.brand} is driving`);
};
const car = new Car("Toyota");
car.drive();

// ES6 class
class Bike {
  constructor(type) {
    this.type = type;
  }

  ride() {
    console.log(`Riding a ${this.type} bike`);
  }
}
const bike = new Bike("mountain");
bike.ride();

class MathUtils {
  static PI = 3.14159;
  static square(n) {
    return n * n;
  }
}
console.log("Static PI:", MathUtils.PI);
console.log("Static Square:", MathUtils.square(5));

var x = 1;
let y = 2;
const z = 3;

x = 10;
y = 20;

console.log("var:", x);
console.log("let:", y);
console.log("const:", z);

class Animal {
  constructor(name) {
    this.name = name;
  }

  speak() {
    console.log(`${this.name} makes a sound.`);
  }
}
const dog = new Animal("Dog");
dog.speak();

const add = (a, b) => a + b;
console.log("Arrow Function Add:", add(2, 3));

async function fetchPost() {
  try {
    const res = await fetch("https://jsonplaceholder.typicode.com/posts/1");
    const data = await res.json();
    console.log("Fetched Post:", data);
  } catch (error) {
    console.error("Fetch Error:", error);
  }
}

console.log("5 == '5':", 5 == "5");   // true
console.log("5 === '5':", 5 === "5"); // false
console.log("5 != '5':", 5 != "5");   // false
console.log("5 !== '5':", 5 !== "5"); // true
