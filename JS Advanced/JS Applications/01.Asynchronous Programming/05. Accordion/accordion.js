async function solution() {
   const res = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');

   const data = await res.json();

    Object.values(data).forEach((article) => {
        const accordionDiv = document.createElement('div');
        accordionDiv.classList.add('accordion');
     
        const headDiv = document.createElement('div');
        headDiv.classList.add('head');
        accordionDiv.appendChild(headDiv);
     
        const titleSpan = document.createElement('span');
        titleSpan.textContent = article.title;
        headDiv.appendChild(titleSpan);
        
        const expandButton = document.createElement('button');
        expandButton.classList.add('button');
        expandButton.id = article._id;
        expandButton.textContent = 'More';
        expandButton.addEventListener('click', ASyncArticleInfo);
        headDiv.appendChild(expandButton);

        const extraDiv = document.createElement('div');
        extraDiv.classList.add('extra');
        extraDiv.style.display = 'None'
        accordionDiv.appendChild(extraDiv);

        const p = document.createElement('p');
        extraDiv.appendChild(p);

        document.getElementById('main').appendChild(accordionDiv);
        
        async function ASyncArticleInfo() {
            url = 'http://localhost:3030/jsonstore/advanced/articles/details';
    
            let res = await fetch(`${url}/${this.id}`);
            const data = await res.json();
    
            if (extraDiv.style.display === 'none') {
                p.textContent = data.content;
                extraDiv.style.display = 'block';
                expandButton.textContent = 'Less'
            } else {
                p.textContent = '';
                extraDiv.style.display = 'none';
                expandButton.textContent = 'More';
            }
        }
    });

}

solution();