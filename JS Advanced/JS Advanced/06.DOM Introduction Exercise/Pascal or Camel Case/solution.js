function solve() {
  let input = document.getElementById('text').value;
  let convention = document.getElementById('naming-convention').value;

  let result = '';
  let isFirstCharacter = null;

  if (convention === 'Camel Case') {
    //this is an exapmle

    for (let i = 0; i < input.length; i++) {
      if (input[i] === ' ') {
        result += (input[i + 1].toUpperCase());
        i++
      } else {
        result += input[i].toLowerCase();
      }
    }
    
  } else if (convention === 'Pascal Case'){

    for (let i = 1; i < input.length; i++) {
      if (input[i] === ' ') {
        isFirstCharacter = true;
      } else {
        if (isFirstCharacter) {
          result += input[i].toUpperCase();
          isFirstCharacter = false;
        } else {
          result += input[i].toLowerCase();
        }
      }
    }
    
  } else {
    result = 'Error!'
  }

  let resultElemenet = document.getElementById('result');
  resultElemenet.textContent = result;
} 