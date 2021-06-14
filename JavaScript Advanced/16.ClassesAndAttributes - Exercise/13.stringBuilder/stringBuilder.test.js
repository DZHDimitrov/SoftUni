const {assert} = require('chai');
const StringBuilder = require('./stringBuilder');

describe('StringBuilder', ()=>{
    it('constructor', () => {
        let instance = new StringBuilder('asdf');
        assert.deepEqual(instance._stringArray,['a','s','d','f']);
        assert.equal(instance._stringArray.length,4);
        instance = new StringBuilder();
        assert.deepEqual(instance._stringArray,[]);
        instance = new StringBuilder(undefined);
        assert.deepEqual(instance._stringArray,[]);
        assert.equal(instance._stringArray.length,0);

        assert.throws(() => instance = new StringBuilder(1),TypeError,'Argument must be а string');
        assert.throws(() => instance = new StringBuilder(['asd','asdf']),TypeError,'Argument must be а string');
        assert.doesNotThrow(() => instance = new StringBuilder());
        assert.doesNotThrow(() => instance = new StringBuilder(undefined));
    });

    it('append', () => {
        let instance = new StringBuilder('asdf');
        let text = 'qwerty';
        instance.append(text);
        assert.deepEqual(instance._stringArray,['a','s','d','f','q','w','e','r','t','y']);

        assert.throws(() => instance.append(1),TypeError,'Argument must be а string');
        assert.throws(() => instance.append(['asd','asdf']),TypeError,'Argument must be а string');
        assert.throws(() => instance.append(undefined),TypeError,'Argument must be а string');

        instance = new StringBuilder();
        text = 'qwe';
        instance.append(text);
        assert.deepEqual(instance._stringArray,['q','w','e']);
    });

    it('prepend', () => {
        let instance = new StringBuilder('qwe');
        let text = 'something';
        instance.prepend(text);
        assert.deepEqual(instance._stringArray,['s','o','m','e','t','h','i','n','g','q','w','e']);

        assert.throws(() => instance.prepend(15),TypeError,'Argument must be а string');
        assert.throws(() => instance.prepend(['qwerty','another']),TypeError,'Argument must be а string');
        assert.throws(() => instance.prepend(undefined),TypeError,'Argument must be а string');

        instance = new StringBuilder();
        instance.prepend('text');
        assert.deepEqual(instance._stringArray,['t','e','x','t']);
    });

    it('insertAt', () => {
        let instance = new StringBuilder('something');
        let text = 'another';
        instance.insertAt(text,1);

        assert.deepEqual(instance._stringArray,['s','a','n','o','t','h','e','r','o','m','e','t','h','i','n','g']);

        assert.throws(() => instance.insertAt(['qwe','test'],1),TypeError,'Argument must be а string');
        assert.throws(() => instance.insertAt(5,1),TypeError,'Argument must be а string');
        assert.throws(() => instance.insertAt(undefined,1),TypeError,'Argument must be а string');
    });

    it('remove', () => {
        let instance = new StringBuilder('qwerty');
        instance.remove(0,5);
        assert.deepEqual(instance._stringArray,['y']);
        instance = new StringBuilder('qwerty');
        instance.remove(1,100);
        assert.deepEqual(instance._stringArray,['q']);
        instance = new StringBuilder('qwerty');
        instance.remove(0,100);
        assert.deepEqual(instance._stringArray,[]);
    });

    it('toString', () => {
        let instance = new StringBuilder('PeshoGosho');
        instance.remove(0,100);
        instance.append('qwerty');
        assert.equal(instance.toString(),'qwerty');

        instance = new StringBuilder();
        assert.doesNotThrow(()=> instance.toString());

        instance.prepend('Hello');
        instance.append('Hey');
        assert.equal(instance.toString(),'HelloHey');
    });
    it('test', () =>{

    });
});