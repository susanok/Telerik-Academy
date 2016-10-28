function solve(args){
  var rowsCols = args[0].split(' ').map(Number),
      rows = rowsCols[0],
      cols = rowsCols[1],
      matrix = new Array(rows),
      i,
      currentRow = rows - 1,
      currentCol = cols - 1,
      rowColChange,
      sum = Math.pow(2, currentRow) - currentCol,
      count = 0;
    for(i = 0; i < rows; i += 1){
        matrix[i] = args[i + 1].split('').map(Number);
    }

    while(1){
        if(matrix[currentRow][currentCol] === 0){
            console.log('Sadly the horse is doomed in '+ count +' jumps');
            break;
        }
        switch (matrix[currentRow][currentCol]){
            case 1:
                rowColChange = {
                    rowChange: -2,
                    colChange: 1
                };
                break;
            case 2:
                rowColChange = {
                    rowChange: -1,
                    colChange: 2
                };
                break;
            case 3:
                rowColChange = {
                    rowChange: 1,
                    colChange: 2
                };
                break;
            case 4:
                rowColChange = {
                    rowChange: 2,
                    colChange: 1
                };
                break;
            case 5:
                rowColChange = {
                    rowChange: 2,
                    colChange: -1
                };
                break;
            case 6:
                rowColChange = {
                    rowChange: 1,
                    colChange: -2
                };
                break;
            case 7:
                rowColChange = {
                    rowChange: -1,
                    colChange: -2
                };
                break;
            case 8:
                rowColChange = {
                    rowChange: -2,
                    colChange: -1
                };
                break;
        }

        matrix[currentRow][currentCol] = 0;

        currentRow += rowColChange.rowChange;
        currentCol += rowColChange.colChange;

        if(currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols){
            console.log('Go go Horsy! Collected '+ sum +' weeds');
            break;
        }
        else{
            sum += Math.pow(2, currentRow) - currentCol;
        }
        count += 1;
    }

}


//solve(['3 5', '54561', '43328', '52388']);
//solve(['3 5', '54361', '43326', '52188']);