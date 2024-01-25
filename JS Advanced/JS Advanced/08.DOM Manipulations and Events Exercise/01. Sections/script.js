function create(words) {
   const contentElement = document.getElementById('content');

   words.forEach(word => {
      const divElement = document.createElement('div');
      const paragraphElement = document.createElement('p');

      paragraphElement.style.display = 'none';
      paragraphElement.textContent = word;

      divElement.addEventListener('click', () => {
         paragraphElement.style.display = 'block';
      })

      divElement.appendChild(paragraphElement);
      contentElement.appendChild(divElement);

   });

}