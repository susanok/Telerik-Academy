function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        matrix = new Array(rows),
        i,
        move,
        count,
        currentCell,
        wantedCell,
        dictWithCols = {},
        dictWithRows = {},
        currentRow,
        currentCol,
        wantedCol,
        wantedRow,
        downUpLeftRight,
        diagonally,
        row,
        col,
        res1,
        res2,
        validMove;
    for(i = 0, count = rows; i < rows; i += 1, count -= 1){
        dictWithRows[count] = i;
    }

    for(i = 0, count = 97; i < 26; i += 1, count += 1){
        dictWithCols[ String.fromCharCode(count)] = i;
    }

    for(i = 2, count = 0; i < rows + 2; i += 1, count += 1 ){
        matrix[count] = params[i];
    }

    for (i = 0; i < tests; i++) {
        move = params[rows + 3 + i].split(' ');
        currentCell = move[0];
        wantedCell = move[1];
        currentRow = dictWithRows[currentCell[1]];
        currentCol = dictWithCols[currentCell[0]];
        wantedRow = dictWithRows[wantedCell[1]];
        wantedCol = dictWithCols[wantedCell[0]];

        if(matrix[currentRow][currentCol] === '-' || matrix[wantedRow][wantedCol] !== '-'){
            console.log('no');
        }
        else{
            switch (matrix[currentRow][currentCol]){
                case 'R':
                    downUpLeftRight = true;
                    diagonally = false;
                    break;
                case 'B':
                    downUpLeftRight = false;
                    diagonally = true;
                    break;
                case 'Q':
                    downUpLeftRight = true;
                    diagonally = true;
                    break;
            }

            if(currentCol === wantedCol && currentRow > wantedRow){
                //up
                if(downUpLeftRight){
                    validMove = true;
                    for(row = currentRow - 1; row >= wantedRow; row -= 1){
                        if(matrix[row][currentCol] !== '-'){
                            validMove = false;
                            break;
                        }
                    }

                    if(validMove){
                        console.log('yes');
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol === wantedCol && currentRow < wantedRow){
                //down
                if(downUpLeftRight){
                    validMove = true;
                    for(row = currentRow + 1; row <= wantedRow; row += 1){
                        if(matrix[row][currentCol] !== '-'){
                            validMove = false;
                            break;
                        }
                    }
                    if(validMove){
                        console.log('yes');
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol > wantedCol && currentRow === wantedRow){
                //left
                if(downUpLeftRight){
                    validMove = true;
                    for(col = currentCol - 1; col >= wantedCol; col -= 1){
                        if(matrix[currentRow][col] !== '-'){
                            validMove = false;
                            break;
                        }
                    }
                    if(validMove){
                        console.log('yes');
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol < wantedCol && currentRow === wantedRow){
                //right
                if(downUpLeftRight){
                    validMove = true;
                    for(col = currentCol + 1; col <= wantedCol; col += 1){
                        if(matrix[currentRow][col] !== '-'){
                            validMove = false;
                            break;
                        }
                    }
                    if(validMove){
                        console.log('yes');
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol > wantedCol && currentRow > wantedRow){
                // upLeft
                if(diagonally){
                    validMove = true;
                    res1 = currentCol - wantedCol;
                    res2 = currentRow - wantedRow;
                    if(res1 === res2){
                        for(row = currentRow - 1, col = currentCol - 1;row >= wantedRow; row -= 1, col -= 1){
                            if(matrix[row][col] !== '-'){
                                validMove = false;
                                break;
                            }
                        }
                        if(validMove){
                            console.log('yes');
                        }
                        else{
                            console.log('no');
                        }
                    }
                    else{
                        console.log('no');
                    }

                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol < wantedCol && currentRow < wantedRow){
                //downRight
                if(diagonally){
                    validMove = true;
                    res1 = wantedCol - currentCol;
                    res2 = wantedRow - currentRow;
                    if(res1 === res2){
                        for(row = currentRow + 1, col = currentCol + 1;row <= wantedRow; row += 1, col += 1){
                            if(matrix[row][col] !== '-'){
                                validMove = false;
                                break;
                            }
                        }
                        if(validMove){
                            console.log('yes');
                        }
                        else{
                            console.log('no');
                        }
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol < wantedCol && currentRow > wantedRow){
                //upRight
                if(diagonally){
                    validMove = true;
                    res1 = wantedCol - currentCol;
                    res2 = currentRow - wantedRow;
                    if(res1 === res2){
                        for(row = currentRow - 1, col = currentCol + 1;row >= wantedRow; row -= 1, col += 1){
                            if(matrix[row][col] !== '-'){
                                validMove = false;
                                break;
                            }
                        }
                        if(validMove){
                            console.log('yes');
                        }
                        else{
                            console.log('no');
                        }

                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }
            else if(currentCol > wantedCol && currentRow < wantedRow){
                //downLeft
                if(diagonally){
                    validMove = true;
                    res1 = currentCol - wantedCol;
                    res2 = wantedRow - currentRow;
                    if(res1 === res2){
                        for(row = currentRow + 1, col = currentCol - 1;row <= wantedRow; row += 1, col -= 1){
                            if(matrix[row][col] !== '-'){
                                validMove = false;
                                break;
                            }
                        }
                        if(validMove){
                            console.log('yes');
                        }
                        else{
                            console.log('no');
                        }
                    }
                    else{
                        console.log('no');
                    }
                }
                else{
                    console.log('no');
                }
            }

        }
    }

}

//solve(['7', '8',
//    '---Q----',
//    'Q-------',
//    '------R-',
//    '--------',
//    '-------R',
//    '----B---',
//    '-B------',
//    '8',
//    'd7 h6',
//    'a6 b4',
//    'g5 h7',
//    'd7 g7',
//    'h3 a4',
//    'b1 a2',
//    'b1 d4',
//    'e2 h4']);
//