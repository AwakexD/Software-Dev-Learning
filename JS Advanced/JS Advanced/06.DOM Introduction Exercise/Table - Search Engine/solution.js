function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let rows = document.querySelectorAll('.container tbody tr');
   
   function onClick() {
      let searchFor = document.getElementById('searchField').value;
      
      for (const row of rows) {
         if (searchFor !== '' && row.innerHTML.includes(searchFor)) {
            row.classList.add('select');
         } else {
            row.classList.remove('select')
         }
      }
   }
}