function solve(args){
    var rowsCols = args[0].split(' ').map(Number),
        rows = rowsCols[0],
        cols = rowsCols[1],
        coordinatePairs = args[1].split(';'),
        n = parseInt(args[2]),
        count = 0,
        count2 = 7,
        kocetoTanks = 4,
        cukiTanks = 4,
        i,
        row,
        col,
        matrix = [],
        tanks = [];
    tanks.push({row: 0, col: 0});
    tanks.push({row: 0, col: 1});
    tanks.push({row: 0, col: 2});
    tanks.push({row: 0, col: 3});
    tanks.push({row: rows - 1, col: cols - 1});
    tanks.push({row: rows - 1, col: cols - 2});
    tanks.push({row: rows - 1, col: cols - 3});
    tanks.push({row: rows - 1, col: cols - 4});

    for(row = 0; row < rows; row += 1){
        matrix[row] = new Array(cols);
        for(col = 0; col < cols; col += 1){
            if(row === 0 && (col === 0 || col === 1 || col === 2 || col === 3)){
                matrix[row][col] = count;
                count += 1;
            }
            else if(row === rows - 1 && (col === cols - 1 || col === cols - 2 || col === cols - 3 || col === cols - 4)){
                    matrix[row][col] = count2;
                    count2 -= 1;
            }
            else{
                matrix[row][col] = '-';
            }

        }
    }

    for(i = 0; i < coordinatePairs.length; i += 1){
        var pair = coordinatePairs[i].split(' ').map(Number);
        matrix[pair[0]][pair[1]] = 'X';
    }

    //console.log(matrix);

    //commands
    for(i = 3; i < n + 3; i += 1){
        var currentLine = args[i].split(' ');
        var command = currentLine[0];
        var id = +currentLine[1];
        var indexes = searchForCoordinates(id, matrix);

        if(command === 'mv'){
            var cells = +currentLine[2];
            var direction = currentLine[3];

            var currentRow = indexes.row;
            var currentCol = indexes.col;
            var wantedCol = 0;
            var wantedRow = 0;
            var newCol = 0;
            var newRow = 0;

            switch (direction){
                case 'l':
                    wantedCol = currentCol - cells;
                    if(wantedCol < 0){
                        while(1){
                            if(wantedCol < 0){
                                wantedCol += 1;
                            }
                            else{
                                break;
                            }
                        }
                    }

                    for (var j = currentCol - 1; j >= wantedCol; j -= 1) {
                        if(matrix[currentRow][j] === '-'){
                            matrix[currentRow][currentCol] = '-';
                            currentCol = j;
                            matrix[currentRow][j] = id;
                        }
                        else{
                            newCol = j + 1;
                        }
                    }
                    break;
               case 'u':

                   wantedRow = currentRow - cells;
                   if(wantedRow < 0){
                       while(1){
                           if(wantedRow < 0){
                               wantedRow += 1;
                           }
                           else{
                               break;
                           }
                       }
                   }

                   for (var f = currentRow - 1; f >= wantedRow; f -= 1) {
                       if(matrix[f][currentCol] === '-'){
                           matrix[currentRow][currentCol] = '-';
                           currentRow = f;
                           matrix[f][currentCol] = id;
                       }
                       else{
                           newRow = f + 1;
                       }
                   }
                   break;
                case 'r':
                   wantedCol = currentCol + cells;
                   if(wantedCol > cols - 1){
                       while(1){
                           if(wantedCol > cols - 1){
                               wantedCol -= 1;
                           }
                           else{
                               break;
                           }
                       }
                   }

                   for (j = currentCol + 1; j <= wantedCol; j += 1) {
                       if(matrix[currentRow][j] === '-'){
                           matrix[currentRow][currentCol] = '-';
                           currentCol = j;
                           matrix[currentRow][j] = id;
                       }
                       else{
                           newCol = j - 1;
                       }
                   }

                    break;
                case 'd':
                    wantedRow = currentRow + cells;
                    if(wantedRow > rows - 1){
                        while(1){
                            if(wantedRow > rows - 1){
                                wantedRow -= 1;
                            }
                            else{
                                break;
                            }
                        }
                    }

                    for (f = currentRow + 1; f <= wantedRow; f += 1) {
                        if(matrix[f][currentCol] === '-'){
                            matrix[currentRow][currentCol] = '-';
                            currentRow = f;
                            matrix[f][currentCol] = id;
                        }
                        else{
                            newRow = f - 1;
                        }
                    }
                    break;
            }
        }
       else
       {
           var dir = currentLine[2];
           var index = searchForCoordinates(id, matrix);
           var curRow = index.row;
           var curCol = index.col;
           switch (dir) {
               case 'u':
                   for (var z = curRow - 1; z >= 0; z -= 1) {
                       if (matrix[z][curCol] !== '-') {
                           if (matrix[z][curCol] !== 'X') {
                               console.log('Tank ' + matrix[z][curCol] + ' is gg');
                               if (matrix[z][curCol] <= 7 && matrix[z][curCol] >= 4) {
                                   cukiTanks -= 1;
                               }
                               else {
                                   kocetoTanks -= 1;
                               }
                           }
                           matrix[z][curCol] = '-';
                           break;
                       }
                   }
                   break;
               case 'd':
                   for (z = curRow + 1; z < rows; z += 1) {
                       if (matrix[z][curCol] !== '-') {
                           if (matrix[z][curCol] !== 'X') {
                               console.log('Tank ' + matrix[z][curCol]+ ' is gg');
                               if (matrix[z][curCol] <= 7 && matrix[z][curCol] >= 4) {
                                   cukiTanks -= 1;
                               }
                               else {
                                   kocetoTanks -= 1;
                               }
                           }
                           matrix[z][curCol] = '-';
                           break;
                       }
                   }
                   break;
               case 'l':
                   for (z = curCol - 1; z >= 0; z -= 1) {
                       if (matrix[curRow][z] !== '-') {
                           if (matrix[curRow][z] !== 'X') {
                               console.log('Tank ' + matrix[curRow][z] + ' is gg');
                               if (matrix[curRow][z] <= 7 && matrix[curRow][z] >= 4) {
                                   cukiTanks -= 1;
                               }
                               else {
                                   kocetoTanks -= 1;
                               }
                           }
                           matrix[curRow][z] = '-';
                           break;
                       }
                   }
                   break;
               case 'r':
                   for (z = curCol + 1; z < cols; z += 1) {
                       if (matrix[curRow][z] !== '-') {
                           if (matrix[curRow][z] !== 'X') {
                               console.log('Tank ' + matrix[curRow][z] + ' is gg');
                               if (matrix[curRow][z] <= 7 && matrix[curRow][z] >= 4) {
                                   cukiTanks -= 1;
                               }
                               else {
                                   kocetoTanks -= 1;
                               }
                           }
                           matrix[curCol][z] = '-';
                           break;
                       }
                   }
                   break;

           }

       }

       if(cukiTanks === 0){
           console.log('Cuki is gg');
           break;
       }
       else if(kocetoTanks === 0){
           console.log('Koceto is gg');
           break;
       }


    }
    //console.log(matrix);

    function searchForCoordinates(id, matrix){
        var indexes = {
            row: 0,
            col: 0
        };
        for (var j = 0; j < matrix[0].length; j += 1) {
            for (var k = 0; k < matrix[1].length; k++) {
                if(matrix[j][k] === id){
                    indexes.row = j;
                    indexes.col = k;
                }
            }
        }

        return indexes;
    }

}

//solve([
//    '5 5',
//    '2 0;2 1;2 2;2 3;2 4',
//    '13',
//    'mv 7 2 l',
//    'x 7 u',
//    'x 0 d',
//    'x 6 u',
//    'x 5 u',
//    'x 2 d',
//    'x 3 d',
//    'mv 4 1 u',
//    'mv 4 4 l',
//    'mv 1 1 l',
//    'x 4 u',
//    'mv 4 2 r',
//    'x 2 d'
//]);

solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
]);

//solve([
//    '10 5',
//    '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
//    '43',
//    'mv 6 5 r',
//    'mv 0 6 d',
//    'x 0 d',
//    'x 0 d',
//    'x 6 u',
//    'x 6 u',
//    'x 6 u',
//    'x 6 u',
//    'x 6 u',
//    'x 7 u',
//    'x 7 u',
//    'x 7 u',
//    'x 7 u',
//    'x 7 u',
//    'x 3 d',
//    'x 3 d',
//    'x 3 d',
//    'x 3 d',
//    'x 3 d',
//    'x 4 u',
//    'x 4 u',
//    'x 4 u',
//    'x 4 u',
//    'x 4 u',
//    'x 0 r',
//    'mv 0 6 d',
//    'mv 0 9 r',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d',
//    'mv 0 1 l',
//    'x 0 d'
//]);
