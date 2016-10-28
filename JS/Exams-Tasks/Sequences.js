function solve(params) {
    var n = parseInt(params[0]),
        i,
        count = 0,
        sequence = true,
        current,
        next,
        arr = new Array(n),
        j;
    for(i = 1, j = 0; i < n + 1; i+= 1, j += 1){
        arr[j] = +params[i];
    }

    for(i = 0; i < n; i += 1){
        if(i !== n -1){
            current = arr[i];
            next = arr[i + 1];
            if(next < current){
                count += 1;
            }
        }
        else{
            count += 1;
        }
    }

    console.log(count);
}

//solve([ '7', '1', '2', '-3', '4', '4', '0', '1' ]);
//solve([ '6', '1', '3', '-5', '8', '7', '-6' ]);
//solve([ '9', '1', '8', '8', '7', '6', '5', '7', '7', '6' ]);
//solve(['10',
//    '874449546',
//    '-32623247',
//    '-1728460730',
//    '1638773671',
//    '-1841932756',
//    '1806344449',
//    '1504664927',
//    '-189773577',
//    '166443107',
//    '-1202266308']);
//
