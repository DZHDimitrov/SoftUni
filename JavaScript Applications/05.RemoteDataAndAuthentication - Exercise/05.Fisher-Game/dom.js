export function ce(tag,attributes,...params) {
    const element = document.createElement(tag);
    const firstValue = params[0];

    if (params.length === 1 && typeof(firstValue) !== 'object') {
        if (['input','textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    }else {
        element.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(x=> {
            element.setAttribute(x,attributes[x])
        });
    }

    return element;
}