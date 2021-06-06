function getArticleGenerator(articles) {
    return () => {
        if (articles.length > 0) {
            let newElement = document.createElement('article');
            newElement.textContent = articles.shift();
            document.getElementById('content').appendChild(newElement)
        }
    }
}
