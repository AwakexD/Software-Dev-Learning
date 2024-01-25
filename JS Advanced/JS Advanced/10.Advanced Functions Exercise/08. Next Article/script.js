function getArticleGenerator(articles) {
    let articlesArrray = articles;
    let article = document.getElementById('content'); 

    return () => {
        if (articlesArrray.length <= 0) {
            return
        }

        let articleElement = document.createElement('article');
        articleElement.textContent = articlesArrray.shift();
        article.appendChild(articleElement);
    }
}
