function ticTacToe(moves) {
    const dashboard = [[false, false, false],
                       [false, false, false],
                       [false, false, false]];

    let player = 'X';
    let wins = false;

    while (true) {
        let [row, col] = moves.shift().split(' ').map(num => Number(num));

        if (dashboard[row][col]) {
            console.log('This place is already taken. Please choose another!');
            continue;
        }
        
        dashboard[row][col] = player;

        if (checkRightDiagonal(dashboard) ||
            checkLeftDiagonal(dashboard) ||
            checkRows(dashboard, row) || 
            checkCols(dashboard, col, player)) {

            console.log(`Player ${player} wins!`);
            break;
        }

        if(fullDashboard(dashboard)) {
            console.log('The game ended! Nobody wins :(');
            break;
        }

        player = (player === 'X') ? 'O' : 'X';
    }

    printDashboard(dashboard);

    function checkRightDiagonal(dashboard) {
        for (let i = 1; i < 3; i++) {
            if (dashboard[0][0] != false) {
                wins = dashboard[0][0] === dashboard[i][i] ? true : false;
                if (!wins) {
                    break;
                }
            }
        }

        return wins;
    }

    function checkLeftDiagonal(dashboard) {
        let lastElement = dashboard.length - 1;
        for (let i = 1; i < 3; i++) {
            if (dashboard[0][lastElement] != false) {
                wins = dashboard[0][lastElement] === dashboard[i][lastElement - i] ? true : false;
                if (!wins) {
                    break;
                }
            }
        }

        return wins;
    }

    function checkRows(dashboard, row) {
        wins = dashboard[row].every((x, i, arr) => x === arr[0]);
        return wins;
    }

    function checkCols(dashboard, col, player) {
        wins = dashboard.map(row => row[col]).every(x => x === player);
        return wins;
    }

    function fullDashboard(dashboard) {
        return dashboard.every(row => row.every(x => x !== false));
    }

    function printDashboard(dashboard) {
        for (const row of dashboard) {
            console.log(row.join('\t'));
        }
    }
}

ticTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);
console.log('--------------------------------------------------------------------');
ticTacToe(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);
console.log('--------------------------------------------------------------------');
ticTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]);
console.log('--------------------------------------------------------------------');
ticTacToe(["0 0", "0 2", "1 0", "2 0", "0 0", "2 1", "1 1"]);
console.log('--------------------------------------------------------------------');