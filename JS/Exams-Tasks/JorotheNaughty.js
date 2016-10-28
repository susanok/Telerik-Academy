function solve(args){
    var rowsColsJumps = args[0].split(' ').map(Number),
        rows = rowsColsJumps[0],
        cols = rowsColsJumps[1],
        startsRowCol = args[1].split(' ').map(Number),
        currentRow = startsRowCol[0],
        currentCol = startsRowCol[1],
        jumps = new Array(rowsColsJumps[2]),
        i,
        j,
        sum = 1,
        numberOfJumps = 0,
        matrix = new Array(rows),
        row,
        col,
        count = 1,
        jumpRowCol,
        jumpRow,
        jumpCol;
    for(row = 0; row < rows; row += 1){
        matrix[row] = new Array(cols);
        for(col = 0; col < cols; col += 1){
            matrix[row][col] = count;
            count+= 1;
        }
    }

    count = 0;

    for(i = 2, j = 0; i < rowsColsJumps[2] + 2; i += 1, j += 1){
        jumps[j] = args[i];
    }

    while(1){
        numberOfJumps += 1;
        if(count === rowsColsJumps[2]){
            count = 0;
        }

        jumpRowCol = jumps[count].split(' ').map(Number);
        jumpRow = jumpRowCol[0];
        jumpCol = jumpRowCol[1];

        matrix[currentRow][currentCol] = 0;

        currentRow += jumpRow;
        currentCol += jumpCol;

        if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols){
            console.log('escaped ' + sum);
            break;
        }
        if(matrix[currentRow][currentCol] === 0){
            console.log('caught ' + numberOfJumps);
        }

        sum += matrix[currentRow][currentCol];

        count += 1;
    }
}

//solve([ '6 7 3',
//    '0 0',
//    '2 2',
//    '-2 2',
//    '3 -1' ]);
