function solve(area,vol,input) {
    let result = JSON.parse(input).reduce((acc,el) => {
        acc.push({
            area: area.call(el),
            volume: vol.call(el)
        });
        return acc;
    },[])
    console.log(result);
}
function area() {
    return Math.abs(this.x * this.y);
};
function vol() {
    return Math.abs(this.x * this.y * this.z);
};

const input = `[
    {"x":"10","y":"-22","z":"10"},
    {"x":"47","y":"7","z":"-5"},
    {"x":"55","y":"8","z":"0"},
    {"x":"100","y":"100","z":"100"},
    {"x":"55","y":"80","z":"250"}
    ]
    `
solve(area,vol,input)