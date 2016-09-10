function solve(){
    "use strict";
    function* idGenerator(){
        let index = 0;

        while(true){
            yield(index += 1);
        }
    }

    const CONSTANTS = {
        STRING_MIN_LENGHT: 2,
        NAME_MAX_LENGHT: 40,
        GENRE_MAX_LENGHT: 20,
        ISBN_TEN_SYMBOLS: 10,
        ISBN_THIRTEEN_SYMBOLS: 13,
        RATING_MIN: 1,
        RATING_MAX: 5,
        ZERO: 0
    };

    const validator = {
        validateEmptyString: function (value, name) {
            name = name || 'Value';
            if (value === "") {
                throw new Error(name + ' must be a non empty string');
            }
        },
        validateUndefinedParameter: function (value, name) {
            name = name || 'Value';
            if (value === undefined) {
                throw new Error(name + ' must not be undefined');
            }
        },
        validateStringLenght: function (value, min, max, name) {
            name = name || 'Value';
            if (value.length < min || value.length > max) {
                throw new Error(name + ' must be between ' + min + " and " + max + ' symbols');
            }
        },
        validateLenghtForISBN: function (value, name){
            name = name || 'Value';
            if (value.length !== CONSTANTS.ISBN_TEN_SYMBOLS && value.length !== CONSTANTS.ISBN_THIRTEEN_SYMBOLS) {
                throw new Error(name + ' must be exactly ' + CONSTANTS.ISBN_TEN_SYMBOLS +
                    " or " + CONSTANTS.ISBN_THIRTEEN_SYMBOLS + ' symbols');
            }
        },
        validateOnlyDigits: function (value, name){
            var isNum = /^\d+$/.test(value);

            if(!isNum){
                throw new Error(name + 'can contain only digits');
            }
        },
        validateNumberForRating: function (value, name){
            name = name || 'Value';

            if(typeof value !== 'Number'){
                throw new Error(name + 'is not a number');
            }

            if(value < CONSTANTS.RATING_MIN || value > CONSTANTS.RATING_MAX){
                throw new Error(name + ' must be a number between ' + CONSTANTS.RATING_MIN +
                ' and ' + CONSTANTS.RATING_MAX);
            }
        },
        validateNumberGreaterThanZero: function (value, name){
            name = name || 'Value';

            if(typeof value !== 'number'){
                throw new Error(name + 'is not a number');
            }

            if(value <= CONSTANTS.ZERO){
                throw new Error(name + ' must be a number greater than ' + CONSTANTS.ZERO);
            }
        }
    };


    let itemsIdGenerator = idGenerator();

    class Item {
        constructor(name, description){
            this.id = itemsIdGenerator.next().value;
            this.name = name;
            this.description = description;
        }

        get name (){
            return this._name;
        }

        set name (value){
            validator.validateUndefinedParameter(value, 'Item name');
            validator.validateEmptyString(value, 'Item name');
            validator.validateStringLenght(value, CONSTANTS.STRING_MIN_LENGHT, CONSTANTS.NAME_MAX_LENGHT, 'Item name');
            this._name = value;
        }

        get description (){
            return this._description;
        }

        set description (value){
            validator.validateUndefinedParameter(value, 'Item description');
            validator.validateEmptyString(value, 'Item description');
            this._description = value;
        }
    }

    class Book extends Item{
        constructor (name, isbn, genre, description){
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        get isbn (){
            return this._isbn;
        }

        set isbn (value){
            validator.validateUndefinedParameter(value, 'ISBN');
            validator.validateEmptyString(value, 'ISBN');
            validator.validateLenghtForISBN(value, 'ISBN');
            validator.validateOnlyDigits(value, 'ISBN');
            this._isbn = value;
        }

        get genre (){
            return this._genre;
        }

        set genre (value){
            validator.validateUndefinedParameter(value, 'Genre');
            validator.validateEmptyString(value, 'Genre');
            validator.validateStringLenght(value, CONSTANTS.STRING_MIN_LENGHT, CONSTANTS.GENRE_MAX_LENGHT, 'Genre');
            this._genre = value;
        }
    }

    class Media extends Item {
        constructor (name, rating, duration, description){
            super(name, description);
            this.rating = rating;
            this.duration = duration;
        }

        get rating (){
            return this._rating;
        }

        set rating (value){
            validator.validateUndefinedParameter(value, 'Rating');
            validator.validateNumberForRating(value, 'Rating');
            this._rating = value;
        }

        get duration () {
            return this._duration;
        }

        set duration (value) {
            validator.validateUndefinedParameter(value, 'Duration');
            validator.validateNumberGreaterThanZero(value, 'Duration');
            this._duration = value;
        }
    }

    let catalogsIdGenerator = idGenerator();

    class Catalog {
        constructor (name){
            this._id = catalogsIdGenerator.next().value;
            this.name = name;
            this._items = [];
        }

        get name (){
            return this._name;
        }

        set name (value) {
            validator.validateUndefinedParameter(value, 'Catalog name');
            validator.validateEmptyString(value, 'Catalog name');
            validator.validateStringLenght(value, CONSTANTS.STRING_MIN_LENGHT, CONSTANTS.NAME_MAX_LENGHT, 'Catalog name');
            this._name = value;
        }

        add(){
            if(arguments.length === 0){
                throw new Error('Add should have arguments');
            }

            let items;
            if(Array.isArray(arguments[0])){
                items = arguments[0];
            } else {
                items = [];
                for(let i = 0, len = arguments.length; i < len; i += 1){
                    items.push(arguments[i]);
                }
            }

            if(items.length === 0){
                throw new Error('Array must not be empty');
            }

            for(let i = 0, len = items.length; i < len; i += 1){
                if(!this._itemLikeObjectValidation(items[i])){
                    throw new Error('Item must be an instance of an Item class');
                }
            }

            for(let i = 0, len = items.length; i < len; i += 1){
                this._items.push(items[i]);
            }

            return this;
        }

        find(){
            if(arguments === "undefined" || arguments.length === 0){
                throw new Error('Invalid options');
            }

            let options,
                isSingleResult = false;

            if(typeof arguments[0] === "number"){
                options = {
                    id: arguments[0]
                };

                isSingleResult = true;
            }

            if(typeof arguments[0] === "object"){
                options = arguments[0];
            }

            if(typeof options !== "object"){
                throw new Error('Invalid options');
            }

            let result = this._items.filter(item => {
                return Object.keys(options)
                    .every(key => item[key] === options[key]);
            });

            return (!isSingleResult) ? result : (result.length) ? result[0] : null;
        }

        search(pattern){
            validator.validateUndefinedParameter(pattern, "Pattern");
            validator.validateEmptyString(pattern, "Pattern");
            validator.validateNumberGreaterThanZero(pattern.length, "Pattern");

            let patternToLower = pattern.toLowerCase();

            return this._items.filter(item =>
            item.name.toLowerCase().includes(pattern) ||
            item.description.toLowerCase().includes(pattern));
        }

        _itemLikeObjectValidation(item){
            return (item instanceof Item) ||
                (typeof item.id === 'number' &&
                typeof  item.name === 'string' &&
                typeof  item.description === 'string');
        }
    }

    class BookCatalog extends Catalog {
        constructor (name){
            super(name);
        }

        _itemLikeObjectValidation(item){
            return super._itemLikeObjectValidation(item) &&
                ((item instanceof Book) ||
                    (typeof item.isbn === "string" &&
                    typeof item.genre === "string"));
        }

        getGenres(){
            let genres = [];
            this._items.forEach(item => {
                genres[item.genre] = true;
            });

            return Object.keys(genres);
        }
    }

    class MediaCatalog extends Catalog {
        constructor (name){
            super(name);
        }

        _itemLikeObjectValidation(item){
            return super._itemLikeObjectValidation(item) &&
                ((item instanceof Media) ||
                    (typeof item.rating === "number" &&
                     typeof item.duration === "number"));
        }

        getTop(count){
            validator.validateNumberGreaterThanZero(count, "Get top count");

            return this._items.sort((x, y) => x.rating - y.rating)
                .slice(0, count)
                .map(item => {
                    return {
                        id: item.id,
                        name: item.name
                    };
                });
        }

        getSortedByDuration(){
            return this._items
                .sort((x, y) => (y.duration - x.duration === 0) ? (y.duration - x.duration) : (x.id - y.id));
        }
    }

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}

var module = solve();
var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);

console.log(catalog.getGenres());

//console.log(catalog.find(book1.id));
////returns book1
//
//console.log(catalog.find({id: book2.id}));
////returns book2
//
//console.log(catalog.search('js'));
//// returns book2
//
//console.log(catalog.search('javascript'));
////returns book1 and book2
//
//console.log(catalog.search('Te sa zeleni'))
////returns []
