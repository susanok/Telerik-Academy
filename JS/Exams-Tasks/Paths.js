function solve(args){
    var rowsCols = args[0].split(' '),
        bounds = {
            rows: +rowsCols[0],
            cols: +rowsCols[1]
        },
        matrix = args.slice(1)
            .map(function (line) {
                return line.split(' ');
            }),
        row = 0,
        col = 0,
        sum = 0,
        dir,
        deltas = {
            u: -1,
            d: +1,
            l: -1,
            r: +1
        },
        leftRight,
        upDown;

    while(1){
        //update sum
        //or if(!matrix[row] || !matrix[row][col])
        if(row < 0 || row >= bounds.rows || col < 0 || col >= bounds.cols){
            return 'successed with ' + sum;
        }

        if(matrix[row][col] === 'used'){
            return 'failed at (' +  row + ', ' + col + ')';
        }

        sum += (1<<row) + col;
        dir = matrix[row][ col];
        matrix[row][col] = 'used';
        upDown = dir[0];
        leftRight = dir[1];

        //update row
        row += deltas[upDown];
        //update col
        col += deltas[leftRight];

    }
    return matrix;
}

var tests = [
    [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
    ],
    [
        '3 5',
        'dr dl dl ur ul',
        'dr dr ul ul ur',
        'dl dr ur dl ur'
    ]
];

tests.forEach(function(test){
    console.log(solve(test));
});