const {assert} = require('chai');
const ChristmasMovies = require('./02. Christmas Movies_Resources (1)');

describe("ChristmasMovies", function() {
    describe("Constructor", function() {
        it("Should be instantiated with no parameters", function() {
            let myInstance = new ChristmasMovies();

            assert.deepEqual(myInstance.movieCollection,[])
            assert.deepEqual(myInstance.watched,{})
            assert.deepEqual(myInstance.actors,[])
        });
     });
     describe("BuyMovie", function() {
        it("Should throw an error when the movie exists", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Jet Lee','Bruce Willis']);
            assert.throws(() => myInstance.buyMovie('Titanic',['Bruce Willis']),`You already own Titanic in your collection!`);
        });
        it("Should add the movie successfully when does not exist", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee']);
            assert.deepEqual(myInstance.movieCollection,[{name: 'Titanic',actors:['Bruce Willis','Jet Lee']}]);
            assert.equal(myInstance.buyMovie('FastAndFurious',['Dwayne Johnson','Jessica Alba']),`You just got FastAndFurious to your collection in which Dwayne Johnson, Jessica Alba are taking part!`)
        })
        it("Should add only unique actors to movie", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            assert.deepEqual(myInstance.movieCollection,[{name: 'Titanic',actors:['Bruce Willis','Jet Lee']}]);
        });
     });
     describe("discardMovie", function() {
        it("Should be throw an error when movie does not exist", function() {
            let myInstance = new ChristmasMovies();
            assert.throws(() => {myInstance.discardMovie('Titanic'),`Titanic is not at your collection!`})
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            assert.throws(() => {myInstance.discardMovie('FastAndFurious'),`Titanic is not at your collection!`})
        });
        it("Should be throw an error when movie is not watched", function() {
            let myInstance = new ChristmasMovies();
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);

            assert.throws(() => {myInstance.discardMovie('Titanic'),`Titanic is not watched!`})
        });
        it("Should remove movie from watchlist if it's watched", function() {
            let myInstance = new ChristmasMovies();
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.watched = {'Titanic':5,'FastAndFurious': 2};
            
            myInstance.discardMovie('Titanic');
            assert.deepEqual(myInstance.watched,{'FastAndFurious': 2});
            assert.equal(myInstance.watched['Titanic'],undefined);

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.buyMovie('FastAndFurious',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.watched = {'Titanic':5,'FastAndFurious':3}

            myInstance.discardMovie('FastAndFurious');

            assert.deepEqual(myInstance.watched,{'Titanic':5});
        });
        it('Should return proper message when remove film from watchlist', function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.watched = {'Titanic':5};

            assert.equal(myInstance.discardMovie('Titanic'),`You just threw away Titanic!`)
        })
     });
     describe("WatchMovie", function() {
        it("Should be throw an error when movie does not exist", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            assert.throws(() => {myInstance.watchMovie('Pohahontas')});
        });
        it("Should add the movie to the watchlist when it is not watched and set number to 1", function() {
            let myInstance = new ChristmasMovies();
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.watchMovie('Titanic');
            
            assert.deepEqual(myInstance.watched,{'Titanic': 1});
            assert.equal(myInstance.watched['Titanic'],1);
            myInstance.watchMovie('Titanic');
            assert.equal(myInstance.watched['Titanic'],2);
        });
        it("Should increment watch movie list when it is already watched", function() {
            let myInstance = new ChristmasMovies();
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('Titanic');

            assert.deepEqual(myInstance.watched,{'Titanic': 5});
        });

     });
     describe("favouriteMovie", function() {
        it("Should throw an error when there are no watched movies in the collection", function() {
            let myInstance = new ChristmasMovies();

            assert.throws(() => {myInstance.favouriteMovie(),'You have not watched a movie yet this year!'})
            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            assert.throws(() => {myInstance.favouriteMovie(),'You have not watched a movie yet this year!'})
        });
        it("Should return most watched film during the current year", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.buyMovie('FastAndFurious',['Dwayne Johnson','Will Smith','Jet Lee']);
            myInstance.buyMovie('HarryPotter',['Daniel Pt','William Has','Jennifer Rose']);

            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('Titanic');
            myInstance.watchMovie('FastAndFurious');
            myInstance.watchMovie('FastAndFurious');
            myInstance.watchMovie('HarryPotter');
            myInstance.watchMovie('HarryPotter');
            myInstance.watchMovie('HarryPotter');

            assert.equal(myInstance.favouriteMovie(),`Your favourite movie is HarryPotter and you have watched it 3 times!`)
        });
     });
     describe("mostStarredActor", function() {
        it("Should throw an error when there are no watched films in the collection for this year", function() {
            let myInstance = new ChristmasMovies();

            assert.throws(() => myInstance.mostStarredActor(),'You have not watched a movie yet this year!');
        });
        it("Should return the most starred actor from the collection for this year", function() {
            let myInstance = new ChristmasMovies();

            myInstance.buyMovie('Titanic',['Bruce Willis','Jet Lee','Jet Lee']);
            myInstance.buyMovie('FastAndFurious',['Dwayne Johnson','Will Smith','Jet Lee']);
            myInstance.buyMovie('HarryPotter',['Daniel Pt','William Has','Jennifer Rose']);

            assert.equal(myInstance.mostStarredActor(),`The most starred actor is Jet Lee and starred in 2 movies!`);
        });
     });
     // TODO: …
});
