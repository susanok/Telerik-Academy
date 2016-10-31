/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/

function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		//list different books by author, by category or all
		function listBooks(args) {
			var listedBooks = [];
			if(args){

				// by author or category
				var byAuthor,
					a,
					booksLenght;
				if(args.author){
					byAuthor = true;
				} else { // by category
					byAuthor = false;
				}

				for(a = 0, booksLenght = books.length; a < booksLenght; a += 1){
					if(byAuthor){
						if(args.author === books[a].author){
							listedBooks.push(books[a]);
						}
					} else {
						if(args.category === books[a].category){
							listedBooks.push(books[a]);
						}
					}
				}

				return listedBooks;
			} else {
				// all books
				return books;
			}
		}

		function addBook(book) {
			var counterCategoris,
				categoriesLenght,
				counterTitles,
				bookslenght,
				hasSuchCategory = false;

			// check for existing title and its lenght
			if(!book.title || book.title.length < 2 || book.title.length > 100
				|| book.category.length < 2 || book.category.length > 100){
				throw new Error();
			}

			// check for existing author
			if(!book.author || book.author === ''){
				throw new Error();
			}

			// check for existing isbn and its lenght
			if(!book.isbn || (book.isbn.toString().length !== 10 && book.isbn.toString().length !== 13)){
				throw new Error();
			}

			// check for repeating title ot isbn
			if(books.length > 0){
				for(counterTitles = 0, bookslenght = books.length; counterTitles < bookslenght; counterTitles += 1){
					if(book.title === books[counterTitles].title || book.isbn === books[counterTitles].isbn){
						throw new Error();
					}
				}
			}


			book.ID = books.length + 1;
			books.push(book);

			//check for the category in categories list
			for(counterCategoris = 0, categoriesLenght = categories.length; counterCategoris < categoriesLenght; counterCategoris += 1){
				if(book.category === categories[counterCategoris]){
					hasSuchCategory = true;
					break;
				}
			}

			if(!hasSuchCategory){
				book.category.id = categories.length + 1;
				categories.push(book.category);

			}
			return book;
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}
module.exports = solve;



