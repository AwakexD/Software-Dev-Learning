function solve() {
  const [inputBox, outputBox] = Array.from(document.querySelectorAll('textarea'));
  const [generatebutton, buyButton] = Array.from(document.querySelectorAll('button'));
  const tableBodyElement = document.querySelector('table[class="table"] tbody');
  let furnitureList = [];

  
  generatebutton.addEventListener('click', () => {
    console.log(Array.from(inputBox.value));
  });

  
}

//TODO
