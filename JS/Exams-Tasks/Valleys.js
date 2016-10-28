function solve(args){
    var heights = args[0].split(' ').map(Number),
        lenght = heights.length,
        i,
        j,
        biggestSum = 0,
        currentSum = 0,
        peaksIndexes = [];

    for(i = 0; i < lenght; i += 1){
        if(i === 0){
            peaksIndexes.push(i);
        }
        if(i === lenght - 1){
            peaksIndexes.push(i);
        }

        if(heights[i] > heights[i - 1] && heights[i] > heights[i + 1]){
            peaksIndexes.push(i);
        }
    }

    for(i = 0; i < peaksIndexes.length - 1; i += 1){
        var currentPeakIndex = peaksIndexes[i];
        for(j = currentPeakIndex; j <= peaksIndexes[i + 1]; j += 1){
            currentSum += heights[j];

        }
        if(currentSum >= biggestSum){
            biggestSum = currentSum;
        }

        currentSum = 0;
    }
    console.log(biggestSum);
}

//solve(["5 1 7 4 8"]); //19
//solve(["5 1 7 6 5 6 4 2 3 8"]); //24

