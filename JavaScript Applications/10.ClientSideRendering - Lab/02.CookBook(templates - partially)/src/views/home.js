import {html} from '../../node_modules/lit-html/lit-html.js';
import { e } from '../dom.js';
import { getRecent } from '../api/data.js';


const homeTemplate = (recipes,onClick) => html`
<section id="home">
    <div class="hero">
        <h2>Welcome to My Cookbook</h2>
    </div>
    <header class="section-title">Recently added recipes</header>
    <div class="recent-recipes" @click=${onClick}>${recipes}</div>
    <footer class="section-title">
        <p>Browse all recipes in the <a href="/catalog">Catalog</a></p>
    </footer>
</section>`;

const previewTemplate = (recipe) => html`
<article class="recent" data-id=${recipe._id}>
    <div class="recent-preview">
        <img src=${recipe.img}>
    </div>
    <div class="recent-title">${recipe.name}</div>
</article>
`;

const spacer = () => html`<div class="recent-space"></div>`;

export function setupHome(section, nav) {
    return showHome;

    async function showHome() {
        const recipes = await getRecent();
        const cards = recipes.map(previewTemplate);
        const result = [];

        cards.forEach((x,i) => {
            result.push(x);
            if (i < cards.length - 1) {
                result.push(spacer());
            }
        })

        return homeTemplate(result,onClick);
    }

    function onClick(event) {
        let article = event.target;
        while (article.tagName !== 'ARTICLE' && article !== event.currentTarget) {
            article = article.parentNode;
        }
        if (article.dataset.id) {
            nav.goTo('details',article.dataset.id);
        }
    }
}