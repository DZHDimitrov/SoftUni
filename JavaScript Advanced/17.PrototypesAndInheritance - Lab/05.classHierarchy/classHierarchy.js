function solve() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(value) {
            this.units = value;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }

        calculate(param) {
            switch (this.units) {
                case 'm':
                    param /= 10;
                    break;
                case 'cm':
                    break;
                case 'mm':
                    param *= 10;
                    break;
                default:
                    break;
            }
            return param;
        }
    }

    class Circle extends Figure {
        constructor(radius,units) {
            super(units);
            this._radius = radius;
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }

        get radius() {
            return this.calculate(this._radius);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
        }
    }

    class Rectangle extends Figure {
        constructor(width, height,units = 'cm') {
            super(units);
            this._width = width;
            this._height = height;
        }

        get area() {
            return this.width * this.height;
        }

        get width() {
            return this.calculate(this._width);
        }
        get height() {
            return this.calculate(this._height);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle,
    }

}

solve();
