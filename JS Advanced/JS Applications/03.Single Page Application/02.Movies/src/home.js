const url = 'http://localhost:3030/data/movies';
const homeSection = document.getElementById('home-page');
const movieList = homeSection.querySelector('#movies-list');

export function renderHome() {
    homeSection.style.display = 'block';
    loadMoviesAsync();
}

function loadMoviesAsync() {
    fetch(url)
        .then(res => res.json())
        .then(data => {
            movieList.innerHTML = '';
            Object.values(data).forEach(m => {
                movieList.appendChild(createMoviePreview(m));
            })
        })
        .catch(err => console.log(err))
}

function createMoviePreview(movie) {
    const element = document.createElement('div');
    element.className = 'card mb-4';
    element.innerHTML = `
    <img src="${movie.img}" class="card-img-top">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a href="/details/${movie._id}">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>
    `

    return element;
}