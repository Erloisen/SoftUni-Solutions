function checkingtheSpeedLimit (speed, area) {
    let speedLimit = 0;
    
    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    let limits = speedLimit - speed;

    if (limits >= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {

        let difference = Math.abs(limits);
        let status = '';

        if (difference <= 20) {
            status = 'speeding';
        } else if (difference <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

checkingtheSpeedLimit(40, 'city');
checkingtheSpeedLimit(21, 'residential');
checkingtheSpeedLimit(120, 'interstate');
checkingtheSpeedLimit(200, 'motorway');
