function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        result,
        previous,
        current,
        next,
        i,
        newArr,
        j,
        sum,
        arrays = new Array(nk[1] + 1);

    arrays[0] = s;
    for(i = 0; i < nk[1]; i += 1){
        newArr  = new Array(nk[0]);
        for(j = 0; j < nk[0]; j += 1){
            if(j === 0){
                previous = arrays[i][arrays[i].length - 1];
                current = arrays[i][j];
                next = arrays[i][j + 1];
            }
            else if(j === nk[0] - 1){
                previous = arrays[i][j - 1];
                current = arrays[i][j];
                next = arrays[i][0];
            }
            else{
                previous = arrays[i][j - 1];
                current = arrays[i][j];
                next = arrays[i][j + 1];
            }

            if(current === 0){
                newArr[j] = Math.abs(previous - next);
            }
            else if(current === 1){
                newArr[j] = previous + next;
            }
            else if(current % 2 === 0){
                newArr[j] = Math.max(previous, next);
            }
            else if(current % 2 !== 0){
                newArr[j] = Math.min(previous, next);
            }
        }

        sum = 0;
        for(j = 0; j < nk[0]; j += 1){
            sum += newArr[j];
        }


        arrays[i + 1] = newArr;
    }
    console.log(sum);

}

//solve(['5 1','9 0 2 4 1']);
//solve(['10 3','1 9 1 9 1 9 1 9 1 9']);
//solve(['10 10','0 1 2 3 4 5 6 7 8 9']);

