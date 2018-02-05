function nowPlaying(data){

    let title = data[0];
    let artist = data[1];
    let duration = data[2];

    console.log(`Now Playing: ${artist} - ${title} [${duration}]`);

}

nowPlaying(['Number One', 'Nelly', '4:09'])