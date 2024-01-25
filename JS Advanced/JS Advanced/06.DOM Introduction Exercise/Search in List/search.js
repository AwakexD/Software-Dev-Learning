function search() {
   let townList = document.querySelectorAll('ul li');
   let searchFor = document.getElementById('searchText').value;
   let resultDiv = document.getElementById('result')

   let mathesFound = 0;

   Array.from(townList).forEach(element => {
      if (element.textContent.includes(searchFor)) {
         element.innerHTML = `<b><u> ${element.textContent} </u></b>`
         mathesFound++;
      } else {
         element.innerHTML = `${element.textContent}`
      }
   });


   resultDiv.textContent = `${mathesFound} matches  found`
}
