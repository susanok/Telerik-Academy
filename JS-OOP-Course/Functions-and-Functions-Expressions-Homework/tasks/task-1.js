/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(args) {
	var i,
		len,
		sumNumbers = 0;

	if(args.length == 0){
		return null;
	}

	if(!args || args === undefined) {
		throw new Error();
	}

	for(i = 0, len = args.length; i < len; i += 1){
		var num = args[i] * 1;

		if(!isNumber(num)){
			throw new Error();
		}

		sumNumbers += num;
	}

	return sumNumbers;

	function isNumber(obj) {
		return !isNaN(parseFloat(obj))
	}
}

module.exports = sum;