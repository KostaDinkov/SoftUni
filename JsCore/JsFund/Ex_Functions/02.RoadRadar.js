function roadRadar(radar_data){
    let speedLimits = {'residential':20, 'city':50, 'interstate':90,'motorway':130};

    let speed = radar_data[0];
    let area = radar_data[1];

    let currentLimit = speedLimits[area];

    if (speed>currentLimit){
        let delta = speed-currentLimit;
        if(delta <=20){
            console.log('speeding');
        }
        else if((delta >20) && (delta <=40)){
            console.log('excessive speeding');
        }
        else {
            console.log('reckless driving')
        }
    }
}

roadRadar([10, 'residential']);
