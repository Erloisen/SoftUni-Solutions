function calculatingTimeToWalk(steps, footprint, speedKmPerH){
    
    let distance = steps * footprint;
    let speed = speedKmPerH * 1000 / 3600;
    let breaks = Math.floor(distance / 500) * 60;
    let timeToWalk = (distance / speed) + breaks;

    let hours = Math.floor(timeToWalk / 3600);
    let minutes = Math.floor(timeToWalk / 60);
    let seconds = Math.ceil(timeToWalk % 60);

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`);
}

calculatingTimeToWalk(4000, 0.60, 5);
calculatingTimeToWalk(2564, 0.70, 5.5);
