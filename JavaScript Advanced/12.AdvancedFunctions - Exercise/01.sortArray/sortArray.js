function solve (array,criteria) {
    array.sort((a,b) => sortArray(a,b,criteria));
    console.log(array);

    function sortArray(a,b,criteria) {
        if (criteria == 'asc') {
            return a-b;
        } else if (criteria == 'desc') {
            return b-a;
        }
    }
}

solve([14, 7, 17, 6, 8], 'asc');

solve([14, 7, 17, 6, 8], 'desc');