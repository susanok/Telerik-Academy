/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	var min = start * 1,
		max = end * 1,
		primes = [];

	if(realTypeOf(min) !== 'Number' || realTypeOf(max) !== 'Number' || !max){
		throw new Error();
	}

	if(!min){
		if(min !== 0){
			throw new Error();
		}
	}

	for(i = min; i <= max; i += 1){
		if(isPrime(i)){
			primes.push(i);
		}
	}

	return primes;

	function realTypeOf(obj) {
		return Object.prototype.toString.call(obj).slice(8, -1);
	}

	function isPrime (n)
	{
		if (n < 2){
			return false;
		}

		var q = Math.floor(Math.sqrt(n));

		for (var i = 2; i <= q; i++)
		{
			if (n % i == 0)
			{
				return false;
			}
		}

		return true;
	}
}

module.exports = findPrimes;

