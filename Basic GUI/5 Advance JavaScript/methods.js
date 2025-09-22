// Export an async function 
export async function fetchData() {
  const response = await fetch('https://api.github.com/users/kiran385');
  return response.json();
}